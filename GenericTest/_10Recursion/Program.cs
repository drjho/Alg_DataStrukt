using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Recursion1();
            Recursion2();
        }

        static void Recursion1()
        {
            Console.WriteLine("Recusrion exercise 1:");
            var length = 10;
            var array = Enumerable.Range(1, length).ToArray();
            Console.WriteLine(string.Join(",", array));
            Console.WriteLine(SumArray(array, length - 1));
            Console.WriteLine("--- Done ---");
        }

        static int SumArray(int[] arr, int index)
        {
            if (index == 0)
                return arr[0];
            else
                return arr[index] + SumArray(arr, index - 1);
        }

        static void Recursion2()
        {
            Console.WriteLine("Recusrion exercise 2:");
            var length = 10;
            var list1 = Enumerable.Range(1, length).ToList();
            var list2 = Enumerable.Range(101, length).ToList();

            Console.WriteLine(string.Join(",", list1));
            Console.WriteLine(string.Join(",", list2));

            var res = EveryOtherArray(list1, list2, null);
            Console.WriteLine(string.Join(",", res));

            Console.WriteLine("--- Done ---");
        }

        static List<int> EveryOtherArray(List<int> list1, List<int> list2, List<int> result)
        {
            if (result == null)
                result = new List<int>();
            if (list2.Count == 0)
                return result;
            result.Add(list1[0]);
            result.Add(list2[0]);
            list1.RemoveAt(0);
            list2.RemoveAt(0);
            return EveryOtherArray(list1, list2, result);
        }
    }
}
