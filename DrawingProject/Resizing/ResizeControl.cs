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
			Resizer.MouseDown(e);
		}

		private void ResizeControl_MouseMove(object sender, MouseEventArgs e)
		{
			Resizer.MouseMoved(e);
		}
	}
}
