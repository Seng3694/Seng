using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seng.Extensions;
using System;

namespace SengTests.ExtensionTests
{
    [TestClass]
    public class BitExtensionsTests
    {
        [TestMethod]
        public void ClearBit()
        {
            var bitString = "1101001";
            var number = Convert.ToInt32(bitString, 2);
            var clearedAt3 = number.ClearBit(3);
            var clearedAt3BitString = Convert.ToString(clearedAt3, 2);
            var expected = "1100001";

            Assert.AreEqual(expected, clearedAt3BitString);
        }

        [TestMethod]
        public void SetBit()
        {
            var bitString = "1101001";
            var number = Convert.ToInt32(bitString, 2);
            var setAt2 = number.SetBit(2);
            var setAt2BitString = Convert.ToString(setAt2, 2);
            var expected = "1101101";

            Assert.AreEqual(expected, setAt2BitString);
        }

        [TestMethod]
        public void ToggleBit()
        {
            var bitString = "1101001";
            var number = Convert.ToInt32(bitString, 2);
            var toggleFirst3 = number.ToggleBit(0).ToggleBit(1).ToggleBit(2);
            var toggleFirst3BitString = Convert.ToString(toggleFirst3, 2);
            var expected = "1101110";

            Assert.AreEqual(expected, toggleFirst3BitString);
        }

        [TestMethod]
        public void CheckBit()
        {
            var bitString = "1101001";
            var number = Convert.ToInt32(bitString, 2);
            Assert.IsTrue(number.CheckBit(0));
            Assert.IsFalse(number.CheckBit(1));
            Assert.IsFalse(number.CheckBit(2));
            Assert.IsTrue(number.CheckBit(3));
            Assert.IsFalse(number.CheckBit(4));
            Assert.IsTrue(number.CheckBit(5));
            Assert.IsTrue(number.CheckBit(6));
        }
    }
}
