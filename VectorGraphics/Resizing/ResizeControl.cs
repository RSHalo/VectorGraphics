using System;
using System.Drawing;
using System.Windows.Forms;
using VectorGraphics.KeyHanding.Extensions;

namespace VectorGraphics.Resizing
{
	public abstract partial class ResizeControl : UserControl
	{
		public CanvasControl Canvas { get; set; }

		public const int DefaultSideLength = 10;

		public int SideLength => (int)(Canvas.ZoomScale * DefaultSideLength);

		/// <summary>Flags whether or not the user is currently resizing.</summary>
		public bool IsResizing { get; set; } = false;

		/// <summary>The X coordinate of the required resize control, in world space.</summary>
		public float WorldX { get; protected set; }

		/// <summary>The Y coordinate of the required resize control, in world space.</summary>
		public float WorldY { get; protected set; }

		/// <summary>
		/// The position of the cursor when a user first holds the mouse down on the resize control. This is in screen space becuase we get this value
		/// from MouseEventArgs e.X. This is used for dragging the control around
		/// </summary>
		protected Point _startCursorPoint;

		/// <summary>
		/// The position of the cursor after a mouse move event. This is in screen space. This is used for dragging the control around.
		/// </summary>
		protected Point _currentCursorPoint;

		/// <summary>The screen space x-direction change of the cursor after a mouse drag.</summary>
		protected int dx;
		/// <summary>The screen space y-direction change of the cursor after a mouse drag.</summary>
		protected int dy;

		/// <summary>The world space x-direction change of the cursor after a mouse drag.</summary>
		protected int DxWorld => (int)(dx / Canvas.ZoomScale);
		/// <summary>The world space y-direction change of the cursor after a mouse drag.</summary>
		protected int DyWorld => (int)(dy / Canvas.ZoomScale);

		private Cursor _cursorBeforeEnter;
		protected Cursor _cursor;

		public ResizeControl()
		{
			InitializeComponent();
			TabStop = false;
		}

		protected void ResizeControl_MouseDown(object sender, MouseEventArgs e)
		{
			IsResizing = true;
			_startCursorPoint = new Point(e.X, e.Y);
		}

		protected virtual void ResizeControl_MouseMove(object sender, MouseEventArgs e)
		{
			if (IsResizing)
            {
                MoveControl(e);
                ResizeShape();

                // Redraw the canvas after resizing the underlying IDrawable. This will show the IDrawable changes, but will also trigger the positions of the other
                // resize controls to update. Other resize controls will need their positions updated when one control is moved. E.g. Consider how a left rectangle resizer will need to
                // moves when the rectangle is moved due to a top rectangle resizer.
                Canvas.Repaint();
            }
		}

		private void ResizeControl_MouseUp(object sender, MouseEventArgs e)
		{
			IsResizing = false;
			
			// Focusing the canvas on MouseUp means that key presses (for things like moving shapes) go directly to the canvas.
			// Another solution would be to remove this Canvas.Focus() call and instead attach handlers (defined in canvas) to the resizers key events.
			// This would also require the resizer control to configure arrow keys as input keys.
			Canvas.Focus();
		}

		/// <summary>Moves the resize control to give the appearance of dragging.</summary>
		protected virtual void MoveControl(MouseEventArgs e)
		{
			_currentCursorPoint = new Point(e.X, e.Y);

			dx = _currentCursorPoint.X - _startCursorPoint.X;
			dy = _currentCursorPoint.Y - _startCursorPoint.Y;
		}

		/// <summary>Resizes the underlying IDrawable shape that this control belongs to.</summary>
		protected abstract void ResizeShape();

		/// <summary>Updates the world space sizing and locations of the control, to correctly align with the ParentShape.</summary>
		public virtual void UpdateWorldState()
		{
			// For sizing
			Height = SideLength;
			Width = SideLength;

			// For positioning
			UpdateWorldCoords();

			UpdateLocation();
		}

		/// <summary>Updates the world space coordinates of the control.</summary>
		protected abstract void UpdateWorldCoords();

		private void UpdateLocation()
		{
			var screenCoords = Canvas.WorldToScreen(WorldX, WorldY);
			var screenLocation = new Point((int)screenCoords.X, (int)screenCoords.Y);

			Location = screenLocation;
		}

		private void ResizeControl_MouseEnter(object sender, EventArgs e)
		{
			// Store the cursor icon before the mouse entered the control, so that it can be restored when the mouse leaves.
			_cursorBeforeEnter = Canvas.Cursor;

			// Change the cursor icon. This is for visual effect.
			Canvas.Cursor = _cursor;
		}

		private void ResizeControl_MouseLeave(object sender, EventArgs e)
		{
			Canvas.Cursor = _cursorBeforeEnter;
		}
	}
}
