using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsAndObjects
{
    class StringsAndObjects
    {
        static void Main(string[] args)
        {
            string a = "hello";
            string b = "world";
            object c = a + " " + b;
            string d = Convert.ToString(c);

            Console.WriteLine(d);
        }
    }
}
