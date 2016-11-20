using System;
using System.Text;

namespace BitByBit
{
    class Program
    {
        static string bits = new string('?', 32);
        static StringBuilder sb;

        static void Main(string[] args)
        {
            while (true)
            {
                sb = new StringBuilder(bits);
                int cmds = int.Parse(Console.ReadLine());
                if (cmds == 0)
                    return;
                for (int i = 0; i < cmds; i++)
                {
                    var lines = Console.ReadLine().Split(' ');
                    if (lines[0] == "SET")
                        set(31 - int.Parse(lines[1]));
                    else if (lines[0] == "CLEAR")
                        clear(31 - int.Parse(lines[1]));
                    else if (lines[0] == "OR")
                        or(31 - int.Parse(lines[1]), 31 - int.Parse(lines[2]));
                    else if (lines[0] == "AND")
                        and(31 - int.Parse(lines[1]), 31 - int.Parse(lines[2]));
                }
                Console.WriteLine(sb.ToString());

            }
        }

        static void set(int n)
        {
            sb[n] = '1';
        }

        static void clear(int n)
        {
            sb[n] = '0';
        }

        static void or(int i, int j)
        {
            if (sb[i] != sb[j])
                sb[i] = (sb[j] == '1') ? sb[j] : (sb[i] == '1') ? sb[i] : (sb[j] == '0') ? sb[i] : sb[j];
        }

        static void and(int i, int j)
        {
            if (sb[i] != sb[j])
                sb[i] = (sb[i] == '0') ? sb[i] : (sb[i] == '?' && sb[j] == '1') ? '?' : sb[j];
        }
    }
}
