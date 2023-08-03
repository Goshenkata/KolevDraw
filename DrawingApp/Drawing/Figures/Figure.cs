using DrawingApp.Drawing;
using DrawingApp.Drawing.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using DrawingApp.Drawing;
using System.Xml;

namespace DrawingApp
{
    public abstract class Figure : ICloneable
    {
        protected bool areControlSet;

        public Point StartingPoint { get; set; } = new Point(0, 0);
        public Point EndingPoint { get; set; } = new Point(0, 0);
        public Command Command { get; set; }
        public FigureSettings Settings { get; set; }


        public abstract void Draw(Graphics g);

        public override string ToString()
        {
            return $"[StartingPoint: {StartingPoint}, EndingPoint:{EndingPoint}]";
        }
        protected Figure(Figure f)
        {
            this.StartingPoint.X = f.StartingPoint.X;
            this.StartingPoint.Y = f.StartingPoint.Y;
            this.EndingPoint.X = f.EndingPoint.X;
            this.EndingPoint.Y = f.EndingPoint.Y;
            this.Settings = (FigureSettings)f.Settings.Clone(); 
        }

        public virtual double GetPerimeter()
        {
            return 0;
        }

        public virtual double GetArea()
        {
            return 0;
        }

        public static implicit operator System.Drawing.Rectangle(Figure fig)
        {
            Size size = new Size(fig.EndingPoint.X - fig.StartingPoint.X, fig.EndingPoint.Y - fig.StartingPoint.Y);
            return new System.Drawing.Rectangle(fig.StartingPoint, size);
        }
        protected Figure()
        {
            this.Settings = new FigureSettings();
            fixPoints();
        }

        public abstract object Clone();

        public void fixPoints()
        {
            bool xIsWrong = StartingPoint.X > EndingPoint.X;
            bool yIsWrong = StartingPoint.Y > EndingPoint.Y;
            if (xIsWrong)
            {
                int tempX = StartingPoint.X;
                StartingPoint = new Point(EndingPoint.X, StartingPoint.Y);
                EndingPoint = new Point(tempX, EndingPoint.Y);
            }

            if (yIsWrong)
            {
                int tempY = StartingPoint.Y;
                StartingPoint = new Point(StartingPoint.X, EndingPoint.Y);
                EndingPoint = new Point(EndingPoint.X, tempY);
            }
        }

        public virtual bool isPointInside(Point p)
        {
            return (p.X > StartingPoint.X)
                && (p.Y > StartingPoint.Y)
                && (p.X < EndingPoint.X)
                && (p.Y < EndingPoint.Y);
        }
        public virtual void SetControls(int tabIndex)
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

                var circleTop = new Drawing.Figures.Circle();
                circleTop.StartingPoint = new Point(middleX - size, StartingPoint.Y - 4);
                circleTop.EndingPoint = new Point(middleX + size, StartingPoint.Y + 4);
                circleTop.Command = new TopStretch();                

                var circleTopRight = new Drawing.Figures.Circle();
                circleTopRight.StartingPoint = new Point(EndingPoint.X - size, StartingPoint.Y - 4);
                circleTopRight.EndingPoint = new Point(EndingPoint.X + size, StartingPoint.Y + 4);
                circleTopRight.Command = new TopRightStretch();

                var circleLeft = new Drawing.Figures.Circle();
                circleLeft.StartingPoint = new Point(StartingPoint.X - size, middleY - 4);
                circleLeft.EndingPoint = new Point(StartingPoint.X + size, middleY + 4);
                circleLeft.Command = new LeftStretch();

                var circleBottomLeft = new Drawing.Figures.Circle();
                circleBottomLeft.StartingPoint = new Point(StartingPoint.X - size, EndingPoint.Y - 4);
                circleBottomLeft.EndingPoint = new Point(StartingPoint.X + size, EndingPoint.Y + 4);
                circleBottomLeft.Command = new BottomLeftStretch();

                var circleBottom = new Drawing.Figures.Circle();
                circleBottom.StartingPoint = new Point(middleX - size, EndingPoint.Y - 4);
                circleBottom.EndingPoint = new Point(middleX + size, EndingPoint.Y + 4);
                circleBottom.Command = new BottomStretch();

                var circleBottomRight = new Drawing.Figures.Circle();
                circleBottomRight.StartingPoint = new Point(EndingPoint.X - size, EndingPoint.Y - 4);
                circleBottomRight.EndingPoint = new Point(EndingPoint.X + size, EndingPoint.Y + 4);
                circleBottomRight.Command = new BottomRightStretch();

                var circleRight = new Drawing.Figures.Circle();
                circleRight.StartingPoint = new Point(EndingPoint.X - size, middleY - 4);
                circleRight.EndingPoint = new Point(EndingPoint.X + size, middleY + 4);
                circleRight.Command = new RightStretch();

                list.Add(circleTopLeft);
                list.Add(circleTop);
                list.Add(circleTopRight);
                list.Add(circleLeft);
                list.Add(circleBottomLeft);
                list.Add(circleBottom);
                list.Add(circleBottomRight);
                list.Add(circleRight);

                foreach(var item in list)
                {
                    item.Settings.FillColor = System.Drawing.Color.White;
                    item.Settings.BorderColor = System.Drawing.Color.Gray;
                }


                Project.Canvases[tabIndex].SelectionFigures.AddRange(list);
                areControlSet = true;
            }
        }

        public void UnsetControls(int tabIndex)
        {
            if (areControlSet)
            {
                Project.Canvases[tabIndex].SelectionFigures = new List<Figure>();
                areControlSet = false;
            }
        }

        public abstract void SeriliazeToSvg(ref XmlDocument xmlDoc);
    }
}
