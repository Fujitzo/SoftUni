using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractEmails
{
    class ExtractEmails
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(^\w+(?:[.-]\w+)*@\w+(?:[.-]\w+)*\.\w{2,})";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            Console.WriteLine("Matches Found {0}", matches.Count);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[0]);
            }



        }
    }
}
