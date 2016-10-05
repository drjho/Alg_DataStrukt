using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            Benchmark();
            LetterCount();
        }

        static void Benchmark()
        {
            Random random = new Random();
            for (int i = 10; i <= 15; i++)
            {
                var max = (int)Math.Pow(2, i);
                var numbers = new HashSet<int>(Enumerable.Range(0, max));

                Stopwatch sw = Stopwatch.StartNew();
                for (int j = 0; j < 100000; j++)
                {
                    numbers.Contains(random.Next(0, max));
                }
                sw.Stop();
                Console.WriteLine($"{max}: {sw.ElapsedMilliseconds} ms.");
            }
        }

        static void LetterCount()
        {

            Dictionary<string, int> dict;
            using (StreamReader reader = new StreamReader("ordlista.txt", Encoding.Default))
            {
                dict = new Dictionary<string, int>();
                string line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    dict.Add(line, line.Length);
                }
            }

            Console.Write("Enter number of letters: ");
            int input;
            if (!int.TryParse(Console.ReadLine(), out input))
                return;

            if (dict != null)
            {
                var words = dict.Where(p => p.Value == input).Select(x => x.Key);
                Console.WriteLine(String.Join("\n", words));
            }
        }

    }
}
