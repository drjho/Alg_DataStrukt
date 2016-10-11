using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03SearchAndSort.Algorithms;
using _03SearchAndSort.Entities;

namespace _04Hash
{
    class Program
    {
        static Random random { get; } = new Random();

        static void Main(string[] args)
        {
            //CarPlateBenchmark(100000);
            //Benchmark();
            //VowelsCount();
        }

        static void Rim()
        {
            
        }

        static void CarPlateBenchmark(int repeats)
        {
            for (int i = 10; i <= 15; i++)
            {
                var plates = SwedishCarPlate.GenerateCarPlates((int)Math.Pow(2, i));
                var dict = plates.GroupBy(p => p.Letters, p => p).ToDictionary(g => g.Key, g => g.ToList());
                //foreach (var item in dict)
                //{
                //    Console.WriteLine(item.Key + ": " + string.Join(",", item.Value.Select(p => p.CarPlate)));
                //}
                Stopwatch w = Stopwatch.StartNew();
                for (int j = 0; j < repeats; j++)
                {
                    dict.ContainsKey(SwedishCarPlate.GetRandomLetters());
                }
                w.Stop();
                Console.WriteLine($"Time to search in Dictionary {repeats} times: {w.ElapsedMilliseconds} ms");

                SortAlgorithm.BubbleSort<SwedishCarPlate>(plates, SwedishCarPlate.IsLettersOfALessThanB);




                w.Restart();
                for (int j = 0; j < repeats; j++)
                {
                    var plate = new SwedishCarPlate { Letters = SwedishCarPlate.GetRandomLetters() };
                    //Console.WriteLine("search for: " + plate.CarPlate);
                    var pos = SearchAlgorithms.BinarySearch<SwedishCarPlate>(plates,
                        plate,
                        SwedishCarPlate.CompareLetters);
                    //if (pos >= 0)
                    //{
                    //    var result = SearchAlgorithms.RegionGrow<SwedishCarPlate>(plates, pos, (a, b) => SwedishCarPlate.CompareLetters(a, b) == 0);
                    //}
                }
                w.Stop();
                Console.WriteLine($"Time to binarySearch {repeats} times: {w.ElapsedMilliseconds} ms");

            }

        }

        static void Benchmark()
        {
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



        static void VowelsCount()
        {
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'y', 'å', 'ä', 'ö' };
            Dictionary<string, int> dict;
            try
            {
                using (StreamReader reader = new StreamReader("ordlista.txt", Encoding.Default))
                {
                    dict = new Dictionary<string, int>();
                    string line;
                    Stopwatch w = Stopwatch.StartNew();
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        dict.Add(line, line.Count(c => vowels.Contains(c)));
                    }
                    w.Stop();
                    Console.WriteLine($"Time: {w.ElapsedMilliseconds}  ms");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("file not found");
                return;
            }

            Console.Write("Enter number of vowels: ");
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
