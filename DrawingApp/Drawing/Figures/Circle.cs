using DrawingApp.Drawing.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Drawing.Figures

{
    public class Circle : Figure
    {
        public Circle() { } 
        private Circle(Figure f) : base(f)
        {
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(GetRadius(),2);
        }
        public override double GetPerimeter()
        {
            return 2 * Math.PI * GetRadius();
        }

        private double GetRadius()
        {
            return (EndingPoint.X - StartingPoint.X) / 2;
        }

        public override object Clone()
        {
            return new Circle(this);
        }

        public override void Draw(Graphics g)
        {
            int a = EndingPoint.X - StartingPoint.X;
            EndingPoint.Y = StartingPoint.Y + a;
            base.fixPoints();
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Blue);
            g.FillEllipse(brush, this);
            g.DrawEllipse(pen, this);
        }

    }
}
