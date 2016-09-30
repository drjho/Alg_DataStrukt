using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03SearchAndSort
{
    public class SearchSortLabb
    {
        public int[] IntArray { get; set; } = null;
        Random random = new Random();

        public SearchSortLabb()
        {
            for (int i = 10; i <= 15; i++)
            {
                var length = (int)Math.Pow(2, i);
                GenerateSortedArray(length);

                Console.WriteLine(RepeatSearch(100000, LinearSearch));
                Console.WriteLine(RepeatSearch(100000, BinarySearch));

                GenerateScrambledArray(length);
                Stopwatch stopwatch = Stopwatch.StartNew();
                BubbleSort();
                stopwatch.Stop();
                Console.WriteLine($"Bubble sort of array with length {length} took {stopwatch.ElapsedMilliseconds} ms.");
                Console.WriteLine(new string('-', 50));
            }
        }

        public void Print()
        {
            Console.WriteLine(string.Join<int>(",", IntArray));
        }

        public void GenerateScrambledArray(int length)
        {
            GenerateSortedArray(length);
            for (int i = 0; i < length; i++)
            {
                Swap(i, random.Next(length));
            }
            Console.WriteLine("The sorted array is now scrambled.");
        }

        public void GenerateSortedArray(int length)
        {
            IntArray = Enumerable.Range(0, length).ToArray();
            Console.WriteLine($"Generated an array of length: {length}");
        }

        public string RepeatSearch(int repeats, Func<int, bool> searchMethod)
        {
            if (IntArray == null || IntArray.Length == 0)
            {
                return "array not initiated.";
            }
            Console.WriteLine($"Start {searchMethod.Method.Name} {repeats} times...");
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < repeats; i++)
            {
                int item = random.Next(IntArray.Length);

                var found = searchMethod(item);
            }
            stopwatch.Stop();
            return repeats + $" {searchMethod.Method.Name} in [ms]: " + stopwatch.ElapsedMilliseconds;
        }

        public bool LinearSearch(int item)
        {
            for (int j = 0; j < IntArray.Length; j++)
            {
                if (IntArray[j] == item)
                {
                    return true;
                }
            }
            return false;
        }

        public bool BinarySearch(int item)
        {
            int start = 0;
            int end = IntArray.Length - 1;
            while (start < end)
            {
                int pos = (int)Math.Floor(.5 * (start + end));
                if (IntArray[pos] == item)
                {
                    return true;
                }
                else if (IntArray[pos] < item)
                {
                    start = pos + 1;
                }
                else
                {
                    end = pos - 1;
                }
            }
            return false;
        }

        public void Swap(int pos1, int pos2)
        {
            var temp = IntArray[pos1];
            IntArray[pos1] = IntArray[pos2];
            IntArray[pos2] = temp;
        }

        public void BubbleSort()
        {
            var swapped = false;
            for (int i = 0; i < IntArray.Length; i++)
            {
                swapped = false;
                for (int j = IntArray.Length - 1; j > i; j--)
                {
                    if (IntArray[j] < IntArray[j - 1])
                    {
                        Swap(j, j - 1);
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
            Console.WriteLine("Bubble Sort performed.");
        }
    }
}
