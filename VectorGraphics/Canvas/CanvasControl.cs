using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VectorGraphics.Canvas;
using VectorGraphics.Drawables;
using VectorGraphics.KeyHanding;
using VectorGraphics.Movement;
using VectorGraphics.Resizing;
using VectorGraphics.Tools;

public class CanvasControl : SelectablePanel, ICanvas
{
    private readonly IKeyHandler _keyHandler;

	public DrawableCollection Drawables { get; } = new DrawableCollection();

    /// <summary>Current ResizeControls on the canvas.</summary>
    public Dictionary<string, List<ResizeControl>> Resizers = new Dictionary<string, List<ResizeControl>>();

    public Tool Tool { get; private set; } = new Tool();

    public float OffsetX { get; set; }
    public float OffsetY { get; set; }

    /// <summary>The scale factor which determines how zoomed in/out the view is.</summary>
    public float ZoomScale { get; private set; } = 1;
    private int mouseWheelIndent;

    /// <summary>World coordinates of the mouse position before zooming.</summary>
    public PointF BeforeZoomWorld { get; private set; }
    /// <summary>World coordinates of the mouse position after zooming.</summary>
    public PointF AfterZoomWorld { get; private set; }

    /// <summary>The SmoothingMode selected by the user.</summary>
    public SmoothingMode SmoothingMode { get; set; }

    public CanvasControl()
    {
        DoubleBuffered = true;
        SetStyle(ControlStyles.ResizeRedraw, true);
        mouseWheelIndent = 0;
        ZoomScale = 1;

        _keyHandler = new CanvasKeyHandler(this);

        // An event is published when the selected shape is changed. The canvas is subscribed to this event so that it can react accordingly.
        Drawables.SelectedShapeChanged += OnSelectedShapeChanged;
    }

    public void Repaint()
    {
        Invalidate();
    }

    // May not work on non Windows 10. Haven't tested.
    // When we scale, the world coordinates under the mouse change (they move to a different part of the screen).
    // The difference between the world coordinates before and after scaling tells us how much we will need to move the world around to the get the
    // original world point back at the same screen position.
    protected override void OnMouseWheel(MouseEventArgs e)
    {
        base.OnMouseWheel(e);

        // The world coordinate under the mouse before scaling.
        BeforeZoomWorld = ScreenToWorld(e.X, e.Y);

        UpdateZoomScale(e);

        // The world coordinate under the mouse after scaling.
        AfterZoomWorld = ScreenToWorld(e.X, e.Y);

        // The X and Y changes between the two world coordinates. These represent the distances that the world needs to move to place the original world coordinate correctly.
        // These values will be negative when zooming in on the 4th Cartesian quadrant.
        float dx = AfterZoomWorld.X - BeforeZoomWorld.X;
        float dy = AfterZoomWorld.Y - BeforeZoomWorld.Y;

        // These changes need to be scaled! This is because the parameters of ScaleTransform are in pixels, and they need to be scaled to match the world coords (which have been scaled).
        dx *= ZoomScale;
        dy *= ZoomScale;

        // Add these changes to the current ZoomOffsets. This is updating the distances that TranslateTransform actually uses to move the world around.
        OffsetX += dx;
        OffsetY += dy;

        // Refresh instead of Invalidate to get synchronous updating. Prevents errors with very fast mouse wheel scrolling.
        Refresh();
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        _keyHandler.HandleKeyDown(e, e.Modifiers);
    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
        _keyHandler.HandleKeyUp(e, e.Modifiers);
    }

    /// <summary>Updates ZoomScale.</summary>
    private void UpdateZoomScale(MouseEventArgs e)
    {
        if (e.Delta > 0)
        {
            mouseWheelIndent++;
        }
        else
        {
            mouseWheelIndent--;
        }

        ZoomScale = mouseWheelIndent >= 0 ? mouseWheelIndent + 1 : (1 / (-mouseWheelIndent + 1f));
    }

    /// <summary>Gets corresponding world coordinates, given screen coordinates.</summary>
    public PointF ScreenToWorld(float screenX, float screenY)
    {
        float worldX = (screenX - OffsetX) / ZoomScale;
        float worldY = (screenY - OffsetY) / ZoomScale;

        return new PointF(worldX, worldY);
    }

    /// <summary>Gets corresponding screen coordinates, given world coordinates.</summary>
    public PointF WorldToScreen(float worldX, float worldY)
    {
        float screenX = OffsetX + (worldX * ZoomScale);
        float screenY = OffsetY + (worldY * ZoomScale);

        return new PointF(screenX, screenY);
    }

