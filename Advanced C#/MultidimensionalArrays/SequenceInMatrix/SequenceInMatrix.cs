using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceInMatrix
{
    class SequenceInMatrix
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            string[,] matrix = new string[rows,cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = (Console.ReadLine());
                }
            }

            // Searching for vertical equal elements

            int currentVerticalSameElements = 0;
            int longestVerticalSameElements = 0;
            int bestCol = 0;
            for (int col = 0; col < cols; col++)
            {
                for(int row = 0; row <rows-1; row++)
                {
                    if (matrix[row, col] == matrix[row + 1, col] && matrix[rows-2,col] == matrix[rows-1,col])
                    {
                        currentVerticalSameElements++;
                        
                      
                    }
                }
                if (currentVerticalSameElements > longestVerticalSameElements)
                {
                    longestVerticalSameElements = currentVerticalSameElements;
                    bestCol = col;
                }
            }

            if (longestVerticalSameElements == rows)
            {
                for (int row = 0; row < rows-1; row++)
                {
                    Console.Write("{0}, ", matrix[row, bestCol]);
                }
                Console.Write(matrix[0, bestCol]);
                Console.WriteLine();
            }

            // Searching for horizontal equal elements

            int currentHorizontalSameElements = 0;
            int longestHorizontalSameElements = 0;
            int bestRow = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && matrix[row, cols-2] == matrix[row, cols-1])
                    {
                        currentHorizontalSameElements++;
                    }
                }
                if (currentHorizontalSameElements > longestHorizontalSameElements)
                {
                    longestHorizontalSameElements = currentHorizontalSameElements;
                    bestRow = row;
                }
            }

            if (longestHorizontalSameElements == cols)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    Console.Write("{0}, ", matrix[col, bestRow]);
                }
                Console.Write(matrix[bestRow,0]);
            }

            // Searching for diagonal equal elements. There are a total of 4 longest diagonals in a rectangular matrix
            //- starting from each corner and going in the opposite direction. The length of these diagonals is
            //equal to the shorter side of the rectangular


            int currentDiagonalSameElements = 0;
            int longestDiagonalSameElements = 0;
            int bestRowD = 0;
            int bestColD = 0;

            for (int i = 0; i < Math.Min(rows, cols); i++)
            {
                if (matrix[0, 0] == matrix[0 + i, 0 + i])
                {
                    currentDiagonalSameElements++;
                }
            }
            if (currentDiagonalSameElements > longestDiagonalSameElements)
                {
                    longestDiagonalSameElements = currentDiagonalSameElements;
                    bestRowD = 0;
                    bestColD = 0;
                    

                }
            currentDiagonalSameElements = 0;
            for (int i = 0; i < Math.Min(rows, cols); i++)
            {
                if (matrix[0, cols-1] == matrix[i, cols - i-1])
                {
                    currentDiagonalSameElements++;
                }
            }
            if (currentDiagonalSameElements > longestDiagonalSameElements)
                {
                    longestDiagonalSameElements = currentDiagonalSameElements;
                    bestRowD = 0;
                    bestColD = cols-1;
                    

                }
            currentDiagonalSameElements = 0;
            for (int i = 0; i < Math.Min(rows, cols); i++)
            {
                if (matrix[rows -1, cols- 1] == matrix[rows -i -1, cols - i-1])
                {
                    currentDiagonalSameElements++;
                }
            }
            if (currentDiagonalSameElements > longestDiagonalSameElements)
                {
                    longestDiagonalSameElements = currentDiagonalSameElements;
                    bestRowD = rows-1;
                    bestColD = cols - 1;
                    

                }
            currentDiagonalSameElements = 0;
            for (int i = 0; i < Math.Min(rows, cols); i++)
            {
                if (matrix[rows - 1, 0] == matrix[rows - i - 1, i])
                {
                    currentDiagonalSameElements++;
                }
            }
            if (currentDiagonalSameElements > longestDiagonalSameElements)
            {
                longestDiagonalSameElements = currentDiagonalSameElements;
                bestRowD = rows - 1;
                bestColD = 0;
                
            }
  
            if (longestDiagonalSameElements == Math.Min(rows, cols))
            {
                for (int i = 0; i < Math.Min(rows-1, cols-1); i++)
                {
                    Console.Write("{0}, ", matrix[bestRowD, bestColD]);
                }
                Console.Write(matrix[bestRowD, bestColD]);
                Console.WriteLine();
            }


        }
    }
}
