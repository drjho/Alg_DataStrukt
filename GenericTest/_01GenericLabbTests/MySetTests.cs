using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01GenericLabb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01GenericLabb.Tests
{
    [TestClass()]
    public class MySetTests
    {
        [TestMethod()]
        public void AddTest()
        {
            MySet<int> s = new MySet<int>();
            int expected = 1000;
            for (int i = 0; i < expected; i++)
            {
                s.Add(i);
            }

            int actual = s.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddTest2()
        {
            MySet<int> s = new MySet<int>();
            s.Add(1);
            s.Add(2);
            s.Add(1);
            int expected = 2;
            int actual = s.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ContainsTest()
        {
            MySet<int> s = new MySet<int>();
            for (int i = 0; i < 1000; i++)
            {
                s.Add(i);
            }
            bool expected = true;
            bool actual = s.Contains(500);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ContainsFailTest()
        {
            MySet<int> s = new MySet<int>();
            for (int i = 0; i < 1000; i++)
            {
                s.Add(i);
            }
            bool expected = true;
            bool actual = s.Contains(2000);

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod()]
        public void copyTest()
        {
            MySet<string> s = new MySet<string>();
            s.Add("a");
            s.Add("b");
            var c = s.Copy();

            bool expected = true;
            bool actual = c.Contains("a") & c.Contains("b");

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void EqualToTest()
        {
            MySet<string> s = new MySet<string>();
            s.Add("a");
            s.Add("b");

            MySet<string> c = new MySet<string>();
            c.Add("a");
            c.Add("b");

            bool expected = true;
            bool actual = c.EqualTo(s);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void EqualToTest2()
        {
            MySet<string> s = new MySet<string>();
            s.Add("a");
            s.Add("b");

            MySet<string> c = new MySet<string>();
            c.Add("a");
            c.Add("b");
            c.Add("b");


            bool expected = true;
            bool actual = c.EqualTo(s);

            Assert.AreEqual(expected, actual);

        }


        [TestMethod()]
        public void EqualToTest3()
        {
            MySet<string> s = new MySet<string>();
            s.Add("a");
            s.Add("b");

            MySet<string> c = new MySet<string>();
            c.Add("a");
            c.Add("b");
            c.Add("c");


            bool expected = false;
            bool actual = c.EqualTo(s);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void IntersectionWithTest()
        {
            MySet<string> s = new MySet<string>();
            s.Add("a");
            s.Add("b");

            MySet<string> c = new MySet<string>();
            c.Add("a");
            c.Add("b");
            c.Add("c");

            var actual = c.IntersectionWith(s);

            Assert.IsTrue(actual.Contains("a") & actual.Contains("b"));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            MySet<string> c = new MySet<string>();
            c.Add("a");
            c.Add("b");
            c.Add("c");

            c.Remove("c");

            int expected = 2;
            int actual = c.Count;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void RemoveTest2()
        {
            MySet<string> c = new MySet<string>();
            c.Add("a");
            c.Add("b");
            c.Add("c");

            c.Remove("d");

            int expected = 3;
            int actual = c.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UnionWithTest()
        {
            MySet<string> s = new MySet<string>();
            s.Add("a");
            s.Add("b");

            MySet<string> c = new MySet<string>();
            c.Add("a");
            c.Add("b");
            c.Add("c");

            var actual = c.UnionWith(s);

            Assert.IsTrue(actual.Contains("a") & actual.Contains("b") & actual.Contains("c") & c.Count == 3);
        }
    }
}