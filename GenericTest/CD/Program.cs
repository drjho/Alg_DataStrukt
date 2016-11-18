using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD
{
    class Program
    {
        static bool[] cds;

        static void Main(string[] args)
        {
            while (true)
            {
                var line = Console.ReadLine().Split(' ');
                var n = int.Parse(line[0]);
                var m = int.Parse(line[1]);
                if (n == 0 && m == 0)
                    break;
                cds = new bool[1000000001];
                for (int i = 0; i < n; i++)
                {
                    cds[int.Parse(Console.ReadLine())] = true;
                }
                var res = 0;
                for (int i = 0; i < m; i++)
                {
                    if (cds[int.Parse(Console.ReadLine())])
                    {
                        res++;
                    }
                }
                Console.WriteLine(res);

            }
        }
    }
}
