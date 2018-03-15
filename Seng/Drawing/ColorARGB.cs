namespace Seng.Drawing
{
    public struct ColorARGB
    {
        public byte A;
        public byte R;
        public byte G;
        public byte B;

        public uint PackedValue
        {
            get
            {
                return ((uint)A << 24) | ((uint)R << 16) | ((uint)G << 8) | B;
            }
            set
            {
                A = (byte)((value & 0xFF000000) >> 24);
                R = (byte)((value & 0x00FF0000) >> 16);
                G = (byte)((value & 0x0000FF00) >> 8);
                B = (byte)((value & 0x000000FF) >> 0);
            }
        }
        
        public ColorARGB(uint packedValue)
        {
            A = 0;
            R = 0;
            G = 0;
            B = 0;
            PackedValue = packedValue;
        }

        public ColorARGB(byte a, byte r, byte g, byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        public static bool operator ==(ColorARGB c1, ColorARGB c2)
        {
            return c1.A == c2.A && c1.R == c2.R && c1.G == c2.G && c1.B == c2.B;
        }

        public static bool operator !=(ColorARGB c1, ColorARGB c2)
        {
            return c1.A != c2.A || c1.R != c2.R || c1.G != c2.G || c1.B != c2.B;
        }

        public override bool Equals(object obj)
        {
            if (obj is ColorARGB)
                return this == (ColorARGB)obj;
            return false;
        }

        public override int GetHashCode()
        {
            return 17 + (21 * A) + (21 * R) + (21 * G) + (21 * B);
        }

        public override string ToString()
        {
            return "A:" + (A.ToString().PadLeft(3)) + "R:" + (R.ToString().PadLeft(3)) + " G:" + (G.ToString().PadLeft(3)) + " B:" + (B.ToString().PadLeft(3));
        }
    }
}
