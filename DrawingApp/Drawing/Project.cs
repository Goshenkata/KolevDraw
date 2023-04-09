using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Drawing
{
    static class Project
    {
        private static List<Canvas> canvases;

        public static List<Canvas> Canvases
        {
            get
            {
                if (canvases == null)
                {
                    canvases = new List<Canvas>();
                }
                return canvases;
            } 
        }
    }
}
