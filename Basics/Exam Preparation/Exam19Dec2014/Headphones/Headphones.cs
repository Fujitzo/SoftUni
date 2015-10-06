using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Headphones
{
    class Headphones
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //top row

            for (int i = 0; i < n / 2; i++)
            {
                Console.Write('-');
            }
            for (int i = 0; i < n+2 ; i++)
            {
                Console.Write('*');
            }
            for (int i = 0; i < n / 2; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
            //upper stays

            for (int row = 0; row < n-1; row++)
            {
                for (int i = 0; i < n / 2; i++)
                {
                    Console.Write('-');
                }
                Console.Write('*');
                for (int i = 0; i < n; i++)
                {
                    Console.Write('-');
                }
                Console.Write('*');
                for (int i = 0; i < n / 2; i++)
                {
                    Console.Write('-');
                }
                Console.WriteLine();
            }

            // upper body
            for (int row = 1; row <= n/2+1 ; row++)
            {
                for (int i = 0; i < n /2 - row+1; i++)
                {
                    Console.Write('-');
                }
                for (int i = 0; i <2*row-1 ; i++)
                {
                    Console.Write('*');
                }
                for (int i = 0; i < 2*(n / 2 - row)+2 + 1; i++)
                {
                    Console.Write('-');
                }
                for (int i = 0; i < 2 * row - 1; i++)
                {
                    Console.Write('*');
                }
                for (int i = 0; i < n / 2 - row+1; i++)
                {
                    Console.Write('-');
                }
                Console.WriteLine();
            
            } 
            // lower body
            for (int row = 1; row <= n / 2; row++)
            {
                for (int i = 0; i < row; i++)
                {
                    Console.Write('-');
                }
                for (int i = 0; i < n - 2*row; i++)
                {
                    Console.Write('*');
                }
                for (int i = 0; i < row*2 + 1; i++)
                {
                    Console.Write('-');
                }
                for (int i = 0; i < n - 2 * row; i++)
                {
                    Console.Write('*');
                }
                for (int i = 0; i < row; i++)
                {
                    Console.Write('-');
                }
                Console.WriteLine();

            } 









        }
    }
}
