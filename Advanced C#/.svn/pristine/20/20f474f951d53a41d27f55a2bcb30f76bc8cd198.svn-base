using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Series_of_Letters
{
    class SeriesOfLetters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(\w)\1+";
            string replacement = "$1";

            Regex regex = new Regex(pattern);
            Console.WriteLine(Regex.Replace(input, pattern, replacement));
           


    
        }
    }
}
