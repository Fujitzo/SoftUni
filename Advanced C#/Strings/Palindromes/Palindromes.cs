using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes
{
    class Palindromes
    {
        static void Main(string[] args)
        {

            string[] text = Console.ReadLine().Split(new char[] { ',', ' ', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            SortedSet<string> palindromes = new SortedSet<string>();

            foreach (string word in text)
            {
                int count = 0;
                for (int i = 0; i<word.Length/2; i++)
                {
                    if (word[i] == word[word.Length - 1 - i])
                    {
                        count++;
                    }                                
                }
                if (count == word.Length / 2)
                {
                    palindromes.Add(word);
                }
            }

            Console.WriteLine(String.Join(", ", palindromes));
        }
    }
}
