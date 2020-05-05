using DrawingProject.Drawables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingProject.Resizing
{
	/// <summary>Contains the world-space information that is used to generate the resize controls.</summary>
	public abstract class Resizer
	{
		public const int DefaultSideLength = 5;

		/// <summary>Flags whether or not the user is currently resizing.</summary>
		public bool IsResizing { get; set; } = false;

		/// <summary>The X coordinate of the required resize control, in world space.</summary>
		public float X { get; protected set; }

		/// <summary>The Y coordinate of the required resize control, in world space.</summary>
		public float Y { get; protected set; }

		/// <summary>The drawable shape that the resizer belongs to.</summary>
		IDrawable ParentShape { get; }

		/// <summary>Resizes the Shape according to user actions.</summary>
		public abstract void Rezise();

		public virtual void MouseDown(MouseEventArgs e)
		{

		}

		public virtual void MouseMoved(MouseEventArgs e)
		{
			
		}

		public virtual void MouseUp(MouseEventArgs e)
		{

		}
	}
}
