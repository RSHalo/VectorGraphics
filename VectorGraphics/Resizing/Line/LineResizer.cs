using System.Drawing;
using System.Windows.Forms;
using VectorGraphics.Drawables;

namespace VectorGraphics.Resizing.Line
{
    class LineResizer : ResizeControl
	{
		private readonly IDrawableLine _drawnLine;

		private readonly bool _isStartPoint = false;

		public LineResizer(IDrawableLine drawableLine, bool isStartPoint) : base()
		{
			_drawnLine = drawableLine;
			_isStartPoint = isStartPoint;

			UpdateWorldCoords();

			_cursor = Cursors.SizeNESW;
		}

		protected override void ResizeShape()
		{
			if (_isStartPoint)
			{
				_drawnLine.StartPoint = new Point(_drawnLine.StartPoint.X + DxWorld, _drawnLine.StartPoint.Y + DyWorld);
			}
			else
			{
				_drawnLine.EndPoint = new Point(_drawnLine.EndPoint.X + DxWorld, _drawnLine.EndPoint.Y + DyWorld);
			}
		}

		protected override void MoveControl(MouseEventArgs e)
		{
			base.MoveControl(e);

			// Move the control freely
			Left += dx;
			Top += dy;
		}

		protected override void UpdateWorldCoords()
		{
			// Set the control to be displayed at one end of the line. Either the start or end, depending on _isStartPoint.
			Point pointOnDrawnLine = _isStartPoint ? _drawnLine.StartPoint : _drawnLine.EndPoint;
			WorldX = pointOnDrawnLine.X;
			WorldY = pointOnDrawnLine.Y;
		}
	}
}
