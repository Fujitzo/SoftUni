using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class VolleyBall
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Leap year ? Please enter leap or normal");
            string leapY = Console.ReadLine();
            double p = double.Parse(Console.ReadLine());  //holidays
            double h = double.Parse(Console.ReadLine());  //home town

            double playNumber = 2d / 3d * p + (48 - h) * 3d / 4d + h;
            if (leapY == "leap")
            {
                playNumber = playNumber * 1.15;
            }

            Console.WriteLine((int)Math.Floor(playNumber));


        }
    }
}
