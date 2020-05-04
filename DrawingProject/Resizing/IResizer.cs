using DrawingProject.Drawables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProject.Resizing
{
	public interface IResizer
	{
		/// <summary>The X coordinate of the required resize control, in world space.</summary>
		int X { get; }

		/// <summary>The Y coordinate of the required resize control, in world space.</summary>
		int Y { get; }

		/// <summary>The drawable shape that the resizer belongs to.</summary>
		IDrawable ParentShape { get; }

		/// <summary>Resizes the Shape according to user actions.</summary>
		void Rezise();
	}
}
