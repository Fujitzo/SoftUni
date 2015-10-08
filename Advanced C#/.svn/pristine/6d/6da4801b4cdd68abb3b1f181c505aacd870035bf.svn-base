using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFilter
{
    class TextFilter
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(new char[] {',',' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string text = Console.ReadLine();
                       
           for (int j = 0; j < bannedWords.Length; j++)
                {
                    text = text.Replace(bannedWords[j], new string('*', bannedWords[j].Length));
                    
                }

           Console.WriteLine(text);
           

         




        }
    }
}
