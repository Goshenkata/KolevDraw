using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Drawing
{
    class Canvas
    {
        public List<Figure> Figures { get; set; }
        public List<Figure> SelectionFigures { get; set; }
        public Canvas()
        {
            this.Figures = new List<Figure>();
            this.SelectionFigures = new List<Figure>(); 
        }
    }
}
