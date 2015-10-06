using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifyBitAtGivenPosition
{
    class ModifyBitAtGivenPosition
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int v = int.Parse(Console.ReadLine());


            if (v==1)

            {
                int mask = 1 << p;
                Console.WriteLine("Modified {0} is {1} | {2}", n, Convert.ToString(n | mask, 2).PadLeft(8, '0'), (int)n | mask);
            }

            if (v == 0)
            {
                int mask = ~(1 << p);
                Console.WriteLine("Modified {0} is {1} | {2}", n, Convert.ToString(n & mask, 2).PadLeft(8, '0'), (int)n & mask);
            }

            else
            {
                Console.WriteLine("The thrid variable should be 0 or 1");
            }

            ;




        }
    }
}
