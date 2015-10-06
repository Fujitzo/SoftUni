using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractBit3
{
    class ExtractBit3
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());


            int shiftedN = n >> p;
            int mask = 1;

            //Console.WriteLine("Th {0} bit of {1} is {2}", p, Convert.ToString(n,2).PadLeft(16,'0'),shiftedN&mask);

            bool is1 = false;
            int result = shiftedN & mask;
            if ( result == 1)
            {
                is1 = true;
            }
            Console.WriteLine(is1);



        }
    }
}
