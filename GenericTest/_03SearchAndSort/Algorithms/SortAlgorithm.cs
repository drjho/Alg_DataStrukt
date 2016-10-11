using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03SearchAndSort.Algorithms
{
    public static class SortAlgorithm
    {
        static Random random = new Random();


        public static void BenchmarkSort(int repeats, int length)
        {
            var array = Enumerable.Range(0, length).ToArray();

            long time = 0;
            for (int i = 0; i < repeats; i++)
            {
                ScrambleArray<int>(array);
                Stopwatch s = Stopwatch.StartNew();
                BubbleSort<int>(array, (a, b) => a < b);
                s.Stop();
                time += s.ElapsedMilliseconds;
                Console.WriteLine($"{i}: {s.ElapsedMilliseconds}");
            }
            Console.WriteLine($"BubbleSort average at {time/repeats} over {repeats} tries.");
        }

        public static void ScrambleArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Swap(array, i, random.Next(array.Length));
            }
            Console.WriteLine("The sorted array is now scrambled.");
        }

        public static void Swap<T>(T[] array, int pos1, int pos2)
        {
            var temp = array[pos1];
            array[pos1] = array[pos2];
            array[pos2] = temp;
        }

        public static void BubbleSort<T>(T[] array, Func<T, T, bool> compare)
        {
            Console.Write("Bubble sorting... ");
            var swapped = false;
            for (int i = 0; i < array.Length; i++)
            {
                swapped = false;
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (compare(array[j], array[j - 1]))
                    {
                        Swap<T>(array, j, j - 1);
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
            Console.WriteLine("Done!");
        }
    }
}
