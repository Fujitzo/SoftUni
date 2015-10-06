using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boat
{
    class Boat
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //sail upper part
            for (int row = 1; row <= n/2; row++ )
            {
                for (int i = 1; i <= n - 2 * row + 1; i++ )
                {
                    Console.Write('.');
                }
                for (int i = 1; i<= 2*row -1; i++)
                {
                Console.Write('*');
                }
                for (int i = 1; i <= n; i++)
                {
                    Console.Write('.');
                }

                Console.WriteLine();
            }

            //sail middle row
            for (int i = 1; i <= 2 * n; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();

            //sail lower part
            for (int row = 1; row <= n / 2; row++)
            {
                for (int i = 1; i <= 2 * row; i++)
                {
                    Console.Write('.');
                }
                for (int i = 1; i <= n - 2 * row; i++)
                {
                    Console.Write('*');
                }
                for (int i = 1; i <= n; i++)
                {
                    Console.Write('.');
                }

                Console.WriteLine();
            }
            
            //fuselage top row
            for (int i = 1; i <= 2 * n; i++ )
            {
                Console.Write('*');
            }
            Console.WriteLine();
            //fuselage body
            for (int row = 1; row <= (n-2) / 2; row++)
            {
                for (int i = 1; i <= row; i++)
                {
                    Console.Write('.');
                }
                for (int i = 1; i <= (2*n) - (2 * row); i++)
                {
                    Console.Write('*');
                }
                for (int i = 1; i <= row; i++)
                {
                    Console.Write('.');
                }
                Console.WriteLine();
            }



        }
    }
}
