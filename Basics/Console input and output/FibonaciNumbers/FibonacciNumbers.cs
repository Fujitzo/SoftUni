using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonaciNumbers
{
    class FibonacciNumbers
    {
        static void Main(string[] args)
        {

            
            int n = int.Parse(Console.ReadLine());
            int[] fibonaci = new int[n];
            
            
            for (int i = 0; i < fibonaci.Length; i++)
            {
                if (i == 0)
                {
                    fibonaci[i] = 0;
                }
                else if (i == 1)
                {
                    fibonaci[i] = 1;

                }
                else if (i == 2)
                {
                    fibonaci[i] = 1;

                }
                else
                fibonaci[i] = (fibonaci[i - 2]) + (fibonaci[i - 1]);
                Console.Write("{0}{1}", fibonaci[i]," ");
            }
            

          
        }
    }
}
