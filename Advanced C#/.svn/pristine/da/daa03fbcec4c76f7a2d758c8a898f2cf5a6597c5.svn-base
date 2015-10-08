using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Increasing_Sequence
{
    class LongestIncreasingSequence
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> temp = new List<int>();
            List<int> longest = new List<int>();

            temp.Add(numbers[0]);
            Console.Write(numbers[0]+" ");

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    temp.Add(numbers[i]);
                    Console.Write("{0} ", numbers[i]);
                    if (i == numbers.Length - 1 && temp.Count > longest.Count)
                    {
                        longest.Clear();
                        longest.InsertRange(0, temp);
                    }
                }
                else
                {
                    if (temp.Count > longest.Count)
                    {
                        longest.Clear();
                        longest.InsertRange(0, temp);
                    }
                    temp.Clear();
                    temp.Add(numbers[i]);
                    Console.WriteLine();
                    Console.Write("{0} ", numbers[i]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Longest: {0}", string.Join(" ", longest));
        }
    }
}
