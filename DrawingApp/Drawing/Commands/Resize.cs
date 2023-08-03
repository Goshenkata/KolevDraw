using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Drawing.Commands
{
    public class TopLeftStretch : Command
    {
        public void Execute(Point p)
        {
            GlobalSettings.Instance.SelectedFigure.StartingPoint = new Point(p.X, p.Y);
        }
    }
    public class LeftStretch: Command
    {
        public void Execute(Point p)
        {
            GlobalSettings.Instance.SelectedFigure.StartingPoint.X = p.X;
        }
    }
    public class BottomStretch: Command
    {
        public void Execute(Point p)
        {
            GlobalSettings.Instance.SelectedFigure.EndingPoint.Y = p.Y;
        }
    }
    public class BottomRightStretch: Command
    {
        public void Execute(Point p)
        {
            GlobalSettings.Instance.SelectedFigure.EndingPoint = new Point(p.X, p.Y);
        }
    }

    public class RightStretch: Command
    {
        public void Execute(Point p)
        {
            GlobalSettings.Instance.SelectedFigure.EndingPoint.X = p.X;
        }
    }

    public class BottomLeftStretch: Command
    {
        public void Execute(Point p)
        {
            GlobalSettings.Instance.SelectedFigure.StartingPoint.X = p.X;
            GlobalSettings.Instance.SelectedFigure.EndingPoint.Y = p.Y;
        }
    }
    public class TopRightStretch: Command
    {
        public void Execute(Point p)
        {
            GlobalSettings.Instance.SelectedFigure.StartingPoint.Y = p.Y;
            GlobalSettings.Instance.SelectedFigure.EndingPoint.X = p.X;
        }
    }
    public class TopStretch: Command
    {
        public void Execute(Point p)
        {
            GlobalSettings.Instance.SelectedFigure.StartingPoint.Y = p.Y;
        }
    }
    public class TopLeftFixedStretch : Command
    {
        public void Execute(Point p)
        {
            int delta = GlobalSettings.Instance.SelectedFigure.StartingPoint.X - p.X;
            GlobalSettings.Instance.SelectedFigure.StartingPoint.X =+ delta;
            GlobalSettings.Instance.SelectedFigure.StartingPoint.Y =+ delta;
        }
    }
}
