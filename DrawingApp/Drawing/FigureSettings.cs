using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DrawingApp.Drawing
{
    public class FigureSettings: ICloneable
    {
        public Color FillColor { get; set; } = System.Drawing.Color.Blue;
        public Color BorderColor { get; set; } = System.Drawing.Color.Blue;
        public int StrokeWidth { get; set; } = 2;

        public FigureSettings() { }

        public FigureSettings(XmlNode childNode)
        {
            string stroke = childNode.Attributes["stroke"].Value;
            string fill = childNode.Attributes["fill"].Value;
            StrokeWidth = int.Parse(childNode.Attributes["stroke-width"].Value);
            if (stroke != null)
            {
                BorderColor = new Color(stroke);
            }
            if (fill != null) {
                FillColor = new Color(fill);
            }
        }

        public object Clone()
        {
            FigureSettings fs = new FigureSettings();
            fs.FillColor = (Color)FillColor.Clone();
            fs.BorderColor = (Color)BorderColor.Clone();
            fs.StrokeWidth = StrokeWidth;
            return fs;
        }

        public void SerializeToAttributes(ref XmlElement element)
        {
            element.SetAttribute("stroke", $"rgb({BorderColor.R},{BorderColor.G},{BorderColor.B})");
            element.SetAttribute("fill", $"rgb({FillColor.R},{FillColor.G},{FillColor.B})");
            element.SetAttribute("stroke-width", StrokeWidth.ToString());
        }
    }
}
