using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Drawing.Commands
{
    public class Move : Command
    {
        private Point initialPoint;
        public Move(Point initialPoint)
        {
            this.initialPoint = initialPoint;
        }

        public void Execute(Point p)
        {
            int deltaX = p.X - initialPoint.X;
            int deltaY = p.Y - initialPoint.Y;
            GlobalSettings.Instance.SelectedFigure.StartingPoint.X += deltaX;
            GlobalSettings.Instance.SelectedFigure.StartingPoint.Y += deltaY;
            GlobalSettings.Instance.SelectedFigure.EndingPoint.X += deltaX;
            GlobalSettings.Instance.SelectedFigure.EndingPoint.Y += deltaY;
        }
    }
}
