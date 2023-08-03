using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DrawingApp.Drawing.Commands;

namespace DrawingApp.Drawing.Figures
{
    public class Line : Figure
    {
        public Line() : base()
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
            Pen pen = new Pen(this.Settings.BorderColor, this.Settings.StrokeWidth);
            g.DrawLine(pen, StartingPoint, EndingPoint);
        }

        public override double GetArea()
        {
            return base.GetArea();
        }


        public override void SeriliazeToSvg(ref XmlDocument xmlDoc)
        {
            XmlElement lineElement = xmlDoc.CreateElement("line");

            lineElement.SetAttribute("x1", StartingPoint.X.ToString());
            lineElement.SetAttribute("y1", StartingPoint.Y.ToString());
            lineElement.SetAttribute("x2", EndingPoint.X.ToString());
            lineElement.SetAttribute("y2", EndingPoint.Y.ToString());
            Settings.SerializeToAttributes(ref lineElement);

            xmlDoc.DocumentElement.AppendChild(lineElement);
        }

        public Line(XmlNode childNode)
        {
            StartingPoint.X = int.Parse(childNode.Attributes["x1"].Value);
            StartingPoint.Y = int.Parse(childNode.Attributes["y1"].Value);
            EndingPoint.X = int.Parse(childNode.Attributes["x2"].Value);
            EndingPoint.Y = int.Parse(childNode.Attributes["y2"].Value);
            Settings = new FigureSettings(childNode);
        }

        public override bool isPointInside(Point p)
        {
            int x = StartingPoint.X;
            int y = StartingPoint.Y;
            int x1 = EndingPoint.X;
            int y1 = EndingPoint.Y;

            if (x > x1)
            {
                int tempX = x;
                x = x1;
                x1 = tempX;
            }
            if (y > y1)
            {
                int tempY = y;
                y = y1;
                y1 = tempY;
            }

            return (p.X > x)
                && (p.Y > y)
                && (p.X < x1)
                && (p.Y < y1);
        }
    }
}
