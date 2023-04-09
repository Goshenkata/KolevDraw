using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Drawing.Figures
{
    public class Text : Figure
    {
        private Text(Figure f) : base(f)
        {
        }

        public override object Clone()
        {
            return new Text(this);
        }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
