using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader(@"C: \Users\m97_j\Downloads\samples\sample.in"))
            {
                var numSets = int.Parse(sr.ReadLine());
                for (int i = 0; i < numSets; i++)
                {
                    var dim = sr.ReadLine().Split(' ');
                    var cols = int.Parse(dim[0]);
                    var rows = int.Parse(dim[1]);
                    var colSum = new int[cols];
                    var rowSum = new int[rows];

                    for (int j = 0; j < rows; j++)
                    {
                        var line = sr.ReadLine().Split(' ');
                        for (int k = 0; k < cols; k++)
                        {
                            var count = int.Parse(line[k]);
                            rowSum[j] += count;
                            colSum[k] += count;
                        }
                    }
                    //Console.WriteLine("cols: " + string.Join(",", colSum));
                    //Console.WriteLine("rows: " + string.Join(",", rowSum));

                    var min = int.MaxValue;
                    var index = 0;
                    for (int j = 0; j < rows; j++)
                    {
                        var sum = 0;
                        for (int k = 0; k < rows; k++)
                        {
                            sum += rowSum[k] * Math.Abs(j - k);
                        }

                        if (sum < min)
                        {
                            min = sum;
                            index = j;
                        }
                    }
                    var rowMin = min;
                    //Console.WriteLine(index + ": " + min);
                    min = int.MaxValue;
                    for (int j = 0; j < cols; j++)
                    {
                        var sum = 0;
                        for (int k = 0; k < cols; k++)
                        {
                            sum += colSum[k] * Math.Abs(j - k);
                        }

                        if (sum < min)
                        {
                            min = sum;
                            index = j;
                        }
                    }
                    //Console.WriteLine(index + ": " + min);
                    Console.WriteLine(min + rowMin);
                }
            }
        }
    }
}
