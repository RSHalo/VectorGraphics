using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingProject.Resizing
{
	public partial class ResizeControl : UserControl
	{
		public const string TagId = "ResizeControl"; 

		public Resizer Resizer { get; set; }

		/// <summary>Flags whether or not the user is currently resizing.</summary>
		public bool IsResizing { get; set; } = false;

		/// <summary>
		/// The position of the cursor when a user first holds the mouse down on the resize control. This is in screen space becuase we get this value
		/// from MouseEventArgs e.X
		/// </summary>
		protected Point _startCursorPoint;

		public ResizeControl()
		{
			InitializeComponent();
		}

		public ResizeControl(int locationX, int locationY) : this()
		{
			Location = new Point(locationX, locationY);
		}

		private void ResizeControl_Click(object sender, EventArgs e)
		{
			//MessageBox.Show(Resizer.GetType().ToString());
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
