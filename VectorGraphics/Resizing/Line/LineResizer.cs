using VectorGraphics.Drawables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorGraphics.Resizing.Line
{
	class LineResizer : ResizeControl
	{
		private readonly DrawableLine _drawnLine;

		private bool IsStartPoint = false;

		public LineResizer(DrawableLine drawableLine, bool isStartPoint) : base()
		{
			_drawnLine = drawableLine;
			IsStartPoint = isStartPoint;

			// Set the control to be displayed at one end of the line. Either the start or end.
			WorldX = IsStartPoint ? _drawnLine.StartPoint.X : _drawnLine.EndPoint.X;
			WorldY = IsStartPoint ? _drawnLine.StartPoint.Y : _drawnLine.EndPoint.Y;

			_cursor = Cursors.SizeNESW;
		}

		protected override void ResizeShape()
		{
			if (IsStartPoint)
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
			WorldX = IsStartPoint ? _drawnLine.StartPoint.X : _drawnLine.EndPoint.X;
			WorldY = IsStartPoint ? _drawnLine.StartPoint.Y : _drawnLine.EndPoint.Y;
		}
	}
}
