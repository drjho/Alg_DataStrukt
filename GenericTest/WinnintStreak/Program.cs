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
            var inputs = Console.ReadLine().Split(' ');
            var matches = int.Parse(inputs[0]);
            var winP = float.Parse(inputs[1], CultureInfo.InvariantCulture);
            var p = GetProbs(matches, winP);
            Console.WriteLine(string.Join(" ", p));
            var m = GetProbMatches(matches);
            float res = 0;
            for (int i = 0; i < matches; i++)
            {
                res += m[i] * p[i] * i;
                Console.WriteLine(m[i] + " " + p[i] + " " + i);
            }
            Console.WriteLine(res);
        }

        static int[] GetProbMatches(int matches)
        {
            var arr = new int[matches + 1];
            for (int i = matches; i >= arr.Length/2; i--)
            {
                int f = 1;
                for (int j = matches; j > i; j--)
                {
                    f *= j;
                }
                arr[i] = f;
                arr[matches - i] = f;
            }
            
            Console.WriteLine(string.Join(" ", arr));
            return arr;
        }

        static float[] GetProbs(int matches, float winP)
        {
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
