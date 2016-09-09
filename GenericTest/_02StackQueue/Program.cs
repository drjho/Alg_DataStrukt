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
            Rpn();
            Console.WriteLine("\n");
            //QueueDemo();
            //Console.WriteLine("\n");
            //StackDemo();
        }

        static void Rpn()
        {
            var rpn = new RPN_Calculator();
            while (true)
            {
                Console.Write("Input: ");
                rpn.ReadInput(Console.ReadLine());
                rpn.ShowResult();
            }
        }

        static void QueueDemo()
        {
            Console.WriteLine("Queue Demo:");
            var q = new MyQueue<int>();

            q.Add(10);
            q.Add(11);
            q.Add(12);
            Console.WriteLine("Count: " + q.Count);

            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--- Dequeue ---");
            Console.WriteLine(q.GetAndRemove());
            Console.WriteLine("---");
            Console.WriteLine("Count: " + q.Count);

            Console.WriteLine("--- Peek ---");
            Console.WriteLine(q.Get());
            Console.WriteLine("Count: " + q.Count);
            Console.WriteLine("--- List:");

            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---");

            Console.WriteLine("contains 100? " + q.Contains(100));
            Console.WriteLine("contains 11? " + q.Contains(11));
            Console.WriteLine("contains 12? " + q.Contains(12));
            Console.WriteLine("contains 10? " + q.Contains(10));

            Console.WriteLine("--- Clear ---");


            q.Clear();
            Console.WriteLine("Count: " + q.Count);
            Console.WriteLine("--- List:");

            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
        }

        static void StackDemo()
        {
            Console.WriteLine("Stack Demo:");
            var s = new MyStack<int>();

            s.Add(10);
            s.Add(11);
            s.Add(12);
            Console.WriteLine("Count: " + s.Count);
            Console.WriteLine("--- List:");

            foreach (var item in s)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--- Pop ---");
            Console.WriteLine(s.GetAndRemove());
            Console.WriteLine("Count: " + s.Count);
            Console.WriteLine("---");

            Console.WriteLine("--- Peek ---");
            Console.WriteLine(s.Get());
            Console.WriteLine("Count: " + s.Count);
            Console.WriteLine("---");


            foreach (var item in s)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---");

            Console.WriteLine("contains 100? " + s.Contains(100));
            Console.WriteLine("contains 11? " + s.Contains(11));
            Console.WriteLine("contains 12? " + s.Contains(12));
            Console.WriteLine("contains 10? " + s.Contains(10));


            Console.WriteLine("--- Clear ---");

            s.Clear();
            Console.WriteLine("--- List:");
            Console.WriteLine("Count: " + s.Count);
            foreach (var item in s)
            {
                Console.WriteLine(item);
            }
        }
    }
}
