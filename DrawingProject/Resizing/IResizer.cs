using DrawingProject.Drawables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProject.Resizing
{
	public abstract class Resizer
	{
		public const int DefaultSideLength = 5;

		/// <summary>The X coordinate of the required resize control, in world space.</summary>
		public float X { get; protected set; }

		/// <summary>The Y coordinate of the required resize control, in world space.</summary>
		public float Y { get; protected set; }

		/// <summary>The drawable shape that the resizer belongs to.</summary>
		IDrawable ParentShape { get; }

		/// <summary>Resizes the Shape according to user actions.</summary>
		public abstract void Rezise();
	}
}
