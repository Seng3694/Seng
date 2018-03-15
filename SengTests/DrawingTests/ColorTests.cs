using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seng.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SengTests.DrawingTests
{
    [TestClass]
    public class ColorTests
    {
        [TestMethod]
        public void PackedARGBValueTest()
        {
            var packed = 0xFFFFB200;
            var colorActual = new ColorARGB(packed);
            Assert.AreEqual(packed, colorActual.PackedValue);

            var colorExpected = new ColorARGB(0xFF, 0xFF, 0xB2, 0x00);

            Assert.AreEqual(colorExpected, colorActual);
        }

        [TestMethod]
        public void ColorConversionTest()
        {
            var argb = new ColorARGB(0, 255, 178, 0);
            var hsl = new ColorHSL(42, 1, 0.5);

            var convertedHsl = argb.ToHSL();
            var convertedArgb = hsl.ToARGB();

            Assert.AreEqual(argb, convertedArgb);
            Assert.AreEqual(hsl, convertedHsl);
            
            var backArgb = convertedHsl.ToARGB();
            var backHsl = convertedArgb.ToHSL();

            Assert.AreEqual(argb, backArgb);
            Assert.AreEqual(hsl, backHsl);
        }
    }
}
