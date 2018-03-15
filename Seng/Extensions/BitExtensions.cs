using System;
using System.Text;

namespace Seng.Extensions
{
    public static class BitExtensions
    {
        public static int ClearBit(this int number, int bit)
        {
            return number & ~(1 << bit);
        }

        public static int SetBit(this int number, int bit)
        {
            return number | 1 << bit;
        }

        public static int ToggleBit(this int number, int bit)
        {
            return number ^ 1 << bit;
        }

        public static bool CheckBit(this int number, int bit)
        {
            return (number & (1 << bit)) == (1 << bit);
        }
        
        public static uint ClearBit(this uint number, int bit)
        {
            return number & ~((uint)1 << bit);
        }

        public static uint SetBit(this uint number, int bit)
        {
            return number | (uint)1 << bit;
        }

        public static uint ToggleBit(this uint number, int bit)
        {
            return number ^ (uint)1 << bit;
        }

        public static bool CheckBit(this uint number, int bit)
        {
            return (number & ((uint)1 << bit)) == ((uint)1 << bit);
        }
        
        public static ulong ClearBit(this ulong number, int bit)
        {
            return number & ~((ulong)1 << bit);
        }

        public static ulong SetBit(this ulong number, int bit)
        {
            return number | (ulong)1 << bit;
        }

        public static ulong ToggleBit(this ulong number, int bit)
        {
            return number ^ (ulong)1 << bit;
        }

        public static bool CheckBit(this ulong number, int bit)
        {
            return (number & ((ulong)1 << bit)) == ((ulong)1 << bit);
        }

        public static string ToBinaryString(this int number, bool spacing = false)
        {
            var str = Convert.ToString(number, 2);
            var length = 8;
            while (length < str.Length)
                length += 8;
            str = str.PadLeft(length, '0');

            if (spacing)
            {
                var builder = new StringBuilder();

                for (int i = 0; i < str.Length; i += 4)
                {
                    builder.Append(str.Substring(i, 4));
                    if (i + 4 < str.Length - 1)
                        builder.Append(' ');
                }

                str = builder.ToString();
            }

            return str;
        }
    }
}
