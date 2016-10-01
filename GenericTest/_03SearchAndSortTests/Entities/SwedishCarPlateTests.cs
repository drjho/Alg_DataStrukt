using Microsoft.VisualStudio.TestTools.UnitTesting;
using _03SearchAndSort.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03SearchAndSort.Entities.Tests
{
    [TestClass()]
    public class SwedishCarPlateTests
    {
        [TestMethod()]
        public void CompareLettersTestA()
        {
            var a = new SwedishCarPlate { Letters = "FDS" };
            var b = new SwedishCarPlate { Letters = "FDS" };
            var actual = SwedishCarPlate.CompareLetters(a, b);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareLettersTestB()
        {
            var a = new SwedishCarPlate { Letters = "FDS" };
            var b = new SwedishCarPlate { Letters = "FSD" };
            var actual = SwedishCarPlate.CompareLetters(a, b);
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }
    }
}