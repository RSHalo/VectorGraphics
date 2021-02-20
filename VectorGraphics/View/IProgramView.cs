using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphics.Tools;

namespace VectorGraphics.View
{
    interface IProgramView
    {
        /// <summary>The tool currently in use.</summary>
        Tool Tool { get; }

        /// <summary>Saves the drawings on the canvas.</summary>
        void Save();

        /// <summary>Deletes the selected shape.</summary>
        void DeleteSelectedShape();
    }
}
