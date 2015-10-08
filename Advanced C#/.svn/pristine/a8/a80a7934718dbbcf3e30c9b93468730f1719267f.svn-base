using System;
using System.Collections.Generic;

class StringMatrixRotation
{
    static void Main()
    {
        string[] inputTokens = Console.ReadLine().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        int degrees = int.Parse(inputTokens[1]) % 360;

        int bestLength = int.MinValue;
        Queue<string> elements = new Queue<string>();
        string currentElement = Console.ReadLine();
        while (!String.IsNullOrEmpty(currentElement))
        {
            elements.Enqueue(currentElement);
            if (currentElement.Length > bestLength)
            {
                bestLength = currentElement.Length;
            }
            currentElement = Console.ReadLine();
        }

        char[,] matrix = new char[elements.Count, bestLength];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            currentElement = elements.Dequeue().PadRight(bestLength, ' ');
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currentElement[col];
            }
        }

        if (degrees == 90)
        {
            char[,] rotatedMatrix = new char[matrix.GetLength(1), matrix.GetLength(0)];

            for (int row = 0; row < rotatedMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < rotatedMatrix.GetLength(1); col++)
                {
                    rotatedMatrix[row, col] = matrix[matrix.GetLength(0) - col - 1, row];
                }
            }
            PrintMatrix(rotatedMatrix);
        }
        else if (degrees == 180)
        {
            char[,] rotatedMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];

            for (int row = 0; row < rotatedMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < rotatedMatrix.GetLength(1); col++)
                {
                    rotatedMatrix[row, col] = matrix[matrix.GetLength(0) - row - 1, matrix.GetLength(1) - col - 1];
                }
            }
            PrintMatrix(rotatedMatrix);
        }
        else if (degrees == 270)
        {
            char[,] rotatedMatrix = new char[matrix.GetLength(1), matrix.GetLength(0)];

            for (int col = 0; col < rotatedMatrix.GetLength(1); col++)
            {
                for (int row = 0; row < rotatedMatrix.GetLength(0); row++)
                {
                    rotatedMatrix[row, col] = matrix[col, matrix.GetLength(1) - row - 1];
                }
            }
            PrintMatrix(rotatedMatrix);
        }
        else if (degrees == 0)
        {
            PrintMatrix(matrix);
        }
    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
