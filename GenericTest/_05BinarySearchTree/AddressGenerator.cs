using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05BinarySearchTree
{
    class AddressGenerator
    {
        List<string> firstNamesList;
        List<string> lastNamesList;
        List<string> addressList;
        Random random = new Random();
        const string firstNamesFile = "fornamn.txt";
        const string lastNamesFile = "efternamn.txt";

        public void GenerateAddresses(int amount)
        {
            //Load names
            firstNamesList = ReadNamesFromFile(firstNamesFile);
            lastNamesList = ReadNamesFromFile(lastNamesFile);

            addressList = new List<string>();
            for (int i = 0; i < amount; i++)
            {
                addressList.Add(firstNamesList[random.Next(firstNamesList.Count)]
                    + " " + lastNamesList[random.Next(lastNamesList.Count)]
                    + " | " + GeneratePhoneNumer());
            }
        }

        private List<string> ReadNamesFromFile(string fileName)
        {
            var nameList = new List<string>();
            StreamReader fileStream = new StreamReader(fileName, Encoding.Default);
            string stringLine;
            while ((stringLine = fileStream.ReadLine()) != null)
            {
                string[] wordArray = stringLine.Split(' ');
                foreach (var word in wordArray)
                {
                    if (word != "")
                    {
                        nameList.Add(word);
                    }
                }
            }
            fileStream.Close();
            return nameList;
        }

        private string GeneratePhoneNumer()
        {
            string prefix = "07";
            int number = random.Next(100000000);
            return prefix + number.ToString("00-00 00 00");
        }

        public void SaveToFile(string fileName)
        {
            StreamWriter fileStream = new StreamWriter(fileName);
            foreach (var person in addressList)
            {
                fileStream.WriteLine(person);
            }
            fileStream.Close();
        }

        public override string ToString()
        {
            string str = "";
            foreach (var person in addressList)
            {
                str += person + Environment.NewLine;
            }
            str += "Size: " + addressList.Count;
            return str;

        }
    }
}
