using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            
            SortedDictionary<char, int> dictionary = new SortedDictionary<char, int>();

            foreach (char letter in input)
            {
                if (!dictionary.ContainsKey(letter))
                {
                    dictionary.Add(letter, 1);
                }
                else
                {
                    dictionary[letter]++;
                }
            }

            foreach (var pair in dictionary)
            {
                Console.WriteLine("{0}: {1} time/s", pair.Key, pair.Value );
            }




        }
    }
}
