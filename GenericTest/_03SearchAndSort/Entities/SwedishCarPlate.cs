using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03SearchAndSort.Entities
{
    public class SwedishCarPlate
    {
        static Random random = new Random();

        public string Letters { get; set; }

        public string Numbers { get; set; }

        public string CarPlate => Letters + " " + Numbers;

        public SwedishCarPlate()
        {
            SetRandomLetters(this);
            SetRandomNumbers(this);
        }


        public static SwedishCarPlate[] GenerateCarPlates(int length)
        {
            var plates = new SwedishCarPlate[length];
            for (int i = 0; i < length; i++)
            {
                plates[i] = new SwedishCarPlate();
            }
            Console.WriteLine($"{length} Swedish car plates generated in a list.");
            return plates;
        }

        public static void SetRandomLetters(SwedishCarPlate plate)
        {
            var str = new StringBuilder(3);
            for (int i = 0; i < 3; i++)
            {
                str.Append((char)random.Next(65, 90));
            }
            plate.Letters = str.ToString();
        }

        public static void SetRandomNumbers(SwedishCarPlate plate)
        {
            var str = new StringBuilder(3);
            for (int i = 0; i < 3; i++)
            {
                str.Append((char)random.Next(48, 57));
            }
            plate.Numbers = str.ToString();
        }

        public static int CompareLetters(SwedishCarPlate plateA, SwedishCarPlate plateB)
        {
            return String.Compare(plateA.Letters, plateB.Letters);
        }

        public static int CompareNumbers(SwedishCarPlate plateA, SwedishCarPlate plateB)
        {
            return String.Compare(plateA.Numbers, plateB.Numbers);
        }

        public static bool IsNumbersOfALessThanB(SwedishCarPlate a, SwedishCarPlate b)
        {
            return CompareNumbers(a, b) < 0;
        }

        public static bool IsLettersOfALessThanB(SwedishCarPlate a, SwedishCarPlate b)
        {
            return CompareLetters(a, b) < 0;
        }

    }
}
