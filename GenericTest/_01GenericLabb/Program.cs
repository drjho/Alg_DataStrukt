using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01GenericLabb
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person("Bo", 2); 
            var p2 = new Person("Do", 21); 
            var p3 = new Person("Fo", 32); 
            var p4 = new Person("Do", 24); 
            var p5 = new Person("Ho", 52); 
            var p6 = new Person("Jo", 26);

            var pSet = new MySet<Person>();
            pSet.Add(p1);
            pSet.Add(p2);
            pSet.Add(p3);
            pSet.Add(p4);
            pSet.Add(p5);
            pSet.Add(p6);

            Console.WriteLine($"pSet size: {pSet.Count}");

            pSet.Add(p6);

            Console.WriteLine($"pSet size: (expected 6) {pSet.Count}");

            Console.WriteLine($"(expected exist) :  {pSet.Contains(p1)}");

            pSet.Remove(p3);

            Console.WriteLine($"(expected not exist) :  {pSet.Contains(p3)}");


        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

