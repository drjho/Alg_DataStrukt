using System;

namespace EightQueens
{
    class Program
    {
        static bool[] row = new bool[8];
        static bool[] col = new bool[8];
        static bool[] dia = new bool[15];
        static bool[] dib = new bool[15];

        static int na = 7;
        static int nb = 0;

        static int r, c, a, b;

        static int count = 0;

        static void Main(string[] args)
        {
            for (r = 0; r < 8; r++)
            {
                var line = Console.ReadLine();
                for (c = 0, a = na--, b = nb++; c < 8; c++, a++, b++)
                {
                    if (line[c] == '*')
                    {
                        if (++count > 8)
                        {
                            Console.WriteLine("invalid");
                            return;
                        }
                        if (row[r] || col[c] || dia[a] || dib[b])
                        {
                            Console.WriteLine("invalid");
                            return;
                        }
                        row[r] = true;
                        col[c] = true;
                        dia[a] = true;
                        dib[b] = true;

                    }
                }
            }
            Console.WriteLine(count == 8 ? "valid" : "invalid");
        }
    }
}
