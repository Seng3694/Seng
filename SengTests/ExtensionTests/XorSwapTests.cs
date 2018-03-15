using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seng.Extensions;

namespace SengTests.ExtensionTests
{
    [TestClass]
    public class XorSwapTests
    {
        [TestMethod]
        public void XorSwapTest()
        {
            var v1 = 42;
            var v2 = 1337;

            NumericExtensions.XorSwap(ref v1, ref v2);

            Assert.AreEqual(1337, v1);
            Assert.AreEqual(42, v2);
        }
    }
}
