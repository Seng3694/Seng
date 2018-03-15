using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Drawing
{
    public static class ColorConverter
    {
        private const double ONE_THIRD = 1d / 3d;
        private const double TWO_THIRD = 2d / 3d;

        public static ColorHSL ToHSL(this ColorARGB rgb)
        {
            var hsl = new ColorHSL();

            var r = (double)rgb.R / (double)byte.MaxValue;
            var g = (double)rgb.G / (double)byte.MaxValue;
            var b = (double)rgb.B / (double)byte.MaxValue;

            var max = new[] { r, g, b }.Max();
            var min = new[] { r, g, b }.Min();

            hsl.L = (max + min) / 2.0d;

            //shade of gray
            if (min == max)
            {
                return hsl;
            }

            if (hsl.L <= 0.5d) hsl.S = (double)(max - min) / (double)(max + min);
            if (hsl.L > 0.5d) hsl.S = (double)(max - min) / (double)(2d - max - min);

            if (max == r) hsl.H = (double)(g - b) / (double)(max - min);
            if (max == g) hsl.H = 2d + (double)(b - r) / (double)(max - min);
            if (max == b) hsl.H = 4d + (double)(r - g) / (double)(max - min);

            hsl.H *= 60;

            if (hsl.H < 0) hsl.H += 360d;

            return hsl;
        }

        public static ColorARGB ToARGB(this ColorHSL hsl)
        {
            var rgb = new ColorARGB();

            //shade of gray
            if (hsl.S == 0)
            {
                rgb.R = (byte)(hsl.L * (double)byte.MaxValue);
                rgb.G = (byte)(hsl.L * (double)byte.MaxValue);
                rgb.B = (byte)(hsl.L * (double)byte.MaxValue);
                return rgb;
            }

            var temp1 = hsl.L < 0.5d
                ? hsl.L * (1d + hsl.S)
                : hsl.L + hsl.S - hsl.L * hsl.S;

            var temp2 = 2d * hsl.L - temp1;

            var tempHue = hsl.H / 360d;

            var tempR = tempHue + ONE_THIRD;
            var tempG = tempHue;
            var tempB = tempHue - ONE_THIRD;

            tempR = tempR < 0 ? tempR + 1 : tempR > 1 ? tempR - 1 : tempR;
            tempG = tempG < 0 ? tempG + 1 : tempG > 1 ? tempG - 1 : tempG;
            tempB = tempB < 0 ? tempB + 1 : tempB > 1 ? tempB - 1 : tempB;

            rgb.R = ColorChannelCalculation(temp1, temp2, tempR);
            rgb.G = ColorChannelCalculation(temp1, temp2, tempG);
            rgb.B = ColorChannelCalculation(temp1, temp2, tempB);

            return rgb;
        }

        private static byte ColorChannelCalculation(double temp1, double temp2, double tempColor)
        {
            var result = 0d;
            if (6 * tempColor < 1) result = temp2 + (temp1 - temp2) * 6 * tempColor;
            else if (2 * tempColor < 1) result = temp1;
            else if (3 * tempColor < 2) result = (temp2 + (temp1 - temp2) * (TWO_THIRD - tempColor) * 6);
            else result = temp2;
            return (byte)Math.Round(((double)result * (double)byte.MaxValue));
        }
    }
}
