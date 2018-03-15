using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Core
{
    public class Dice
    {
        private Random _random;

        public int Pips { get; }

        public Dice(int pips, Random random = null)
        {
            _random = random ?? new Random();
            Pips = pips;
        }

        public int Roll()
        {
            return _random.Next(1, Pips + 1);
        }

        public static int Roll(int pips, Random random)
        {
            return random.Next(1, Math.Abs(pips) + 1);
        }
    }
}
