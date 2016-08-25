using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTest
{
    class Program
    {
        static void Main(string[] args)
        {
            NonGenericTest();
            GenericTest();
            NonGenericPairTest();
            GenericPairTest();
        }

        public static void NonGenericTest()
        {

            var list = new ArrayList();

            list.Add(3);
            list.Add(4);

            // Not type safe!
            //list.Add("ohoh!");

            int t = 0;
            foreach (var x in list)
            {
                t += (int)x;
            }
            Console.WriteLine(t);
        }

        public static void GenericTest()
        {

            var list = new List<int>();

            list.Add(3);
            list.Add(4);

            // Not type safe!
            //list.Add("ohoh!");

            int t = 0;
            foreach (var x in list)
            {
                t += (int)x;
            }
            Console.WriteLine(t);
        }

        public static void NonGenericPairTest()
        {
            Pair nonGenricPair = new Pair() { First = "Första", Second = 2 };

            //Runtime error
            //int i = (int)nonGenricPair.First;
            //int j = (int)nonGenricPair.Second;


            Console.WriteLine($"First: {nonGenricPair.First}");
            Console.WriteLine($"Second: {nonGenricPair.Second}");
        }

        public static void GenericPairTest()
        {
            var nonGenricPair = new Pair<string>() {
                First = "Första",
                Second = "2" };

            //Compile error
            //int i = (int)nonGenricPair.First;
            //int j = (int)nonGenricPair.Second;


            Console.WriteLine($"First: {nonGenricPair.First}");
            Console.WriteLine($"Second: {nonGenricPair.Second}");
        }
        public class Pair
        {
            public Object First { get; set; }
            public Object Second { get; set; }

        }

        public class Pair<T>
        {
            public T First { get; set; }
            public T Second { get; set; }

        }
    }
}
