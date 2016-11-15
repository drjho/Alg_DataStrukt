using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinnintStreak
{
    class Program
    {


        static void Main(string[] args)
        {
            // inputs
            var inputs = Console.ReadLine().Split(' ');
            var matches = int.Parse(inputs[0]);
            var winP = float.Parse(inputs[1], CultureInfo.InvariantCulture);
            var p = GetProbs(matches, winP);
            Console.WriteLine(string.Join(" ", p));

            // calculation
            var m = GetProbMatches(matches);
            float res = 0;
            for (int i = 0; i < matches; i++)
            {
                if (i > 1) // when winning more than once
                {
                    Console.WriteLine(i + " here");
                    res += p[i] * i * 2;
                    Console.WriteLine(2 + " " + p[i] + " " + i);

                    var tmp = m[i] - 2;
                    Console.WriteLine("tmp: " + tmp);
                    var limit = Math.Ceiling(tmp / 2f);
                    for (int j = 0; j < limit; j++)
                    {
                        var rst = j + 1;
                        res += p[i] * rst * 2;
                        Console.WriteLine(p[i] + " " + rst);
                    }
                }
                else // win once or less
                {
                    res += m[i] * p[i] * i;
                    Console.WriteLine(m[i] + " " + p[i] + " " + i);
                }
            }
            res += m[matches] * p[matches] * matches;
            // output
            Console.WriteLine(res);
        }

        static int[] GetProbMatches(int matches)
        {
            // how many matches with a certain probablity
            // it is not P(n,k) !!
            var arr = new int[matches + 1];
            for (int i = matches; i >= arr.Length / 2; i--)
            {
                int f = 1;
                for (int j = matches; j > i; j--)
                {
                    f *= j;
                }
                if (i < matches - 1)
                    f /= 2;
                arr[i] = f; 
                arr[matches - i] = f;
            }
            //if (matches % 2 == 0)
            //{
            //    arr[arr.Length / 2] /= 2;
            //}
            Console.WriteLine(string.Join(" ", arr));
            return arr;
        }

        static float[] GetProbs(int matches, float winP)
        {
            // probabiliy: from all lost to all win
            var probs = new float[matches + 1];
            for (int i = 0; i <= matches; i++)
            {
                float p = 1;
                for (int j = 0; j < i; j++)
                {
                    p *= winP;
                }
                float lostP = 1 - winP;
                for (int k = i; k < matches; k++)
                {
                    p *= lostP;
                }
                probs[i] = p;
            }
            return probs;
        }
    }
}
