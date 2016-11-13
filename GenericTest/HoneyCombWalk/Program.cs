using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyCombWalk
{
    class Program
    {
        static int[,,] mem = new int[15, 29, 29];

        static void Main(string[] args)
        {
            int cases = int.Parse(Console.ReadLine());
            for (int i = 0; i < cases; i++)
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(Move(n, 0, 0));
            }
        }

        static int Move(int n, int x, int y)
        {
            if (n == 0)
            {
                if (x == 0 && y == 0)
                {
                    return 1;
                }
                return 0;
            }

            if (mem[n, x + 14, y + 14] != 0)
                return mem[n, x + 14, y + 14];

            int steps = 0;

            int next = n - 1;

            steps += Move(next, x + 1, y + 1);
            steps += Move(next, x + 1, y);
            steps += Move(next, x, y - 1);
            steps += Move(next, x - 1, y - 1);
            steps += Move(next, x - 1, y);
            steps += Move(next, x, y + 1);

            mem[n, x + 14, y + 14] = steps;
            return steps;
        }
    }
}
