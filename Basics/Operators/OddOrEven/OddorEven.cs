using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOrEven
{
    class OddorEven
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            if (n % 2 == 0)
            {
                Console.WriteLine("Even");
            }
            else
                Console.WriteLine("Odd");
        }
    }
}
