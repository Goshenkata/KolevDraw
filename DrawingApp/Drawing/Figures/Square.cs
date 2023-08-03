using DrawingApp.Drawing.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DrawingApp.Drawing.Figures
{
    public class Square : Figure
    {
        public Square():base() {
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
            Pen pen = new Pen(this.Settings.BorderColor, this.Settings.StrokeWidth);
            Brush brush = new SolidBrush(this.Settings.FillColor);
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
            XmlElement rectElement = xmlDoc.CreateElement("rect");

            rectElement.SetAttribute("x", StartingPoint.X.ToString());
            rectElement.SetAttribute("y", StartingPoint.Y.ToString());
            rectElement.SetAttribute("width", GetSide().ToString());
            rectElement.SetAttribute("height", GetSide().ToString());
            Settings.SerializeToAttributes(ref rectElement);

            xmlDoc.DocumentElement.AppendChild(rectElement);
        }
        public Square(XmlNode childNode)
        {
            string x = childNode.Attributes["x"].Value;
            string y = childNode.Attributes["y"].Value;
            int side = int.Parse(childNode.Attributes["width"].Value);
            if (x != null)
            {
                StartingPoint.X = int.Parse(x);
            }
            if (y != null)
            {
                StartingPoint.Y = int.Parse(y);
            }
            EndingPoint.X = StartingPoint.X + side;
            EndingPoint.Y = StartingPoint.Y + side;
            Settings = new FigureSettings(childNode);
        }
    }
}
