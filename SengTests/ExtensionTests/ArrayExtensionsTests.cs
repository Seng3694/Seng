﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seng.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SengTests.ExtensionTests
{
    [TestClass]
    public class ArrayExtensionsTests
    {
        [TestMethod]
        public void QuickSortTest()
        {
            var arr = new[] { 5, 2, 9, 1, 12, 1337, 4, 98, 42, 3, -23 };
            arr.QuickSort();
            var expected = new[] { -23, 1, 2, 3, 4, 5, 9, 12, 42, 98, 1337 };

            for(int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(arr[i], expected[i]);
            }
        }
    }
}
