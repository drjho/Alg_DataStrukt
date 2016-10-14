using Microsoft.VisualStudio.TestTools.UnitTesting;
using _05BinarySearchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05BinarySearchTree.Tree;

namespace _05BinarySearchTree.Tests
{
    [TestClass()]
    public class AddressBookTests
    {
        [TestMethod()]
        public void StartsWithPrintTest()
        {
            var book = new AddressBook();
            var a1 = new Contact { Name = "a1", Number = "1" };
            var b1 = new Contact { Name = "b1", Number = "1" };
            var b2 = new Contact { Name = "b2", Number = "2" };
            var b3 = new Contact { Name = "b3", Number = "3" };
            var c1 = new Contact { Name = "c1", Number = "1" };
            book.AddContact(b2);
            book.AddContact(b1);
            book.AddContact(b3);
            book.AddContact(c1);
            book.AddContact(a1);

            var expected = new List<Contact> { b1, b2, b3 };
            var actual = book.GetContactStartsWith("b").ToSortedList();
  
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}