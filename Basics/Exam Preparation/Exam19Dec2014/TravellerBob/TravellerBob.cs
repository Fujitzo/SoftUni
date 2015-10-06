using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellerBob
{
    class TravellerBob
    {
        static void Main(string[] args)
        {
            string leap = Console.ReadLine();
            int c = int.Parse(Console.ReadLine());
            int f = int.Parse(Console.ReadLine());

            int travelsInCMonth = 3 * 4;
            int travelsInFMonth = 2 * 2;
            double travelsInNMonth = 3d / 5d * travelsInCMonth;

            double total = c * travelsInCMonth + f * travelsInFMonth + (12 - c - f) * travelsInNMonth;
            if (leap == "leap")
            { 
            total = total * 1.05;
            }
                
            Console.WriteLine(Math.Floor(total));
           

        }
    }
}
