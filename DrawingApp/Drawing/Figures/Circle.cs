using DrawingApp.Drawing.Commands;
using DrawingApp.Drawing.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Windows.Forms.AxHost;

namespace DrawingApp.Drawing.Figures

{
    public class Circle : Figure
    {
        public Circle():base() { } 
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
            Pen pen = new Pen(this.Settings.BorderColor,this.Settings.StrokeWidth);
            Brush brush = new SolidBrush(this.Settings.FillColor);
            g.FillEllipse(brush, this);
            g.DrawEllipse(pen, this);
        }

        public override void SetControls(int tabIndex)
        {
            if (!areControlSet)
            {
                List<Figure> list = new List<Figure>();

                int size = 6;
                int middleX = (StartingPoint.X + EndingPoint.X) / 2;
                int middleY = (StartingPoint.Y + EndingPoint.Y) / 2;


                var circleTopLeft = new Drawing.Figures.Circle();
                circleTopLeft.StartingPoint = new Point(StartingPoint.X - size, StartingPoint.Y - 4);
                circleTopLeft.EndingPoint = new Point(StartingPoint.X + size, StartingPoint.Y + 4);
                circleTopLeft.Command = new TopLeftStretch();

                var circleTopRight = new Drawing.Figures.Circle();
                circleTopRight.StartingPoint = new Point(EndingPoint.X - size, StartingPoint.Y - 4);
                circleTopRight.EndingPoint = new Point(EndingPoint.X + size, StartingPoint.Y + 4);
                circleTopRight.Command = new TopRightStretch();

                var circleBottomLeft = new Drawing.Figures.Circle();
                circleBottomLeft.StartingPoint = new Point(StartingPoint.X - size, EndingPoint.Y - 4);
                circleBottomLeft.EndingPoint = new Point(StartingPoint.X + size, EndingPoint.Y + 4);
                circleBottomLeft.Command = new BottomLeftStretch();

                var circleBottomRight = new Drawing.Figures.Circle();
                circleBottomRight.StartingPoint = new Point(EndingPoint.X - size, EndingPoint.Y - 4);
                circleBottomRight.EndingPoint = new Point(EndingPoint.X + size, EndingPoint.Y + 4);
                circleBottomRight.Command = new BottomRightStretch();


                list.Add(circleTopLeft);
                list.Add(circleTopRight);
                list.Add(circleBottomLeft);
                list.Add(circleBottomRight);

                foreach(var item in list)
                {
                    item.Settings.FillColor = System.Drawing.Color.White;
                    item.Settings.BorderColor = System.Drawing.Color.Gray;
                }

                Project.Canvases[tabIndex].SelectionFigures.AddRange(list);
                areControlSet = true;
            }
        }

        public override void SeriliazeToSvg(ref XmlDocument xmlDoc)
        {
            XmlElement circleElement = xmlDoc.CreateElement("circle");

            int middleX = (StartingPoint.X + EndingPoint.X) / 2;
            int middleY = (StartingPoint.Y + EndingPoint.Y) / 2;
            circleElement.SetAttribute("cx", middleX.ToString());
            circleElement.SetAttribute("cy", middleY.ToString());
            circleElement.SetAttribute("r", GetRadius().ToString());
            Settings.SerializeToAttributes(ref circleElement);

            xmlDoc.DocumentElement.AppendChild(circleElement);
        }

        public Circle(XmlNode childNode)
        {   
            int cx = int.Parse(childNode.Attributes["cx"].Value);
            int cy = int.Parse(childNode.Attributes["cy"].Value);
            int r = int.Parse(childNode.Attributes["r"].Value);
            StartingPoint.X = cx - r;
            StartingPoint.Y = cy - r;
            EndingPoint.X = cx + r;
            EndingPoint.Y = cx + r;
            Settings = new FigureSettings(childNode);
        }
    }
}
