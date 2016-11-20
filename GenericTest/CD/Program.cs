using System;

namespace CD
{
    class Program
    {
        static char[] cds = new char[1000000001];

        static void Main(string[] args)
        {
            var c = 'a';
            while (true)
            {
                var line = Console.ReadLine().Split(' ');
                var n = int.Parse(line[0]);
                var m = int.Parse(line[1]);
                if (n == 0 && m == 0)
                    break;
                for (int i = 0; i < n; i++)
                {
                    cds[intParse(Console.ReadLine())] = c;
                }
                var res = 0;
                for (int i = 0; i < m; i++)
                {
                    if (cds[intParse(Console.ReadLine())] == c)
                    {
                        res++;
                    }
                }
                Console.WriteLine(res);
                c++;
            }
        }

        static int intParse(string value)
        {
            int result = 0;
            for (int i = 0; i < value.Length; i++)
            {
                result = 10 * result + (value[i] - 48);
            }
            return result;
        }
    }
}
