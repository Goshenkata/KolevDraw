using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Drawing.Figures
{
    public class Rectangle : Figure
    {

        public override object Clone()
        {
            return new Rectangle(this);
        }

        public override void Draw(Graphics g)
        {
            base.fixPoints();
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Blue);
            g.FillRectangle(brush, this);
            g.DrawRectangle(pen, this);
        }


        public override double GetArea()
        {

            return GetWidth() * GetHeight();
        }
        public override double GetPerimeter()
        {

            return 2* GetWidth()  + 2 * GetHeight();
        }

        private int GetWidth()
        {
            return EndingPoint.X - StartingPoint.X;
        }

        private int GetHeight()
        {
            return EndingPoint.Y - StartingPoint.Y;
        }


        protected Rectangle(Figure f) : base(f) {}
        public Rectangle(Point upperLeftPoint, int width, int height)
        {
            StartingPoint = upperLeftPoint;
            EndingPoint = new Point(upperLeftPoint.X + width, upperLeftPoint.Y + height);
        }
        public Rectangle() { }
    }
}
