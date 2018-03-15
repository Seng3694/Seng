using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seng.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SengTests.CoreTests
{
    [TestClass]
    public class FlagHelperTests
    {
        [TestMethod]
        public void FlagHelperTest()
        {
            var storageField = typeof(BoolStorage).GetField("_storage", BindingFlags.NonPublic | BindingFlags.Instance);
            var helper = new BoolStorage();

            for (int i = 0; i < 64; i++)
                helper.SetBool(i, true);

            for (int i = 0; i < 64; i++)
                Assert.IsTrue(helper.GetBool(i));

            Assert.IsTrue(((uint[])storageField.GetValue(helper)).Length == 2);

            Assert.IsFalse(helper.GetBool(65));
            helper.SetBool(65, true);
            Assert.IsTrue(helper.GetBool(65));

            //helper backed by an uint array. Each uint has 32 bits to set. If the 65th bit is set, the array should resize to 3
            Assert.IsTrue(((uint[])storageField.GetValue(helper)).Length == 3);
        }
    }
}
