using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Drawing.Figures
{
    public class Square : Figure
    {
        public Square() {
        }

        public Square(Figure f) : base(f) { }

        public override object Clone()
        {
            return new Square(this);
        }

        public override void Draw(Graphics g)
        {
            int a = EndingPoint.X - StartingPoint.X;
            EndingPoint.Y = StartingPoint.Y + a;
            base.fixPoints();
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Blue);
            g.FillRectangle(brush, this);
            g.DrawRectangle(pen, this);
        }

        public static  implicit operator System.Drawing.Rectangle(Square rect)
        {
            Size size = new Size(rect.EndingPoint.X - rect.StartingPoint.X, rect.EndingPoint.Y - rect.StartingPoint.Y);
            return new System.Drawing.Rectangle(rect.StartingPoint, size);
        }

        private int GetSide()
        {
            return EndingPoint.X - StartingPoint.X;
        }
        public override double GetPerimeter()
        {
            return 4 * GetSide();
        }

        public override double GetArea()
        {
            return  GetSide() * GetSide();
        }
    }
}
