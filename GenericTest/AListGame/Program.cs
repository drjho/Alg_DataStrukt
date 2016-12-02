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
            var input = int.Parse(Console.ReadLine());
            ListGame(input);
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
    }
}
