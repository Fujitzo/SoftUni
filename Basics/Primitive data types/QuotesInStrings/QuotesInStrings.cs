using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesInStrings
{
    class QuotesInStrings
    {
        static void Main(string[] args)
        {

            string quote1 = "The \"use\" of quotations causes difficulties.";
            string quote2 = @"The ""use"" of quotations causes difficulties.";

            Console.WriteLine(quote1);
            Console.WriteLine(quote2);
        }
    }
}
