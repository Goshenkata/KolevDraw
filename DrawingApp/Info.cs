using DrawingApp.Drawing.Figures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingApp
{
    public partial class Info : Form
    {
        public Info(List<Figure> list, String name)
        {
            InitializeComponent();
            this.name.Text = name;
            if (list.Count > 0) {
                this.numberOfElements.Text = list.Count.ToString();
                this.totalArea.Text = Math.Round(list.Sum(s => s.GetArea()),2).ToString();
                this.totalParameter.Text = Math.Round(list.Sum(s => s.GetPerimeter()),2).ToString();
                this.circles.Text = GetNum(list,typeof(Circle));
                this.rectangles.Text = GetNum(list, typeof(DrawingApp.Drawing.Figures.Rectangle));
                this.lines.Text = GetNum(list, typeof(Line));
                this.ellipses.Text = GetNum(list, typeof(Ellipse));
                this.squares.Text = GetNum(list, typeof(Square));
            }
        }
        private string GetNum(List<Figure> list, Type type)
        {
            return list.Where(s => s.GetType() == type).Count().ToString();
        }
    }
}
