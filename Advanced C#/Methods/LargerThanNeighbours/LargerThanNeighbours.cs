using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargerThanNeighbours
{
    class LargerThanNeighbours
    {
        static bool IsLargerThanNeighbours(int[] numbers, int i)
        {
            bool IsLarger = false;

            if (i == 0)
            {
                if(numbers[i] > numbers[i+1])
                {
                IsLarger = true;
                }
            }
            if (i == numbers.Length -1)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    IsLarger = true;
                }
            }
            else if (i != 0 && i != numbers.Length)
            {
                if ((numbers[i] > numbers[i - 1]) && (numbers[i] > numbers[i + 1]))
                {
                    IsLarger = true;
                }
            }

            return IsLarger;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers separated by space on a single line");
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(IsLargerThanNeighbours(numbers, i));
            }


        }
    }
}
