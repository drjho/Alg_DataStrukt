using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03SearchAndSort.Algorithms
{
    public static class SearchAlgorithms
    {
        static Random random = new Random();

        public static void BenchmarkSearch(int repeats, int length)
        {
            var array = Enumerable.Range(0, length).ToArray();
            Console.WriteLine($"Start benchmark of search methods {repeats} times with array of length {length}...");

            #region LinearSearch benchmark
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < repeats; i++)
            {
                int item = random.Next(array.Length);

                LinearSearch(array, item, (a, b) => a == b);
            }
            stopwatch.Stop();
            Console.WriteLine($"Time to perform LinearSearch {repeats} times took {stopwatch.ElapsedMilliseconds} ms");
            #endregion


            #region LinearLinqSearch benchmark
            stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < repeats; i++)
            {
                int item = random.Next(array.Length);
                LinearLinqSearch(array, item, (a, b) => a == b);
            }
            stopwatch.Stop();
            Console.WriteLine($"Time to perform LinearLinqSearch {repeats} times took {stopwatch.ElapsedMilliseconds} ms");
            #endregion

            #region BinarySearch benchmark
            stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < repeats; i++)
            {
                int item = random.Next(array.Length);
                BinarySearch(array, item, (a, b) => a - b);
            }
            stopwatch.Stop();
            Console.WriteLine($"Time to perform BinarySearch {repeats} times took {stopwatch.ElapsedMilliseconds} ms");
            #endregion

        }

        public static int LinearSearch<T>(T[] array, T item, Func<T, T, bool> condition)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (condition(array[i], item))
                {
                    return i;
                }
            }
            return -1;
        }

        public static T LinearLinqSearch<T>(T[] array, T item, Func<T, T, bool> condition)
        {
            return array.FirstOrDefault(i => condition(i, item));
        }

        public static int BinarySearch<T>(T[] array, T item, Func<T, T, int> compare)
        {
            int start = 0;
            int end = array.Length;
            while (start < end)
            {
                int pos = Average(start, end);
                int comp = compare(array[pos], item);
                if (comp == 0)
                {
                    return pos;
                }
                else if (comp < 0)
                {
                    start = pos + 1;
                }
                else
                {
                    end = pos - 1;
                }
            }
            return -1;
        }

        public static int Average(int a, int b)
        {
            return (int)(a + b) >> 1;
        }

        public static T[] RegionGrow<T>(T[] array, int seedPosition, Func<T, T, bool> condition)
        {
            if (seedPosition < 0 || seedPosition >= array.Length)
            {
                Console.WriteLine(seedPosition + " is out of range.");
                return null;
            }
            List<T> list = new List<T> { array[seedPosition] };
            int pos = seedPosition - 1;
            while (condition(array[pos], array[seedPosition]))
            {
                list.Add(array[pos--]);
            }
            pos = seedPosition + 1;
            while (condition(array[pos], array[seedPosition]))
            {
                list.Add(array[pos++]);
            }
            return list.ToArray();
        }

    }
}
