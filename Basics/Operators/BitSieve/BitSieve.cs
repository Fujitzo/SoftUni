using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitSieve
{
    class BitSieve
    {
        static void Main(string[] args)
        {
            long bits = long.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            
            for (int i = 0; i < n; i++)
            {
                long sieve = long.Parse(Console.ReadLine());
                bits = bits & ~sieve;

            }
            int count=1;
            int bitlength = Convert.ToString(bits, 2).Length;
            Console.WriteLine(Convert.ToString(bits, 2));
            for (int k = 0; k < bitlength; k++)
                
                    {
                        bits = bits >> k;
                        long values = bits & 1;
                        if (values == 1)
                        {
                            
                            count++;
                            
                        }
           
                    }
            Console.WriteLine(count);
            Console.WriteLine(bitlength);
                }
        
            }
        }



