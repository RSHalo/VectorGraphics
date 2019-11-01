using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingTest
{
    public partial class Form1 : Form
    {
        List<Line> drawnLines = new List<Line>
        {
            new Line(new Pen(Color.Red), new Point(10, 10), new Point(50, 50)),
            new Line(new Pen(Color.Red), new Point(100, 150), new Point(200, 200))
        };

        List<Rectangle> drawnRectangles = new List<Rectangle>();

        public Form1()
        {
            InitializeComponent();
        }

        private void PnlDrawingSurface_Paint(object sender, PaintEventArgs e)
        {
            // All drawing happens when this Panel is painted on the screen.
            // You don't just draw a line and expect it to persist. The drawing will dissapear when you minimise then maximise the form.
            // So, if we do all drawing when the containing Panel is drawn, then any time we can see our Panel, all our lines/rectangles will have been drawn too.
            // This is a very important concept. When you want to research, do a Google search like: "Drawing Paint event", "Drawing OnPaint override".

            foreach (Line line in drawnLines)
            {
                e.Graphics.DrawLine(line.Pen, line.StartPoint, line.EndPoint);
            }

            foreach (var rectangle in drawnRectangles)
            {
                e.Graphics.DrawRectangles(new Pen(Color.Coral), drawnRectangles.ToArray());
            }
        }

        private void BtnDrawLine_Click(object sender, EventArgs e)
        {
            Line line = new Line(new Pen(Color.Blue), new Point(75, 50), new Point(30, 80));
            drawnLines.Add(line);

            // Invalidate causes the control to be redrawn.
            // As we said before, we want the panel to be redrawn so that all of our drawings will be redrawn.
            pnlDrawingSurface.Invalidate();
        }

        private void BtnDrawThickLine_Click(object sender, EventArgs e)
        {
            Line line = new Line(new Pen(Color.Blue, 2), new Point(175, 150), new Point(130, 180));
            drawnLines.Add(line);

            pnlDrawingSurface.Invalidate();
        }

        private void BtnDrawRectangle_Click(object sender, EventArgs e)
        {
            Rectangle rectangle = new Rectangle(105, 30, 75, 20);
            drawnRectangles.Add(rectangle);

            pnlDrawingSurface.Invalidate();
        }
    }
}
