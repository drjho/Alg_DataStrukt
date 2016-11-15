using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePath
{
    class Program
    {
        static HashSet<int> primes = new HashSet<int>();

        static void Main(string[] args)
        {
            Primes(1001, 10000);
            Console.WriteLine("done " + primes.Count);
            //NextPrimes(1033);
            Console.WriteLine(Steps(1033, 8179));
            Console.WriteLine(Steps(1373, 8017));
            Console.WriteLine(Steps(1033, 1033));

            var repeats = int.Parse(Console.ReadLine());
            for (int i = 0; i < repeats; i++)
            {
                var inputs = Console.ReadLine().Split(' ');
                
                var res = Steps(int.Parse(inputs[0]), int.Parse(inputs[1]));
                if (res < 0)
                {
                    Console.WriteLine("Impossible");
                }
                else
                {
                    Console.WriteLine(res);
                }
            }

        }

        static int Steps(int start, int goal)
        {
            var dist = new int[10000];

            var q = new Queue<int>();
            q.Enqueue(start);
            dist[start] = 1;
            while (q.Count > 0)
            {
                var current = q.Dequeue();
                if (current == goal)
                    return dist[current] - 1;
                foreach (var next in NextPrimes(current))
                {
                    if (dist[next] == 0)
                    {
                        dist[next] = dist[current] + 1;
                        q.Enqueue(next);
                    }
                }
            }
            return -1;
        }

        static List<int> NextPrimes(int n)
        {
            var list = new List<int>();
            int a = 1000 * (int)(n / 1000);
            int b = 100 * (int)((n - a) / 100);
            int c = 10 * (int)((n - a - b) / 10);
            int d = n - a - b - c;
            var nums = new int[] { a, b, c, d };
            for (int i = 0; i < 4; i++)
            {
                var scl = Math.Pow(10, 3 - i);
                var rst = n - nums[i];
                for (int j = 0; j < 10; j++)
                {
                    var tmp = (int)(rst + scl * j);
                    if (primes.Contains(tmp))
                    {
                        //Console.WriteLine(tmp);
                        list.Add(tmp);
                    }
                }
            }
            return list;
        }

        static void Primes(int start, int end)
        {
            primes = new HashSet<int>();
            for (int i = start; i < end; i += 2)
            {
                if (CheckPrime(i))
                    primes.Add(i);
            }
        }

        static bool CheckPrime(int n)
        {
            for (int i = 3; i < n / 2; i+= 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
    }
}
