using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03SearchAndSort.Algorithms
{
    public static class SearchAlgorithms
    {
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
