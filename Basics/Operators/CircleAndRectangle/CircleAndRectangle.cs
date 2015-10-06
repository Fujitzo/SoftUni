using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleAndRectangle
{
    class CircleAndRectangle
    {
        static void Main(string[] args)
        {
             
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            bool inCircle = false;
            bool inRect = false;

            double distancetoCenter = Math.Sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1));
            if (distancetoCenter <= 1.5)
            {
                inCircle = true;
            }

            if (x < -1 || x > 1 || y < -1 || y > 5)
            {
                inRect = false;
            }

            Console.WriteLine(inCircle == true && inRect == false?"yes":"No"); 
            
        }
    }
}
