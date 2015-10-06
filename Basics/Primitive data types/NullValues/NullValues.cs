using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullValues
{
    class NullValues
    {
        static void Main(string[] args)
        {

            int a = 0;
            double b = 0;

            a = 5;
            b = 6.0d;

            Console.WriteLine("{0}{1}\n{2}{3}" ,a ,a.GetTypeCode(),b,b.GetTypeCode());

            string a1 = Convert.ToString(a);
            string b1 = Convert.ToString(b);
            a1 = null;
            b1 = null;

            Console.WriteLine("{}{}",a1, b1 );


        }
    }
}
