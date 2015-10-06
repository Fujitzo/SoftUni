using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoscelesTriangle
{
    class IsoscelesTriangle
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.Unicode;

            char c = '\u00A9';
            string c1 = Convert.ToString(c);
            string space = " ";


            Console.WriteLine("{0}{0}{0}{1}", space, c1);
            Console.WriteLine("{0}{0}{1}{0}{1}", space, c1);
            Console.WriteLine("{0}{1}{0}{0}{0}{1}", space, c1);
            Console.WriteLine("{1}{0}{1}{0}{1}{0}{1}", space, c1);


            //another way

            //char c = '\u00A9';
            //string c1 = Convert.ToString(c);

            //Console.WriteLine("{0,4}" ,c1);
            //Console.WriteLine("{0,3} {0,1}", c1);
            //Console.WriteLine("{0,2} {0,3}", c1);
            //Console.WriteLine("{0,1} {0,1}{0,2}{0,2}", c1);
            
        }
    }
}
