using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoroTheFootballPlayer
{
    class JoroTheFootballPlayer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter \"t\" for leap year or \"f\" for non leap year");
            string leap = Console.ReadLine();


            Console.WriteLine("Please enter the number of holidays in the year");
            double p = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the number of weekends that Joro spends in his hometown");
            double  h = int.Parse(Console.ReadLine());

            double plays = p / 2 + 2d / 3d * (52 - h) + h;
                        
            
            //double numberOfPlays1 = (p / 2);
            //double numberOfPlays2 = (2d / 3d);
            //double numberOfPlays3 = h;

            //Console.WriteLine(numberOfPlays1);
            //Console.WriteLine(numberOfPlays2);
            //Console.WriteLine(numberOfPlays3);

            if (leap == "t")
            {
                plays += 3;
            }
            

            int playsInt = Convert.ToInt32(Math.Floor(plays));

            Console.WriteLine("This year Joro will play {0} times footbal", playsInt);


        }
    }
}
