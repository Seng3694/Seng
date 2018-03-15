using System;

namespace Seng.Drawing
{
    public struct ColorHSL
    {
        public double H;
        public double S;
        public double L;

        public ColorHSL(double h, double s, double l)
        {
            H = h;
            S = s;
            L = l;
        }

        public static bool operator ==(ColorHSL c1, ColorHSL c2)
        {
            return Math.Round(c1.H) == Math.Round(c2.H)
                && Math.Round(c1.S, 2) == Math.Round(c2.S, 2)
                && Math.Round(c1.L, 2) == Math.Round(c2.L, 2);
        }

        public static bool operator !=(ColorHSL c1, ColorHSL c2)
        {
            return Math.Round(c1.H) != Math.Round(c2.H)
                || Math.Round(c1.S, 2) != Math.Round(c2.S, 2)
                || Math.Round(c1.L, 2) != Math.Round(c2.L, 2);
        }

        public override bool Equals(object obj)
        {
            if (obj is ColorHSL)
                return this == (ColorHSL)obj;
            return false;
        }

        public override int GetHashCode()
        {
            return 17 + (21 * Math.Round(H).GetHashCode()) + (21 * Math.Round(S).GetHashCode()) + (21 * Math.Round(L).GetHashCode());
        }

        public override string ToString()
        {
            return "H:" + (H.ToString("0").PadLeft(3)) + " S:" + ((S * 100).ToString("0.00").PadLeft(6)) + " L:" + ((L * 100).ToString("0.00").PadLeft(6));
        }
    }
}
