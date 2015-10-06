using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicode_Characters
{
    class UnicodeCharacters
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            foreach (var letter in input)
            {               

                Console.Write("\\u{0}", Convert.ToInt32(letter).ToString("X").PadLeft(4, '0'));
                
            }
            Console.WriteLine();




        }
    }
}
