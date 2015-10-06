using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclePerimeterAndArea
{
    class CirclePerimeterAndArea
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter radius");
            float r = float.Parse(Console.ReadLine());

            Console.WriteLine("Perimeter is {0:0.00}, Area is {1:0.00}", 2*Math.PI*r, Math.PI*r*r);
        }
    }
}
