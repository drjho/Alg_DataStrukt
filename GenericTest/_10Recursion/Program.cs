using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Permutation("abcd");
            //Hanoi();
            //Recursion1();
            //Recursion2();
            //PhoneList(@"C:\Users\m97_j\Downloads\samples\phone.in");
        }

        static void Recursion1()
        {
            Console.WriteLine("Recursion exercise 1:");
            var length = 10;
            var array = Enumerable.Range(1, length).ToArray();
            Console.WriteLine("array to sum: " + string.Join(",", array));
            Console.WriteLine("the sum: " + SumArray(array, length - 1));
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
            Console.WriteLine("Recursion exercise 2:");
            var length = 10;
            var list1 = Enumerable.Range(1, length).ToList();
            var list2 = Enumerable.Range(101, length).ToList();

            Console.WriteLine("list 1: " + string.Join(",", list1));
            Console.WriteLine("list 2: " + string.Join(",", list2));

            var res = EveryOtherArray(list1, list2, null);
            Console.WriteLine("result: " + string.Join(",", res));

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

        static void Permutation(String str)
        {
            permutation(str, 0, str.Length - 1);
        }

        static string swap(string str, int pos1, int pos2)
        {
            if (pos1 >= pos2)
                return str;
            var n = str.Length - 1;
            return str.Substring(0, pos1) +
                str[pos2] +
                str.Substring(pos1 + 1, pos2 - pos1 - 1) +
                str[pos1] +
                ((pos2 == n) ? "" : str.Substring(pos2 + 1, n - pos2));
        }

        private static void permutation(string str, int pos1, int pos2)
        {
            if (pos1 == pos2)
                Console.WriteLine(str);
            else
            {
                for (int i = pos1; i <= pos2; i++)
                {
                    str = swap(str, pos1, i);
                    permutation(str, pos1 + 1, pos2);
                    str = swap(str, pos1, i);
                }
            }
        }

        static Stack<int> a = new Stack<int>(Enumerable.Range(1, 5).Reverse());
        static Stack<int> b = new Stack<int>();
        static Stack<int> c = new Stack<int>();
        static int count = 0;

        static void Hanoi()
        {
            HanoiMove(5, a, c, b);
        }

        static void HanoiOutput()
        {
            Console.WriteLine($"--- {count++} ---");
            Console.WriteLine("src: " + String.Join(",", a.Reverse()));
            Console.WriteLine("aux: " + String.Join(",", b.Reverse()));
            Console.WriteLine("tgt: " + String.Join(",", c.Reverse()));

        }

        static void HanoiMove(int n, Stack<int> src, Stack<int> tgt, Stack<int> aux)
        {
            if (n > 0)
            {
                HanoiMove(n - 1, src, aux, tgt);

                tgt.Push(src.Pop());

                HanoiOutput();

                HanoiMove(n - 1, aux, tgt, src);
            }
        }

        static void PhoneList(string filename)
        {
            if (!File.Exists(filename))
                return;
            using (StreamReader sr = new StreamReader(filename))
            {
                int numSets;
                int numLines;
                try
                {
                    
                    if (int.TryParse(sr.ReadLine(), out numSets))
                    {
                        if (numSets < 1 || numSets > 40)
                            throw new Exception("numSets error");
                        for (int i = 0; i < numSets; i++)
                        {
                            var set = new SortedSet<string>(new PhoneComparer());
                            bool notFound = true;
                            if (int.TryParse(sr.ReadLine(), out numLines))
                            {
                                if (numLines < 1 || numLines > 10000)
                                    throw new Exception("numLines error");
                                for (int j = 0; j < numLines; j++)
                                {
                                    var str = sr.ReadLine();
                                    if (str.Length > 10)
                                        throw new Exception("phone number error");

                                    if (!set.Add(str))
                                    {
                                        notFound = false;
                                    }
                                }
                                Console.WriteLine((notFound) ? "YES" : "NO");
                            }
                        }
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


    }

    public class PhoneComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var length = Math.Min(x.Length, y.Length);
            for (int i = 0; i < length; i++)
            {
                if (x[i] != y[i])
                    return x[i].CompareTo(y[i]);
            }
            return 0;
        }
    }
}

