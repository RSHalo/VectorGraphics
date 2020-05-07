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
		public CanvasControl Canvas { get; set; }

		public const int DefaultSideLength = 5;

		public int SideLength => (int)(Canvas.ZoomScale * DefaultSideLength);

		/// <summary>Flags whether or not the user is currently resizing.</summary>
		public bool IsResizing { get; set; } = false;

		/// <summary>The X coordinate of the required resize control, in world space.</summary>
		public float WorldX { get; protected set; }

		/// <summary>The Y coordinate of the required resize control, in world space.</summary>
		public float WorldY { get; protected set; }

		/// <summary>The drawable shape that the resizer belongs to.</summary>
		public IDrawable ParentShape { get; protected set; }

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


		public ResizeControl()
		{
			InitializeComponent();
		}

		protected void ResizeControl_MouseDown(object sender, MouseEventArgs e)
		{
			IsResizing = true;
			_startCursorPoint = new Point(e.X, e.Y);
		}

		protected virtual void ResizeControl_MouseMove(object sender, MouseEventArgs e)
		{
			if (!IsResizing)
				return;

			MoveControl(e);

			ResizeShape();

			// The other resize controls on the canvas may be need to moved around as a result of moving this one.
			// E.g. Consider how a left rectangle resizer will need to be moved as a result of changing a rectangle's height using a top rectangle resizer. 
			Canvas.RefreshResizers();
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

		private void ResizeControl_MouseUp(object sender, MouseEventArgs e)
		{
			IsResizing = false;
		}

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

	}
}
