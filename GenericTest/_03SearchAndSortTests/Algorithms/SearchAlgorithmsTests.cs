using Microsoft.VisualStudio.TestTools.UnitTesting;
using _03SearchAndSort.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03SearchAndSort.Algorithms.Tests
{
    [TestClass()]
    public class SearchAlgorithmsTests
    {
        [TestMethod()]
        public void AverageTest()
        {
            var expected = 50;
            var actual = SearchAlgorithms.Average(0, 100);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RegionGrowTest()
        {
            var array = new int[] { 1, 2, 3, 3, 3, 4, 5 };
            var expected = new int[] { 3, 3, 3 };
            var actual = SearchAlgorithms.RegionGrow<int>(array, 3, (a, b) => a == b);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BinarySearchTest()
        {
            var array = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var expected = 1;
            var actual = SearchAlgorithms.BinarySearch<int>(array, 2, (a, b) => a-b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BinarySearchTest2()
        {
            var array = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var expected = -1;
            var actual = SearchAlgorithms.BinarySearch<int>(array, 9, (a, b) => a-b);
            Assert.AreEqual(expected, actual);
        }
    }
}