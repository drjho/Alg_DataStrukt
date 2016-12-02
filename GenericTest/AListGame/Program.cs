using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AListGame
{
    class Program
    {
        static List<int> primes = new List<int> { 2, 3, 5, 7 };
        static int index = 0;

        static void Main(string[] args)
        {
            //GenPrimes((int)Math.Pow(10, 9));
            //Console.WriteLine( "d" );
            //Console.WriteLine(string.Join(",", primes));

            //int input = 0;
            //for (int i = 999999999; i > 0; i--)
            //{
            //    if (IsPrime6(i))
            //    {
            //        Console.WriteLine(i);
            //        input = i;
            //        break;
            //    }
            //}

            var input = int.Parse(Console.ReadLine());
            ListGame(input);
            //if (IsPrime(input))
            //    Console.WriteLine(0);
            //else
            //    Console.WriteLine(Find(input, 2, 0));
            //Console.WriteLine(Factors(input));

        }

        static void ListGame(int n)
        {
            int count = 0;
            while (n > 1)
            {
                n /= FindPrimeFactor(n);
                Console.WriteLine(n);
                count++;
            }
            Console.WriteLine(count);
        }

        static int FindPrimeFactor(int n)
        {
            if (n % 2 == 0)
                return 2;
            if (n % 3 == 0)
                return 3;
            int i = 5;
            int w = 2;

            while (i * i <= n)
            {
                if (n % i == 0)
                    return i;

                i += w;
                w = 6 - w;
            }
            return n;
        }

        static bool IsPrime6(int n)
        {
            if (n % 2 == 0)
                return false;
            if (n % 3 == 0)
                return false;
            int i = 5;
            int w = 2;

            while (i*i<n)
            {
                if (n % i == 0)
                    return false;

                i += w;
                w = 6 - w;
            }
            return true;
        }

        static void GenPrimes(int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (IsPrime6(i))
                    ;
                    //Console.WriteLine(i);
            }
        }

        static bool IsPrime(int n)
        {
            if (n % 2 == 0)
                return false;
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        static int Find(int n, int s, int c)
        {
            for (int i = s; i <= n; i++)
            {
                if (n % i == 0)
                {
                    //Console.WriteLine(n + " " + i);
                    return Find(n / i, i, ++c);
                }
            }
            return c;
        }

        static int Factors(int n)
        {
            int f = 0;
            int c = 2;
            while (n > 1)
            {
                if (n % c == 0)
                {
                    n /= c;
                    Console.WriteLine(n + " " + c);
                    f++;
                }
                else
                {
                    c++;
                }
            }
            return f;
        }
    }
}
