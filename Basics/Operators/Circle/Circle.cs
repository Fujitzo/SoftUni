using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    class Circle
    {
        static void Main(string[] args)
        {

            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            double r = Math.Sqrt((x * x) + (y * y));

            if (r > 2)

            {
                Console.WriteLine("No");
            }
            else
                Console.WriteLine("Yes");


        }
    }
}
