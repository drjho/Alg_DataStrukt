using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03SearchAndSort.Algorithms
{
    public static class SortAlgorithm
    {
        public static void BubbleSort<T>(T[] array, Func<T,T,bool> compare) 
        {
            var swapped = false;
            for (int i = 0; i < array.Length; i++)
            {
                swapped = false;
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (compare(array[j], array[j - 1]))
                    {
                        var temp = array[j];
                        array[j] = array[j-1];
                        array[j-1] = temp;
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
