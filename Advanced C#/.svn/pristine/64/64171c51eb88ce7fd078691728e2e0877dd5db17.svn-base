using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            int[] inputRowsCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = inputRowsCols[0];
            int cols = inputRowsCols[1];

            int[,] matrix = new int[rows, cols];


            for (int row = 0; row < rows; row++)
            {
                int[] inputRow = new int[cols];
                string[] inputRowStr = Console.ReadLine().Split();
                for (int i = 0; i < cols; i++)
                {
                    inputRow[i] = Convert.ToInt32(inputRowStr[i]);
                    matrix[row, i] = inputRow[i];
                }

            }

            int sum = int.MinValue;
            int maxSum = int.MinValue;
            int bestRow = 0;
            int bestCol = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (sum >= maxSum)
                    {
                        maxSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Max sum = {0}", maxSum);

            
            for (int row = bestRow; row < bestRow+3; row++)
            {
                for (int col = bestCol; col < bestCol+3; col++)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
