using System;
class MaximalSum
{
    static void Main()
    {
        string[] rowsAndColsInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int rows = int.Parse(rowsAndColsInput[0]) + 1;
        int cols = int.Parse(rowsAndColsInput[1]) + 1;
        int[,] matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            string[] currentRowNumbersAsStrings =
                        Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = int.Parse(currentRowNumbersAsStrings[col]);
            }
        }

        int bestSum = int.MinValue;
        int currentSum = 0;
        int[,] elementsWithMaxSum = new int[3, 3];
        for (int row = 0; row < rows - 2; row++)
        {
            for (int col = 0; col < cols - 2; col++)
            {
                currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                             matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                             matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                    for (int i = 0; i < elementsWithMaxSum.GetLength(0); i++)
                    {
                        for (int j = 0; j < elementsWithMaxSum.GetLength(1); j++)
                        {
                            elementsWithMaxSum[i, j] = matrix[row + i, col + j];
                        }
                    }
                }
            }
        }

        Console.WriteLine("Sum = {0}", bestSum);
        for (int row = 0; row < elementsWithMaxSum.GetLength(0); row++)
        {
            for (int col = 0; col < elementsWithMaxSum.GetLength(1); col++)
            {
                Console.Write("{0,2} ", elementsWithMaxSum[row, col]);
            }
            Console.WriteLine();
        }
    }
}