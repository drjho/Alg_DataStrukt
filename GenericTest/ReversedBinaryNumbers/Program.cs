using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedBinaryNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReverseBinary("13"));
            Console.WriteLine(ReverseBinary("47"));
            Console.WriteLine(ReverseBinary("1000000000"));
            Console.WriteLine(ReverseBinary("1"));
        }

        static ulong ReverseBinary(string str)
        {
            var bin = Convert.ToString(uint.Parse(str), 2);
            //Console.WriteLine(bin);
            var rev = string.Join("", bin.Reverse());
            return Convert.ToUInt32(rev, 2);
        }
    }
}
