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
            GlobalSettings.Instance.SelectedFigure.StartingPoint = p;
        }
    }
}