    /// <summary>Clears to a blank canvas.</summary>
    public void Clear()
    {
        Drawables.Clear();
        ResetView();
    }

    /// <summary>
    /// Resets the canvas view, ready for user drawing, by defaulting things like zoom and offset.
    /// This does not clear the canvas' drawings, use <see cref="Clear"/> for that.
    /// </summary>
    public void ResetView()
    {
        Drawables.DeleteSelectedShapes();

        OffsetX = 0f;
        OffsetY = 0f;

        mouseWheelIndent = 0;
        ZoomScale = 1;

        Repaint();
    }

    public void AddShape(IDrawable shape)
    {
        Drawables.AddShape(shape);
    }

    public void MoveShape(IDrawable shape, MovementType movementType)
    {
        shape.MoveBehaviour.Move(movementType);
        Repaint();
    }

    /// <summary>Performs any required action before loading shapes from a file.</summary>
    public void PreLoad()
    {
        Clear();
    }

    public void DeleteSelectedShapes()
    {
        Drawables.DeleteSelectedShapes();
        Repaint();
    }

    /// <summary>Gets the appropriate resize controls for the newly selected shape.</summary>
    public void OnSelectedShapeChanged(object source, EventArgs e)
    {
        RemoveResizeControls();
        AddResizeControls();
    }

    public void AddResizeControls()
    {
        // When the selected shapes change, new resize controls are needed.
        foreach (IDrawable selectedShape in Drawables.SelectedShapes)
        {
            List<ResizeControl> resizers = selectedShape.GetResizers();

            // Add ResizeControls to the canvas.
            foreach (ResizeControl resizer in resizers)
            {
                resizer.Canvas = this;
                resizer.UpdateWorldState();
                Controls.Add(resizer);
            }

            Resizers[selectedShape.Id] = resizers;
        }
    }

    public void RemoveResizeControls()
    {
        foreach (List<ResizeControl> resizers in Resizers.Values)
        {
            foreach (ResizeControl resizer in resizers)
            {
                Controls.Remove(resizer);
            }
        }

        Resizers.Clear();
    }

    /// <summary>
    /// Updates the locations and sizes of the current resizer controls appropriately, based on the underlying IDrawable, as well as canvas offset/zoom scale.
    /// </summary>
    public void RefreshResizers()
    {
        foreach (List<ResizeControl> resizers in Resizers.Values)
        {
            foreach (ResizeControl resizer in resizers)
            {
                resizer.UpdateWorldState();
            }
        }
    }

    #region Event handlers for mouse events
    protected override void OnMouseDown(MouseEventArgs e)
    {
        Tool.MouseDown(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        // TODO:
        // Refactor note: Does MainForm.MainCanvas_MouseMove still get called?
        // If it does, then does this or MainForm.MainCanvas_MouseMove get called first?
        Tool.UpdateWorldCoords(e);
        Tool.MouseMoved(e);
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        Tool.Clicked(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        Tool.MouseUp(e);
    }
    #endregion

    protected override void OnPaint(PaintEventArgs e)
    {
        // Some of this may not belong in the canvas code, like updating peripherals. They will need to move.
        // Also, do I need to call base.OnPaint() here?

        var graphics = e.Graphics;

        graphics.SmoothingMode = SmoothingMode;

        // Apply scaling defined by Canvas.ZoomScale
        graphics.ScaleTransform(ZoomScale, ZoomScale, MatrixOrder.Append);

        // Apply the translation defined by the offset values.
        graphics.TranslateTransform(OffsetX, OffsetY, MatrixOrder.Append);

        // All drawing happens when this Canvas is painted on the screen.
        // You don't just draw a line and expect it to persist. The drawing will disappear when you minimise then maximise the form.
        // So, if we do all drawing when the containing Panel is drawn, then any time we can see our Panel, all our lines/rectangles will have been drawn too.
        // This is a very important concept. When you want to research, do a Google search like: "Drawing Paint event", "Drawing OnPaint override".
        foreach (IDrawable drawable in Drawables)
        {
            drawable.Draw(graphics);
        }

        // When you draw a shape, you may drag your mouse to construct the shape. While this happens, IsDrawing will be set to true.
        // We want to show the shape being created by the mouse moving, so we draw the Tool's "CreationDrawable" shape.
        if (Tool.IsDrawing)
        {
            Tool.CreationDrawable?.Draw(graphics);
        }

        RefreshResizers();
    }

    public T SetupTool<T>() where T : Tool, new()
    {
        // Create new instance of the specified tool and assign it's canvas.
        T tool = new T
        {
            Canvas = this
        };

        Tool = tool;
        Cursor = tool.Cursor;
        return tool;
    }
}
