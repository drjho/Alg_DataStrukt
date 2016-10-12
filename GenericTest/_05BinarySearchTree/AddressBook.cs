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
        BinarySearchTree<Contact> book = new BinarySearchTree<Contact>(Contact.NameComparer);

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
                    book.Add(c);
                }
            }
        }

        public void Print()
        {
            if (book.Root != null)
            {
                Print(book.Root);
            }
        }

        public void Print(BinaryTreeNode<Contact> node)
        {
            if (node.Left != null)
                Print(node.Left);

            Console.WriteLine(node.Value);

            if (node.Right != null)
                Print(node.Right);
        }

        public class Contact
        {
            public string Name { get; set; }
            public string Number { get; set; }

            public static int NameComparer(Contact c1, Contact c2)
            {
                return String.Compare(c1.Name, c2.Name);
            }

            public static int NumberComparer(Contact c1, Contact c2)
            {
                return String.Compare(c1.Number, c2.Number);
            }

            public override string ToString()
            {
                return Name + " | " + Number;
            }
        }
    }
}

