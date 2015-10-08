using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheMatrix
{
    class FillTheMatrix
    {
        static void Main(string[] args)
        {
            int[,] matrix1 = new int[4,4];
            int[,] matrix2 = new int[4, 4];
            int num = 1;

            Console.WriteLine("Matrix1");
            Console.WriteLine();

            for (int col = 0; col < 4; col++ )
            {
                for (int row = 0; row < 4; row++)
                {
                    matrix1[row, col] = num++;
                 }
            }

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.Write("{0} ", matrix1[row, col]);
                }
                    Console.WriteLine();
            }
            
            Console.WriteLine();
            Console.WriteLine("Matrix2");
            Console.WriteLine();

            num = 1;

            for (int col = 0; col < 4; col++)
            {
                if (col%2 ==0)
                {
                    for (int row = 0; row < 4; row++)
                     {
                        matrix2[row, col] = num++;
                     }
                }
                else
                {
                    for (int row = 3; row >= 0; row--)
                    {
                        matrix2[row, col] = num++;
                    }
                }

            }

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.Write("{0} ", matrix2[row, col]);
                }
                Console.WriteLine();
            }
     
        }
    }
}
