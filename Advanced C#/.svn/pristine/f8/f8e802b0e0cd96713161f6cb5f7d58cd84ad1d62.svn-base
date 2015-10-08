using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_05
{
    class Program
    {
        static void Main()
        {
            int[] inputElements = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int arrLength = inputElements.Length;
            int longestSequence = 1;
            int testSequenceLength = 1;
            int longestSequenceEndPos = 0;
            List<int> longestSeqReversed = new List<int>();

            for (int i = 0; i < arrLength; i++) // The purpose of this loop is to print the sequences on separate lines and to record the end position of the longest sequence, and its length
            {
                Console.Write(inputElements[i]);
                if (i < inputElements.Length - 1 && (inputElements[i] < inputElements[i + 1]))
                {
                    Console.Write(" ");
                    testSequenceLength++;
                }
                else
                {
                    Console.WriteLine();
                    if (testSequenceLength > longestSequence)
                    {
                        longestSequence = testSequenceLength;
                        longestSequenceEndPos = i;
                    }
                    testSequenceLength = 1;
                }
            }
            Console.Write("Longest: ");
            // Using the data we acquired with the previous loop, we now start from the end of the longest sequence and record its numbers in a list, in a reversed order
            for (int i = longestSequenceEndPos; i > longestSequenceEndPos - longestSequence; i--)
            {
                if (i < 0)
                {
                    break;
                }
                longestSeqReversed.Add(inputElements[i]);

            }
            // We print the list in reversed order, to show the longest sequence in ascending order
            for (int i = longestSeqReversed.Count - 1; i >= 0; i--)
            {
                Console.Write(longestSeqReversed[i] + " ");
            }

        }
    }
}