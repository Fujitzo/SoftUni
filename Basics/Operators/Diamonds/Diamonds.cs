using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamonds
{
    class Diamonds
    {
        static void Main(string[] args)
        {
            while (true)
            {

                int n = int.Parse(Console.ReadLine());
                // first row

                for (int i = 0; i < n / 2; i++)
                {
                    Console.Write('-');
                }
                Console.Write('*');
                for (int i = 0; i < n / 2; i++)
                {
                    Console.Write('-');
                }

                // cascade up
                Console.WriteLine();

                for (int row = 1; row < n / 2; row++)
                {
                    for (int i = 0; i < n / 2 - row; i++)
                    {
                        Console.Write('-');
                    }
                    Console.Write('*');
                    for (int i = 1; i <= row * 2 - 1; i++)
                    {
                        Console.Write('-');
                    }
                    Console.Write('*');
                    for (int i = 0; i < n / 2 - row; i++)
                    {
                        Console.Write('-');
                    }
                    Console.WriteLine();
                }

                // middle row

                Console.Write('*');

                for (int i = 0; i < n - 2; i++)
                    Console.Write('-');
                Console.Write('*');

                Console.WriteLine();

                //cascade down

                for (int row = 1; row < n / 2; row++)
                {
                    for (int i = 0; i < row; i++)
                    {
                        Console.Write('-');
                    }
                    Console.Write('*');
                    for (int i = 1; i <= n-2*row-2; i++)
                    {
                        Console.Write('-');
                    }
                    Console.Write('*');
                    for (int i = 0; i < row; i++)
                    {
                        Console.Write('-');
                    }
                    Console.WriteLine();

                }

                //last row

                for (int i = 0; i < n / 2; i++)
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
           
        }       
    }
}
