using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingHours
{
    class WorkingHours
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine()); // h - hours required
            int d = int.Parse(Console.ReadLine()); // d - days available
            int p = int.Parse(Console.ReadLine()); // p - productivity (%)


            double workdays = d - 0.1*d;
            double workhours = Math.Floor(workdays*12*p/100d);
             

            if (workhours < h)
            {
                Console.WriteLine("No");
                Console.WriteLine("{0}", workhours - h);
            }
            else
                Console.WriteLine("Yes");
                Console.WriteLine("{0}", workhours - h);



        }
    }
}
