using System;
using System.IO;

namespace Apparatus
{
    class Program
    {
        static int mod = 1000003;

        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\m97_j\Downloads\samples\apparatus.00.in"))
            {
                var info = sr.ReadLine().Split(' ');
                var lights = int.Parse(info[0]);
                var pics = int.Parse(info[1]);
                if (pics == 0)
                {
                    Console.WriteLine(FactorialMod(lights, mod));
                    return;
                }
                var ones = GetOnes(sr);
                if (ones < 0)
                {
                    Console.WriteLine("0");
                    return;
                }
                var minFact = FactorialMod(ones, mod) * FactorialMod(lights - ones, mod);
                //Console.WriteLine(ones);
                //Console.WriteLine(ones << 1);
                //var diff = Math.Abs(lights - (ones << 1));
                //Console.WriteLine(diff);
                for (int i = 1; i < pics; i++)
                {
                    var temp = GetOnes(sr);
                    if (temp != ones)
                    {
                        if (lights - temp != ones)
                        {
                            Console.WriteLine("0");
                            return;
                        }

                    }
                }
                Console.WriteLine(FactorialMod(ones, mod) * FactorialMod(lights - ones, mod));
            }


        }

        static int GetOnes(StreamReader sr)
        {
            var line1 = sr.ReadLine();
            var line2 = sr.ReadLine();
            var ones1 = CountOnes(line1);
            var ones2 = CountOnes(line2);
            if (ones1 != ones2)
            {
                return -1;
            }
            return ones1;
        }

        static int CountOnes(string str)
        {
            var res = 0;
            foreach (var c in str)
            {
                if (c == '1')
                    res++;
            }
            return res;
        }

        static int FactorialMod(int n, int mod)
        {
            int res = 1;
            while (n > 0)
            {
                res = (res * n) % mod;
                n--;
            }
            return res;
        }
    }
}
