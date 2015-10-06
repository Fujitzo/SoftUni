using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangles
{
    class Rectangles
    {
        static void Main(string[] args)
        {
            double height = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            Console.WriteLine("The perimiter of the rectangular is {0}", height*2 + width*2);
            Console.WriteLine("The area of the rectangular is {0}", height * width);
        }
    }
}
