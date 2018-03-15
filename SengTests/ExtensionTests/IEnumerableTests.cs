using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seng.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SengTests.ExtensionTests
{
    [TestClass]
    public class IEnumerableTests
    {
        [TestMethod]
        public void AppendTest()
        {
            var arr = new[] { 1, 2, 3, 4 };

            Assert.IsTrue(arr.Append(5).Last() == 5);
            Assert.IsTrue(arr.Append(5).Count() == 5);
        }

        [TestMethod]
        public void PrependTest()
        {
            var arr = new[] { 1, 2, 3, 4 };

            Assert.IsTrue(arr.Prepend(5).First() == 5);
            Assert.IsTrue(arr.Prepend(5).Count() == 5);
        }
    }
}
