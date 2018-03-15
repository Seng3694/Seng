namespace Seng.Extensions
{
    public static class NumericExtensions
    {
        #region XorSwap overloads

        /// <summary>
        /// Swaps the two values without a temp variable.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void XorSwap(ref sbyte a, ref sbyte b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }

        /// <summary>
        /// Swaps the two values without a temp variable.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void XorSwap(ref byte a, ref byte b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }

        /// <summary>
        /// Swaps the two values without a temp variable.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void XorSwap(ref int a, ref int b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }

        /// <summary>
        /// Swaps the two values without a temp variable.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void XorSwap(ref uint a, ref uint b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }

        /// <summary>
        /// Swaps the two values without a temp variable.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void XorSwap(ref short a, ref short b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }

        /// <summary>
        /// Swaps the two values without a temp variable.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void XorSwap(ref ushort a, ref ushort b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }
        
        /// <summary>
        /// Swaps the two values without a temp variable.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void XorSwap(ref long a, ref long b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }

        /// <summary>
        /// Swaps the two values without a temp variable.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void XorSwap(ref ulong a, ref ulong b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }
        
        #endregion
    }
}
