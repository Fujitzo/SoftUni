using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        List<int> tempSequence = new List<int>();
        List<int> longestSequence = new List<int>();

        Console.Write(numbers[0] + " ");
        tempSequence.Add(numbers[0]);
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                tempSequence.Add(numbers[i]);
                Console.Write(numbers[i] + " ");
            }
            else
            {
                if (tempSequence.Count > longestSequence.Count)
                {
                    longestSequence = tempSequence;
                }
                Console.WriteLine();
                tempSequence.Clear();
                tempSequence.Add(numbers[i]);
                Console.Write(numbers[i] + " ");
            }


        }

        Console.WriteLine("\nLongest: {0}", string.Join(" ", longestSequence));
    }
}
