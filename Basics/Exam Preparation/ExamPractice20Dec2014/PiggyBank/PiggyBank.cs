using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiggyBank
{
    class PiggyBank
    {
        static void Main(string[] args)
        {
            int price = int.Parse(Console.ReadLine());
            int partyDays = int.Parse(Console.ReadLine());

            double savedFor1Month = (30 - partyDays) * 2 - partyDays * 5;
            double monthsNeeded = price / savedFor1Month;
            if (monthsNeeded*10 % 10 == 0)
            {
                monthsNeeded = price / savedFor1Month;
            }
                
            else
            {
                monthsNeeded = Math.Floor(monthsNeeded + 1);
            }
            int yearsNeeded = (int)monthsNeeded / 12;
            int monthsinLastY = (int)monthsNeeded % 12;

            if (savedFor1Month <= 0)
            {
                Console.WriteLine("never");
            }
            else
            {
                Console.WriteLine("{0} years, {1} months", yearsNeeded, monthsinLastY);

            }

 

        }
    }
}
