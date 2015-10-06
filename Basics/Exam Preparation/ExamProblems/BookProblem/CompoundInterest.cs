using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProblem
{
    class CompoundInterest
    {
        static void Main(string[] args)
        {
            int p = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            double i = double.Parse(Console.ReadLine());
            double f = double.Parse(Console.ReadLine());

            double FVbank = p * Math.Pow((1 + i), n);
            double FVfriend = p*(1+f);

            if (FVbank < FVfriend)
            {
                Console.WriteLine("{0:0.00} Bank", FVbank);
            }
            else
            {
                Console.WriteLine("{0:0.00} Friend", FVfriend);
            }






        }
    }
}
