using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideBy7And5
{
    class DivideBy7And5
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());


            bool IsDivisible = false;
            if (number % 7 == 0 && number % 5 == 0)
            { 
            IsDivisible = true;
            }
                
                Console.WriteLine(IsDivisible);
        }
    }
}
