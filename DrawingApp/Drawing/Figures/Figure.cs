using DrawingApp.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
 namespace DrawingApp
{
    public abstract class Figure : ICloneable
    {
        private bool areControlSet;

        public Point StartingPoint { get; set; } = new Point(0, 0);
        public Point EndingPoint { get; set; } = new Point(0, 0);


        public abstract void Draw(Graphics g);

        public override string ToString() {
            return $"[StartingPoint: {StartingPoint}, EndingPoint:{EndingPoint}]";
        }
        protected Figure(Figure f)
        {
            this.StartingPoint = f.StartingPoint;
            this.EndingPoint = f.EndingPoint;
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
        protected Figure() { }
        public abstract object Clone();

        protected void fixPoints()
        {
            if (StartingPoint.X > EndingPoint.X)
            {
                int tempX = StartingPoint.X;
                StartingPoint = new Point(EndingPoint.X, StartingPoint.Y);
                EndingPoint = new Point(tempX, EndingPoint.Y);
            }

            if (StartingPoint.Y > EndingPoint.Y)
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
        public void SetControls(int tabIndex)
        {
            if (!areControlSet)
            {
                List<Figure> list = new List<Figure>();

                int middleX = (StartingPoint.X + EndingPoint.X) / 2;
                int middleY = (StartingPoint.Y + EndingPoint.Y) / 2;


                var CircleTopLeft = new Drawing.Figures.Circle();
                CircleTopLeft.StartingPoint = new Point(StartingPoint.X - 4, StartingPoint.Y - 4);
                CircleTopLeft.EndingPoint = new Point(StartingPoint.X + 4, StartingPoint.Y + 4);

                var CircleTop = new Drawing.Figures.Circle();
                CircleTop.StartingPoint = new Point(middleX - 4, StartingPoint.Y - 4);
                CircleTop.EndingPoint = new Point(middleX + 4, StartingPoint.Y + 4);

                var CircleTopRight = new Drawing.Figures.Circle();
                CircleTopRight.StartingPoint = new Point(EndingPoint.X - 4, StartingPoint.Y - 4);
                CircleTopRight.EndingPoint = new Point(EndingPoint.X + 4, StartingPoint.Y + 4);

                var CircleLeft = new Drawing.Figures.Circle();
                CircleLeft.StartingPoint = new Point(StartingPoint.X - 4, middleY - 4);
                CircleLeft.EndingPoint = new Point(StartingPoint.X + 4,middleY + 4);

                var CircleBottomLeft = new Drawing.Figures.Circle();
                CircleBottomLeft.StartingPoint = new Point(StartingPoint.X - 4, EndingPoint.Y - 4);
                CircleBottomLeft.EndingPoint = new Point(StartingPoint.X + 4,EndingPoint.Y + 4);

                var CircleBottom = new Drawing.Figures.Circle();
                CircleBottom.StartingPoint = new Point(middleX - 4, EndingPoint.Y - 4);
                CircleBottom.EndingPoint = new Point(middleX + 4,EndingPoint.Y + 4);

                var CircleBottomRight = new Drawing.Figures.Circle();
                CircleBottomRight.StartingPoint = new Point(EndingPoint.X - 4, EndingPoint.Y - 4);
                CircleBottomRight.EndingPoint = new Point(EndingPoint.X + 4,EndingPoint.Y + 4);

                var CircleRight = new Drawing.Figures.Circle();
                CircleRight.StartingPoint = new Point(EndingPoint.X - 4, middleY - 4);
                CircleRight.EndingPoint = new Point(EndingPoint.X + 4, middleY + 4);

                list.Add(CircleTopLeft);
                list.Add(CircleTop);
                list.Add(CircleTopRight);
                list.Add(CircleLeft);
                list.Add(CircleBottomLeft);
                list.Add(CircleBottom);
                list.Add(CircleBottomRight);
                list.Add(CircleRight);


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
    }
}
