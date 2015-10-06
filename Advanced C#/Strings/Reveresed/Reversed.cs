using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reveresed
{
    class Reversed
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            char[] arr = input.ToCharArray();
            char[] reversed = arr.Reverse().ToArray();

            Console.WriteLine(String.Join("",reversed));

        }
    }
}
