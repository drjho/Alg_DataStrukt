using Microsoft.VisualStudio.TestTools.UnitTesting;
using _03SearchAndSort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03SearchAndSort.Tests
{
    [TestClass()]
    public class SearchProgramTests
    {
        [TestMethod()]
        public void BubbleSortTest()
        {
            SearchProgram prog = new SearchProgram();
            prog.GenerateSortedArray(100);
            prog.Print();
            var expected = (int[])prog.IntArray.Clone();
            prog.GenerateScrambledArray(100);
            prog.Print();
            prog.BubbleSort();
            prog.Print();
            var actual = (int[])prog.IntArray.Clone();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}