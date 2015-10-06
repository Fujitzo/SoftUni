using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunlight
{
    class Sun
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            //first row
            for (int i = 0; i < 3 * n / 2; i++)
            { 
                Console.Write('.');
            }
                Console.Write('*');
            for (int i = 0; i < 3 * n / 2; i++)
                { 
                Console.Write('.');
                }
            Console.WriteLine();
                
            //upper rays
            for (int row = 1; row < n; row++)
            {
                for (int i = 1; i <= row; i++)
                { 
                Console.Write('.');
                }
                Console.Write('*');
                for (int i = 1; i <= (3 * n / 2) - row - 1; i++)
                {
                Console.Write('.');
                }
                Console.Write('*');
                for (int i = 1; i <= (3 * n / 2) - row - 1; i++)
                {
                    Console.Write('.');
                }
                Console.Write('*');
                for (int i = 1; i <= row; i++)
                {
                    Console.Write('.');
                }
                Console.WriteLine();
            }
            //upper body
            for (int row = 1; row <= n / 2; row++)
            {
                for (int i = 1; i <= n; i++ )
                {
                    Console.Write('.');
                }
                for (int i = 1; i <= n; i++)
                {
                    Console.Write('*');
                }
                for (int i = 1; i <= n; i++)
                {
                    Console.Write('.');
                }
                    Console.WriteLine();
            }
            //middle row

            for (int i = 1; i <= n * 3; i++)
            {
                Console.Write('*');
            }

            Console.WriteLine();

            //lower body
            for (int row = 1; row <= n / 2; row++)
            {
                for (int i = 1; i <= n; i++)
                {
                    Console.Write('.');
                }
                for (int i = 1; i <= n; i++)
                {
                    Console.Write('*');
                }
                for (int i = 1; i <= n; i++)
                {
                    Console.Write('.');
                }
                Console.WriteLine();
            }

            //lower rays
            for (int row = 0; row < n; row++)
            {
                for (int i = 1; i < n - row; i++)
                {
                    Console.Write('.');
                }
                                                                Console.Write('*');
                for (int i =1; i <= n/2 + row; i++ )
                {
                    Console.Write('.');
                }
                                                                Console.Write('*');
                for (int i = 1; i <= n / 2 + row; i++)
                {
                    Console.Write('.');
                }
                                                                Console.Write('*');
                for (int i = 1; i < n - row; i++)
                {
                    Console.Write('.');
                }
                    Console.WriteLine();
            }

            //last row
            for (int i = 0; i < 3 * n / 2; i++)
            {
                Console.Write('.');
            }
            Console.Write('*');
            for (int i = 0; i < 3 * n / 2; i++)
            {
                Console.Write('.');
            }
            Console.WriteLine();

        }
    }
}
