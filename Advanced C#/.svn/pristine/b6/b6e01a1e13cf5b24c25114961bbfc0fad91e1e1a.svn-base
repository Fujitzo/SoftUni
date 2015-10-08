using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences_of_Equal_Strings
{
    class SequencesOfEqualStrings
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().Select(Convert.ToString).ToArray();

            for (int i = 0; i < words.Length - 1; i++)
            {

                if (words[i] == words[i + 1])
                {
                    Console.Write("{0} ", words[i]);

                }
                else
                    Console.WriteLine(words[i]);


            }
            if (words.Last() == words[words.Length - 1])
            {
                Console.Write(words.Last());
            }
            else
                Console.WriteLine(words.Last());
            Console.WriteLine();

        }
    }
}
