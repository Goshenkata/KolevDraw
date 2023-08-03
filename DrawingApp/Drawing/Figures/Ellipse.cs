using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DrawingApp.Drawing.Figures
{
    public class Ellipse : Figure
    {

        private Ellipse(Figure f) : base(f)
        {
        }

        public Ellipse():base()
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
            base.fixPoints();
            Pen pen = new Pen(this.Settings.BorderColor,this.Settings.StrokeWidth);
            Brush brush = new SolidBrush(this.Settings.FillColor);
            g.FillEllipse(brush, this);
            g.DrawEllipse(pen, this);
        }

        public override void SeriliazeToSvg(ref XmlDocument xmlDoc)
        {

            XmlElement ellipseElement = xmlDoc.CreateElement("ellipse");

            int middleX = (StartingPoint.X + EndingPoint.X) / 2;
            int middleY = (StartingPoint.Y + EndingPoint.Y) / 2;
            ellipseElement.SetAttribute("cx", middleX.ToString());
            ellipseElement.SetAttribute("cy", middleY.ToString());
            ellipseElement.SetAttribute("rx", GetXRadius().ToString());
            ellipseElement.SetAttribute("ry", GetYRadius().ToString());
            Settings.SerializeToAttributes(ref ellipseElement);

            xmlDoc.DocumentElement.AppendChild(ellipseElement);
        }

        public Ellipse(XmlNode childNode)
        {   
            int cx = int.Parse(childNode.Attributes["cx"].Value);
            int cy = int.Parse(childNode.Attributes["cy"].Value);
            int rx = int.Parse(childNode.Attributes["rx"].Value);
            int ry = int.Parse(childNode.Attributes["ry"].Value);
            StartingPoint.X = cx - rx;
            StartingPoint.Y = cy - ry;
            EndingPoint.X = cx + rx;
            EndingPoint.Y = cy + ry;
            Settings = new FigureSettings(childNode);
        }
    }
}
