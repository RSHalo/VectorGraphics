using System.Drawing;
using System.Windows.Forms;
using VectorGraphics.Canvas;
using VectorGraphics.Drawables;

namespace VectorGraphics.Tools
{
    public class Tool : ICanvasRepainter
    {
        public CanvasControl Canvas { get; set; }
        public bool IsDrawing { get; protected set; }
        public bool IsControlHeld { get; set; }

        /// <summary>The X co-ordinate of the tool's mouse position, in world space.</summary>
        public int WorldX { get; set; }
        /// <summary>The Y co-ordinate of the tool's mouse position, in world space.</summary>
        public int WorldY { get; set; }

        public Point WorldPoint => new Point(WorldX, WorldY);

        /// <summary>The shape to be drawn while the tool is creating a final result.</summary>
        // E.g. The rectangle that moves along with the mouse when you are drawing a rectangle.
        public IDrawable CreationDrawable { get; protected set; }

        public Cursor Cursor { get; protected set; } = Cursors.Cross;

        /// <summary>Transforms screen coordinates to world co-ordinates and assigns them to the tool.</summary>
        public void UpdateWorldCoords(MouseEventArgs e)
        {
            PointF point = Canvas.ScreenToWorld(e.X, e.Y);

            WorldX = (int)point.X;
            WorldY = (int)point.Y;
        }

        public virtual void MouseDown(MouseEventArgs e)
        {

        }

        public virtual void MouseMoved(MouseEventArgs e)
        {

        }

        public virtual void MouseUp(MouseEventArgs e)
        {

        }

        public virtual void Clicked(MouseEventArgs e)
        {

        }

        public void RepaintCanvas()
        {
            Canvas.Repaint();
        }
    }
}
