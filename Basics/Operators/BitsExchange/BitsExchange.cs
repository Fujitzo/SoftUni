using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsExchange
{
    class BitsExchange
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter number to be transformed");
                long n = long.Parse(Console.ReadLine());
                Console.WriteLine("Enter range1 start position");
                int p = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter range2 start position");
                int q = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter range length");
                int k = int.Parse(Console.ReadLine()); 

                if (p + k > 32 || q + k > 32)
                    Console.WriteLine("Out of range");
                else if ((p + q) <= k)
                    Console.WriteLine("Overlapping");                
                else if (p < 0 || q < 0 || k < 0)
                    Console.WriteLine("Invalid input, please enter p, q and k > 0");
                else
                {   // Reading P and Q range values (0 or 1)
                    for (int i = 0; i <= k - 1; i++)
                    {
                        long maskP = 1 << p + i;
                        long valuesP = (n & maskP) >> (p + i);
                        long maskQ = 1 << q + i;
                        long valuesQ = (n & maskQ) >> (q + i);

                        // checking if value is 0 or 1 and doing the exchange
                        if (valuesP == 1)
                        {
                            n = n | maskQ;
                        }
                        else if (valuesP == 0)
                        {
                            n = n & ~maskQ;
                        }
                        if (valuesQ == 1)
                        {
                            n = n | maskP;
                        }
                        else if (valuesQ == 0)
                        {
                            n = n & ~maskP;
                        }
                    }
                    Console.WriteLine("Modified n: {0} binary: {1}", n, Convert.ToString(n, 2).PadLeft(32, '0'));
                }
                            
                
            }
            

        }
    }
}
