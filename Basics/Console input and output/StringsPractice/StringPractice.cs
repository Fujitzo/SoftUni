using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsPractice
{
    class StringPractice
    {
        static void Main(string[] args)
        {


            string allLangs = "C#, Java; HTML, CSS; PHP, SQL";
            string[] langs = allLangs.Split(new char[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var lang in langs)
                Console.WriteLine(lang);
            Console.WriteLine("Langs = " + string.Join(", ", langs));
            Console.WriteLine("  \n\n Software  University  ".Trim());

        }
    }
}
