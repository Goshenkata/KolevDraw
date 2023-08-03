using DrawingApp.Drawing.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Drawing
{
    public sealed class GlobalSettings
    {
        private static readonly GlobalSettings instance = new GlobalSettings();

        private GlobalSettings() { }

        public static GlobalSettings Instance
        {
            get { return instance; }
        }

        public Figure SelectedFigure { get; set; } = new Rectangle();
        public Figure ManipulationFigure { get; set; }
        public FigureSettings Settings { get; set; } = new FigureSettings();

    }
}
