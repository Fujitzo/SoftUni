using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumCheck
{
    class PrimeNumCheck
    {
        static void Main(string[] args)
        {


            int num = int.Parse(Console.ReadLine());

            bool isPrime = false;
            if (num == 0 || num == 1 )
            {
                isPrime = false;
            }
            else
            {
            for (int i = 2; i <= num/2; i++ )
            {
                

                if (num % i == 0)
                {
                isPrime = false;
                }
            else
                isPrime = true;
                
            }

            
            
            Console.WriteLine(isPrime);
            }
        }
    }
}
