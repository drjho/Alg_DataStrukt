﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05BinarySearchTree.Tree;
using System.IO;

namespace _05BinarySearchTree
{
    public class AddressBook
    {
        public BinarySearchTree<Contact> Book { get; private set; } = new BinarySearchTree<Contact>(Contact.NameComparer);

        public void AddContact(Contact contact)
        {
            Book.Add(contact);
        }

        public void ImportFromFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    var strs = line.Split('|');
                    var c = new Contact
                    {
                        Name = strs[0].Trim(' '),
                        Number = strs[1].Trim(' ')
                    };
                    Book.Add(c);
                }
            }
        }

        public AddressBook GetContactStartsWith(string s)
        {
            if (Book.Root != null)
            {
                var current = Book.Root;
                s = s.ToLowerInvariant();
                var contacts = FilterContacts(current, new BinarySearchTree<Contact>(Contact.NameComparer), (a) => s.CompareTo(a.Substring(0, 1)));
                return new AddressBook { Book = contacts };
            }
            return null;
        }

        BinarySearchTree<Contact> FilterContacts(BinaryTreeNode<Contact> node, BinarySearchTree<Contact> contacts, Func<string, int> compare)
        {
            var comp = compare(node.Value.Name.ToLowerInvariant());

            if (comp > 0) // node is to the left of what we look for...
            {
                if (node.Right != null)
                    contacts = FilterContacts(node.Right, contacts, compare);
            }
            else if (comp < 0) // node is to the right of what we look for..
            {
                if (node.Left != null)
                    contacts = FilterContacts(node.Left, contacts, compare);
            }
            else // we found what we look for...
            {
                contacts.Add(node.Value);
                if (node.Left != null)
                    contacts = FilterContacts(node.Left, contacts, compare);
                if (node.Right != null)
                    contacts = FilterContacts(node.Right, contacts, compare);
            }
            return contacts;
        }

        public void Print(int count = -1)
        {
            if (Book.Root != null)
            {
                Print(Book.Root, count);
            }
        }

        public int Print(BinaryTreeNode<Contact> node, int count = -1)
        {
            if (node.Left != null)
                count = Print(node.Left, count);

            if (count > 0 ||count < 0)
            {
                Console.WriteLine(node.Value);
                --count;
            }

            if (node.Right != null)
                count = Print(node.Right, count);

            return count;
        }

        public List<Contact> ToSortedList()
        {
            return Book.ToSortedList();
        }


    }
}

