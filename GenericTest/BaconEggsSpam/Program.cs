using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaconEggsSpam
{
    class Program
    {
        static SortedList<string, SortedSet<string>> mem;

        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            while (true)
            {
                var orders = int.Parse(Console.ReadLine());
                if (orders == 0)
                {
                    Console.WriteLine(sb.ToString());
                    return;
                }
                mem = new SortedList<string, SortedSet<string>>();
                for (int i = 0; i < orders; i++)
                {
                    var line = Console.ReadLine().Split(' ');
                    for (int j = 1; j < line.Length; j++)
                    {
                        if (mem.ContainsKey(line[j]))
                            mem[line[j]].Add(line[0]);
                        else
                            mem[line[j]] = new SortedSet<string> { line[0] };
                    }
                }
                foreach (var pair in mem)
                {
                    sb.Append($"{pair.Key} {string.Join(" ", pair.Value)}\n");
                }
                sb.Append("\n");
            }
        }
    }
}
