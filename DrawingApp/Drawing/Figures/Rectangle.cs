using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
            Pen pen = new Pen(this.Settings.BorderColor, this.Settings.StrokeWidth);
            Brush brush = new SolidBrush(this.Settings.FillColor);
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
        public Rectangle(Point upperLeftPoint, int width, int height): base()
        {
            StartingPoint = upperLeftPoint;
            EndingPoint = new Point(upperLeftPoint.X + width, upperLeftPoint.Y + height);
        }
        public Rectangle():base() { }

        public Rectangle(XmlNode childNode)
        {
            string x = childNode.Attributes["x"].Value;
            string y = childNode.Attributes["y"].Value;
            int width = int.Parse(childNode.Attributes["width"].Value);
            int height = int.Parse(childNode.Attributes["height"].Value);
            if (x != null)
            {
                StartingPoint.X = int.Parse(x);
            }
            if (y != null)
            {
                StartingPoint.Y = int.Parse(y);
            }
            EndingPoint.X = StartingPoint.X + width;
            EndingPoint.Y = StartingPoint.Y + height;
            Settings = new FigureSettings(childNode);
        }

        public override void SeriliazeToSvg(ref XmlDocument xmlDoc)
        {
            
            XmlElement rectElement = xmlDoc.CreateElement("rect");

            rectElement.SetAttribute("x", StartingPoint.X.ToString());
            rectElement.SetAttribute("y", StartingPoint.Y.ToString());
            rectElement.SetAttribute("width", GetWidth().ToString());
            rectElement.SetAttribute("height", GetHeight().ToString());
            Settings.SerializeToAttributes(ref rectElement);

            xmlDoc.DocumentElement.AppendChild(rectElement);
        }
    }
}
