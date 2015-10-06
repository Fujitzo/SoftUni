using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunglasses
{
    class Sunglasses
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter odd number");
            int n = int.Parse(Console.ReadLine());

            string frame = "*";
            string glass = "/";
            string bridge = "|";
            string space = " ";

            //first row

            for (int i = 0; i < 2*n; i++ )
            {
                Console.Write(frame);

            }
            for (int i = 0; i < n; i++)
                {                             
                   Console.Write(space);
                }
                
            for (int i = 0; i < 2*n; i++)
                {
                    Console.Write(frame); 
                }

           // middle rows 

            Console.WriteLine();
            
            for (int j = 0; j < n - 2; j++)
            {
                
                
                Console.Write(frame);

                
                for (int i = 0; i < (2*n)-2; i++)
                {
                    Console.Write(glass);
                }
                                            
                Console.Write(frame);

                if (j==n/2-1)
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write(bridge);
                    }
                }
                else
                
                    for (int i = 0; i < n; i++)
                
                    {
                        Console.Write(space);
                    }
                Console.Write(frame);


                for (int i = 0; i < (2 * n) - 2; i++)
                {
                    Console.Write(glass);
                }

                Console.Write(frame);
                Console.WriteLine();
   
                
               
            }
            // last row
            for (int i = 0; i < 2 * n; i++)
            {
                Console.Write(frame);

            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(space);
            }

            for (int i = 0; i < 2 * n; i++)
            {
                Console.Write(frame);
            }


             
        }
    }
}
