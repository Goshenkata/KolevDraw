using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Drawing.Figures
{
    public class Ellipse : Figure
    {

        private Ellipse(Figure f) : base(f)
        {
        }

        public Ellipse()
        {
        }

        public override double GetArea()
        {

            return Math.PI * GetXRadius() * GetYRadius();
        }
        public override double GetPerimeter()
        {
            // Ramanujan Formula
            //  π [ 3 (a + b) - √[(3a + b) (a + 3b) ]]
            double a = GetXRadius();
            double b = GetYRadius();
            return Math.PI * (3 * (a + b) - Math.Sqrt((3 * a + b) * (a + 3 * b)));
        }

        private double GetXRadius()
        {
            return (EndingPoint.X - StartingPoint.X) / 2;
        }
        private double GetYRadius()
        {
            return (EndingPoint.Y - StartingPoint.Y) / 2;
        }

        public override object Clone()
        {
            return new Ellipse(this);
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Blue);
            g.FillEllipse(brush, this);
            g.DrawEllipse(pen, this);
        }
    }
}
