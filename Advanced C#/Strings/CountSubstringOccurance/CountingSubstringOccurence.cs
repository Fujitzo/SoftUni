using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSubstringOccurance
{
    class CountingSubstringOccurence
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine().ToLower();
            string searchTerm = Console.ReadLine().ToLower();
            int inputLength = input.Length;
            
            int count = 0;

            for (int i = 0; i < inputLength; i++)
            {
                int index = input.IndexOf(searchTerm);
                if (index != -1)
                {
                    input = input.Substring(index+1);
                    count++;
                }
                
            }


            Console.WriteLine(count);





        }
    }
}
