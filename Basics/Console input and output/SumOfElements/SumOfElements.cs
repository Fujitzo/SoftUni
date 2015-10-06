using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfElements
{
    class SumOfElements
    {
        static void Main(string[] args)
        {

            string[] elements = Console.ReadLine().Split();
            int[] numbers = Array.ConvertAll(elements, int.Parse);

            int maxNum = numbers.Max();
            int sumOfOthers = numbers.Sum() - maxNum;

            if (maxNum == sumOfOthers)

            {
                Console.WriteLine("Yes, sum {0}", maxNum);
            }

            else
            Console.WriteLine("No, diff {0}", Math.Abs(sumOfOthers - maxNum));

        }
    }
}
