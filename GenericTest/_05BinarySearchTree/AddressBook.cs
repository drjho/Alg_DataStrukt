using System;
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
        public BinarySearchTree<Contact> Book { get; private set; } = new BinarySearchTree<Contact>();

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
                var contacts = FilterContacts(current, new BinarySearchTree<Contact>(), (a) => s.CompareTo(a.Substring(0, 1)));
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
                Func<int, Func<bool>> closure = (i) =>
                {
                    int counter = i;

                    return () =>
                    {
                        if (i < 0)
                            return true;
                        if (counter-- > 0)
                            return true;
                        else
                            return false;
                    };
                };
                Print(Book.Root, closure(count));

            }
        }

        [Obsolete("Method not used, CountDown is defined in Print(int Count) directly.")]
        static Func<bool> CountDown(int i)
        {
            int count = i;

            return () =>
            {
                if (i < 0)
                    return true;
                if (count-- > 0)
                    return true;
                else
                    return false;
            };
        }

        public void Print(BinaryTreeNode<Contact> node, Func<bool> condition)
        {

            if (node.Left != null)
                Print(node.Left, condition);

            if (condition())
            {
                Console.WriteLine(node.Value);
            }

            if (node.Right != null)
                Print(node.Right, condition);

        }

        public List<Contact> ToSortedList()
        {
            return Book.ToSortedList();
        }


    }
}

