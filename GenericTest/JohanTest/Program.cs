using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohanTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] foo = { 1, 2, 3, 4, 5 };

            Allan(foo);
            Tryggve(foo);
            Bengt(foo);
            Josephus(foo);
        }

        static void Allan<T>(IEnumerable<T> input)
        {
            var queue = new Queue<T>(input);
            queue.Enqueue(queue.Dequeue());

            Console.WriteLine(string.Join(", ", queue));
        }

        static void Tryggve<T>(IEnumerable<T> input)
        {
            var stack = new Stack<T>(input);
            var queue = new Queue<T>(stack);

            Console.WriteLine(string.Join(", ", queue));
        }

        static void Bengt<T>(IEnumerable<T> input)
        {
            var queue = new Queue<T>(input);
            T t = queue.Dequeue();

            var stack = new Stack<T>(queue);
            stack.Push(t);

            Console.WriteLine(string.Join(", ", stack));
        }

        // En ful men korrekt brute force-lösning på Josephus-problemet, O(n)
        // https://en.wikipedia.org/wiki/Josephus_problem
        static void Josephus<T>(IEnumerable<T> input)
        {
            var circle = new Queue<T>(input);

            while (circle.Count > 1)
            {
                circle.Enqueue(circle.Dequeue());
                circle.Dequeue();
            }

            Console.WriteLine(circle.Dequeue());
        }
    }
}
