using System;

namespace CD
{
    class Program
    {
        static int[] cds;

        static void Main(string[] args)
        {
            while (true)
            {
                var line = Console.ReadLine().Split(' ');
                var n = int.Parse(line[0]);
                var m = int.Parse(line[1]);
                if (n == 0 && m == 0)
                    break;
                cds = new int[n];
                for (int i = 0; i < n; i++)
                {
                    cds[i] = int.Parse(Console.ReadLine());
                }
                var res = 0;
                var i1 = 0;
                for (int i = 0; i < m; i++)
                {
                    var j2 = int.Parse(Console.ReadLine());
                    if (i1 >= cds.Length || j2 < cds[i1])
                        continue;
                    while (j2 > cds[i1])
                    {
                        if (++i1 >= cds.Length)
                            break;
                        
                    }
                    if (i1 < cds.Length && j2 == cds[i1])
                        res++;
                }
                Console.WriteLine(res); 

            }
        }
    }
}
