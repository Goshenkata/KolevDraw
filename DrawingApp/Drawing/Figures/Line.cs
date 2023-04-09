using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Drawing.Figures
{
    public class Line : Figure
    {
        public Line()
        {
        }

        private Line(Figure f) : base(f)
        {
        }

        public override object Clone()
        {
            return new Line(this);
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, StartingPoint, EndingPoint);
        }
    }
}
