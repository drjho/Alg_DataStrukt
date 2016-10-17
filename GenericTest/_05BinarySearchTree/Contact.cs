using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05BinarySearchTree
{
    public class Contact : IComparable
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

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var otherContact = obj as Contact;
            if (otherContact != null)
                return NameComparer(this, otherContact);
            else
                throw new ArgumentException("Object is not a Temperature");

        }

        public override string ToString()
        {
            return Name + " | " + Number;
        }
    }
}
