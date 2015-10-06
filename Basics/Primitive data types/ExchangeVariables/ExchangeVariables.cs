using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeVariables
{
    class ExchangeVariables
    {
        static void Main(string[] args)
        {

            int a = 5;
            int b = 10;
            Console.WriteLine("The values before exchange are: {0} and {1}", a,b);

            int c = a;
            int d = b;
            a = d;
            b = c;        
               

            Console.WriteLine("The values after exchange are: {0} and {1}", a,b);

        }
    }
}
