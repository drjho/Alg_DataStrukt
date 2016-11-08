using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05BinarySearchTree.Tree;

namespace _05BinarySearchTree
{
    class Program
    {
        const int defaultSize = 5000;

        static void Main(string[] args)
        {
            Console.WriteLine("Run sortedPrint?");
            if (Console.ReadLine().ToLowerInvariant() == "y")
                SortedPrint();

            Console.WriteLine("Generate new addresses?");
            if (Console.ReadLine().ToLowerInvariant() == "y")
            {
                var addressGenerator = new AddressGenerator();
                addressGenerator.GenerateAddresses(defaultSize);
                Console.WriteLine(addressGenerator);
                addressGenerator.SaveToFile("address book.txt");
            }

            Console.WriteLine("Import addresses?");
            if (Console.ReadLine().ToLowerInvariant() == "y")
            {
                var addressBook = new AddressBook();
                addressBook.ImportFromFile("address book.txt");
                Console.WriteLine("count: " + addressBook.Book.ExplicitCount());
                Console.WriteLine("Print addresses?");
                var input = Console.ReadLine().ToLowerInvariant();
                if (input == "yes")
                {
                    addressBook.Print();
                }
                else if (input.Length == 1)
                {
                    if (char.IsLetter(input[0]))
                    {

                        var filtered = addressBook.GetContactStartsWith(input);
                        filtered.Print(10);
                    }
                }

            }


        }


        static void SortedPrint()
        {
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'y', 'å', 'ä', 'ö' };
            Dictionary<string, int> dict;
            try
            {
                using (StreamReader reader = new StreamReader("ordlista.txt", Encoding.Default))
                {
                    dict = new Dictionary<string, int>();
                    string line;
                    Stopwatch w = Stopwatch.StartNew();
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        dict.Add(line, line.Count(c => vowels.Contains(c)));
                    }
                    w.Stop();
                    Console.WriteLine($"Time: {w.ElapsedMilliseconds}  ms");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("file not found");
                return;
            }



            if (dict != null)
            {
                var words = dict.Keys.ToList();
                words.Sort();
                Console.WriteLine(String.Join("\n", words));
            }
        }
    }
}
