using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingProject.Drawables;

namespace DrawingProject.Resizing
{
	public abstract partial class ResizeControl : UserControl
	{
		public const string TagId = "ResizeControl";

		public const int DefaultSideLength = 5;

		/// <summary>Flags whether or not the user is currently resizing.</summary>
		public bool IsResizing { get; set; } = false;

		/// <summary>The X coordinate of the required resize control, in world space.</summary>
		public float WorldX { get; protected set; }

		/// <summary>The Y coordinate of the required resize control, in world space.</summary>
		public float WorldY { get; protected set; }

		/// <summary>The drawable shape that the resizer belongs to.</summary>
		public IDrawable ParentShape { get; protected set; }

		/// <summary>Resizes the Shape according to user actions.</summary>
		public abstract void Rezise();

		/// <summary>
		/// The position of the cursor when a user first holds the mouse down on the resize control. This is in screen space becuase we get this value
		/// from MouseEventArgs e.X
		/// </summary>
		protected Point _startCursorPoint;

		public ResizeControl()
		{
			InitializeComponent();
		}

		private void ResizeControl_MouseDown(object sender, MouseEventArgs e)
		{
			IsResizing = true;
			_startCursorPoint = new Point(e.X, e.Y);

			//Resizer.MouseDown(e);
		}

		private void ResizeControl_MouseMove(object sender, MouseEventArgs e)
		{
			if (!IsResizing)
				return;

			var currentCursorPoint = new Point(e.X, e.Y);

			int dx = currentCursorPoint.X - _startCursorPoint.X;
			int dy = currentCursorPoint.Y - _startCursorPoint.Y;

			Left += dx;
			Top += dy;
		}

		private void ResizeControl_MouseUp(object sender, MouseEventArgs e)
		{
			IsResizing = false;
		}
	}
}
