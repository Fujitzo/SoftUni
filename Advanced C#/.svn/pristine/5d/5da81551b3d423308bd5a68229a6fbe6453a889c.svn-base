using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReplaceTag
{
    class ReplaceTag
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();



            string patternURL = @"<a\s+href=('(?<url>[^']*)'|""(?<url>[^""]*)"")>([^<]*)<\/a>";
            string replacementURL = "[URL href=${url}[/URL]";
            Regex regex = new Regex(patternURL);
            string result = Regex.Replace(input, patternURL, replacementURL);

            Console.WriteLine(result);



        }
    }
}
