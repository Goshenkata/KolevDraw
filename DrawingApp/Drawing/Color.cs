using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DrawingApp.Drawing
{
    public class Color: ICloneable
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public Color(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Color(string rgbData)
        {
            string pattern = @"rgb\((\d{1,3}),\s*(\d{1,3}),\s*(\d{1,3})\)";

            Match match = Regex.Match(rgbData, pattern);

            R = int.Parse(match.Groups[1].Value);
            G = int.Parse(match.Groups[2].Value);
            B = int.Parse(match.Groups[3].Value);
        }

        public static implicit operator System.Drawing.Color(Color color)
        {
            return System.Drawing.Color.FromArgb(
                color.R,
                color.G,
                color.B
                );
        }

        public static implicit operator Color(System.Drawing.Color color)
        {
            return new Color(color.R, color.G, color.B);
        }

        public object Clone()
        {
            return new Color(R, G, B);
        }

        public override string ToString()
        {
            return $"R:{R}, G:{G}, B:{B}";
        }
    }
}
