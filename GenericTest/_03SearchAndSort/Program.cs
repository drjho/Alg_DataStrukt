using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03SearchAndSort
{
    class SearchProgram
    {
        int[] intArray { get; set; } = null;
        Random random = new Random();

        static void Main(string[] args)
        {
            SearchProgram prog = new SearchProgram();
            //Console.WriteLine(prog.LinearSearch(1));

            for (int i = 10; i <= 15; i++)
            {
                var length = (int)Math.Pow(2, i);
                Console.WriteLine(prog.GenerateSortedArray(length));
                Console.WriteLine(prog.RepeatSearch(100000, prog.LinearSearch));
                Console.WriteLine(prog.RepeatSearch(100000, prog.BinarySearch));
            }
        }

        public string GenerateSortedArray(int length)
        {
            intArray = Enumerable.Range(0, length).ToArray();
            return $"Generated an array of length: {length}";
        }

        public string RepeatSearch(int repeats, Func<int, bool> searchMethod)
        {
            if (intArray == null || intArray.Length == 0)
            {
                return "array not initiated.";
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < repeats; i++)
            {
                int item = random.Next(intArray.Length);

                var found = searchMethod(item);
            }
            stopwatch.Stop();
            return repeats + $" {searchMethod.Method.Name} in [ms]: " + stopwatch.ElapsedMilliseconds;
        }

        public bool LinearSearch(int item)
        {
            for (int j = 0; j < intArray.Length; j++)
            {
                if (intArray[j] == item)
                {
                    return true;
                }
            }
            return false;
        }

        public bool BinarySearch(int item)
        {
            int start = 0;
            int end = intArray.Length - 1;
            while (start < end)
            {
                int pos = (int)Math.Floor(.5 * (start + end));
                if (intArray[pos] == item)
                {
                    return true;
                }
                else if (intArray[pos] < item)
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
    }
}
