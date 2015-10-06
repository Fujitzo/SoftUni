using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Length
{
    class StringLength
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < 20; i++ )
            {
                if (i >= input.Length)
                {
                    output.Append('*');
                }
                else
                {
                    output.Append(input[i]);
                }
                
            }
            Console.WriteLine(output);


        }
    }
}
