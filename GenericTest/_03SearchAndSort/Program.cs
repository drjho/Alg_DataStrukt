﻿using System;
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
            SearchAlgorithms.BenchmarkSearch(100000, (int)Math.Pow(2, 10));
            SearchAlgorithms.BenchmarkSearch(100000, (int)Math.Pow(2, 11));
            SearchAlgorithms.BenchmarkSearch(100000, (int)Math.Pow(2, 12));
            SearchAlgorithms.BenchmarkSearch(100000, (int)Math.Pow(2, 13));
            SearchAlgorithms.BenchmarkSearch(100000, (int)Math.Pow(2, 14));
            SearchAlgorithms.BenchmarkSearch(100000, (int)Math.Pow(2, 15));
            Console.WriteLine("Press Q to quit or any othe key to continue...");
            if (Console.ReadKey().Key == ConsoleKey.Q)
                return;

            //new SearchSortLabb();
            var plates = SwedishCarPlate.GenerateCarPlates((int)Math.Pow(2, 13));
            //var plates = SwedishCarPlate.GenerateCarPlates(5);

            //foreach (var item in plates)
            //{
            //    Console.WriteLine(item.CarPlate);
            //}

            //SortAlgorithm.BubbleSort<SwedishCarPlate>(plates, SwedishCarPlate.IsLettersOfALessThanB);
            //var letterSorted = (SwedishCarPlate[]) plates.Clone();

            //foreach (var item in letterSorted)
            //{
            //    Console.WriteLine(item.CarPlate);
            //}

            SortAlgorithm.BubbleSort<SwedishCarPlate>(plates, SwedishCarPlate.IsNumbersOfALessThanB);
            //var numberSorted = (SwedishCarPlate[])plates.Clone();

            //foreach (var item in numberSorted)
            //{
            //    Console.WriteLine(item.CarPlate);
            //}

            //Console.Write("Search Letters:");
            //var input = Console.ReadLine();

            //var position = SearchAlgorithms.BinarySearch<SwedishCarPlate>(letterSorted, new SwedishCarPlate { Letters = input }, SwedishCarPlate.CompareLetters);

            //Console.WriteLine("Position: " + position);

            Console.Write("Search Numbers:");
            var input = Console.ReadLine();

            var position = SearchAlgorithms.BinarySearch<SwedishCarPlate>(plates, new SwedishCarPlate { Numbers = input }, SwedishCarPlate.CompareNumbers);
            if (position > -1)
            {
                var similarPlates = SearchAlgorithms.RegionGrow<SwedishCarPlate>(plates, position, (a, b) => SwedishCarPlate.CompareNumbers(a, b) == 0);
                Console.WriteLine("Position: " + position + " -> " + plates[position].CarPlate);
                Console.WriteLine(String.Join(", ", similarPlates.Select(a => a.CarPlate)));

            }
        }

    }
}
