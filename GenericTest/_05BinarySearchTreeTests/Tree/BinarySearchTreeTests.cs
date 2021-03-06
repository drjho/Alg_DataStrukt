﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using _05BinarySearchTree.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05BinarySearchTree.Tree.Tests
{
    [TestClass()]
    public class BinarySearchTreeTests
    {


        [TestMethod()]
        public void SizeTest()
        {
            var t = new BinarySearchTree<int>();
            t.Add(5);
            t.Add(1);
            t.Add(2);
            var expected = 3;
            var actual = t.Size;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddTest()
        {
            var t = new BinarySearchTree<int>();
            t.Add(5);
            t.Add(4);
            t.Add(3);
            t.Add(2);
            t.Add(1);
            var expected = 4;
            var actual = t.Depth;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void AddTest1()
        {
            var t = new BinarySearchTree<int>();
            t.Add(5);
            t.Add(4);

            var n = t.Find(t.Root, 4);
            var actual = n.IsLeftNode;
            var expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddTest2()
        {
            var t = new BinarySearchTree<int>();
            t.Add(5);
            t.Add(5);

            var actual = 1;
            var expected = t.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ClearTest()
        {
            var t = new BinarySearchTree<int>();
            t.Add(5);
            t.Add(4);
            t.Add(3);
            t.Add(2);
            t.Add(1);
            var size = t.Size;
            t.Clear();
            var expected = 5;
            var actual = size - t.ExplicitCount(t.Root, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ContainsTest()
        {
            var t = new BinarySearchTree<int>();
            t.Add(5);
            t.Add(3);
            bool expected = true;
            bool actual = t.Contains(3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ContainsTest2()
        {
            var t = new BinarySearchTree<int>();
            t.Add(5);
            bool expected = false;
            bool actual = t.Contains(4);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BalanceTest1()
        {
            var t = new BinarySearchTree<int>();
            t.Add(8);
            t.Add(5);
            t.Add(9);
            t.Add(4);
            t.Add(6);
            t.Add(10);
            t.Add(11);

            var actual = t.IsBalanced;
            var expected = false;
            //Console.WriteLine(string.Join(",", t.ToSortedList()));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BalanceTest2()
        {
            var t = new BinarySearchTree<int>();
            t.Add(8);
            t.Add(5);
            t.Add(9);
            t.Add(4);
            t.Add(6);
            t.Add(10);
            t.Add(3);

            var actual = t.IsBalanced;
            var expected = true;
            //Console.WriteLine(string.Join(",", t.ToSortedList()));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAndRemoveTest()
        {

        }

        [TestMethod()]
        public void ExplicitCountTest()
        {
            var t = new BinarySearchTree<int>();
            t.Add(5);
            t.Add(4);
            t.Add(3);
            t.Add(2);
            t.Add(1);
            var expected = 5;
            //var actual = t.ExplicitCount(t.Root, 0);
            var actual = t.ExplicitCount();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DepthDifferenceTest()
        {
            var t = new BinarySearchTree<int>();
            t.Add(5);
            t.Add(4);
            t.Add(3);
            t.Add(2);
            t.Add(1);

            var expected = 4;
            var actual = t.DepthDifference(t.Root);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DepthDifferenceTest2()
        {
            var t = new BinarySearchTree<int>();
            t.Add(4);
            t.Add(5);
            t.Add(3);
            t.Add(2);
            t.Add(1);

            var expected = 2;
            var actual = t.DepthDifference(t.Root);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DepthDifferenceTest3()
        {
            var t = new BinarySearchTree<int>();
            t.Add(4);
            t.Add(5);
            t.Add(2);
            t.Add(3);
            t.Add(1);

            var expected = 1;
            var actual = t.DepthDifference(t.Root);


            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToSortedListTest()
        {
            var t = new BinarySearchTree<int>();
            t.Add(4);
            t.Add(5);
            t.Add(2);
            t.Add(3);
            t.Add(1);

            var expected = new List<int> { 1, 2, 3, 4, 5 };
            var actual = t.ToSortedList();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}