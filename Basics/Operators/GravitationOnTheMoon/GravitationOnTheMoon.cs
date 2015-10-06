using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitationOnTheMoon
{
    class GravitationOnTheMoon
    {
        static void Main(string[] args)
        {

            double weight = double.Parse(Console.ReadLine());

            double weightOnMoon = weight * 0.17;
            Console.WriteLine("{0:0.00}",weightOnMoon);

        }
    }
}
