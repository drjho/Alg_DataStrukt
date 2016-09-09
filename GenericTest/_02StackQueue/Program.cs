using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02StackQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new MyQueue<int>();

            q.Add(10);
            q.Add(11);
            q.Add(12);

            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---");
            Console.WriteLine(q.GetAndRemove());
            Console.WriteLine("---");

            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---");

            Console.WriteLine("contains 100? " + q.Contains(100));
            Console.WriteLine("contains 11? " + q.Contains(11));
            Console.WriteLine("contains 12? " + q.Contains(12));

            Console.WriteLine("---");

            q.Clear();
            foreach (var item in q)
            {
                Console.WriteLine(item);
            }

        }
    }
}
