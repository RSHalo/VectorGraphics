using System.Linq;
using System.Windows.Forms;
using VectorGraphics.Drawables;

namespace VectorGraphics.Tools
{
    class Pointer : Tool
    {
        public Pointer() : base()
        {
            Cursor = Cursors.Default;
        }

        public override void MouseUp(MouseEventArgs e)
        {
            // Tell the Canvas what shape we hit. If no shape hit, value is null (because we are using FirstOrDefault).
            var shape = Canvas.Drawables.FirstOrDefault(d => d.HitTest(WorldX, WorldY));
            HandleNewSelection(shape);
        }

        private void HandleNewSelection(IDrawable shape)
        {
            if (shape == null)
            {
                // Check for IsControlHeld to ensure that we don't reset the selection when the user is selecting a large number of shapes.
                // This is for UX purposes.
                if (IsControlHeld == false)
                {
                    Canvas.Drawables.UnselectAll();
                }

                return;
            }

            if (Canvas.Drawables.SelectedShapes.Any(s => s.Id == shape.Id))
            {
                // The shape is already selected, so unselect it.
                Canvas.Drawables.UnselectShape(shape);
                return;
            }

            if (IsControlHeld)
            {
                // When control is held, we want to enable multi-select. So add the shape the existing selection.
                Canvas.Drawables.SelectShape(shape);
            }
            else
            {
                Canvas.Drawables.SelectSingleShape(shape);
            }
        }
    }
}
