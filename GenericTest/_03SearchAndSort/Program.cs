using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03SearchAndSort.Entities;
using _03SearchAndSort.Algorithms;

namespace _03SearchAndSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //new SearchSortLabb();
            //var plates = SwedishCarPlate.GenerateCarPlates((int)Math.Pow(2,15));
            var plates = SwedishCarPlate.GenerateCarPlates(5);

            foreach (var item in plates)
            {
                Console.WriteLine(item.CarPlate);
            }

            SortAlgorithm.BubbleSort<SwedishCarPlate>(plates, SwedishCarPlate.CompareLetter);

            foreach (var item in plates)
            {
                Console.WriteLine(item.CarPlate);
            }

            SortAlgorithm.BubbleSort<SwedishCarPlate>(plates, SwedishCarPlate.CompareNumber);

            foreach (var item in plates)
            {
                Console.WriteLine(item.CarPlate);
            }
        }

    }
}
