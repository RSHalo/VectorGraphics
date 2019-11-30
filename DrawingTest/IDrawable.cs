﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingTest
{
    interface IDrawable
    {
        Pen Pen { get; set; }

        void Draw(Graphics graphics);
    }
}
