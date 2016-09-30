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
    public class SortAlgorithmTests
    {
        [TestMethod()]
        public void BubbleSortTest()
        {
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var actual = new int[] { 8, 5, 3, 2, 4, 1, 6, 7 };
            Console.WriteLine("Before sort: " + string.Join<int>(",", actual));
            SortAlgorithm.BubbleSort<int>(actual, (a, b) => a < b);
            Console.WriteLine("After sort: " + string.Join<int>(",", actual));
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}