using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorize_Numbers
{
    class CategorizeNumbers
    {
        static void Main(string[] args)
        {
            float[] numbers = Console.ReadLine().Split().Select(float.Parse).ToArray();

            List<float> wholeNumbers = new List<float>();
            List<float> decimalNumbers = new List<float>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 1 == 0)
                {
                    wholeNumbers.Add(numbers[i]);
                }
                else
                {
                    decimalNumbers.Add(numbers[i]);
                }
            }

            Console.WriteLine("[{0}] Min: {1}, Max: {2}, Sum: {3}, Avg: {4}", string.Join(", ", decimalNumbers), decimalNumbers.Min(), decimalNumbers.Max(),decimalNumbers.Sum(), Math.Round(decimalNumbers.Average(), 2));
            Console.WriteLine();
            Console.WriteLine("[{0}] Min: {1}, Max: {2}, Sum: {3}, Avg: {4}", string.Join(", ", wholeNumbers), wholeNumbers.Min(),wholeNumbers.Max(),wholeNumbers.Sum(), Math.Round(wholeNumbers.Average(), 2));
            

            //while (true)
            //{ 
            // float a = float.Parse(Console.ReadLine());
            //if (a%1==0)
            //    Console.WriteLine("whole");
            //else
            //    Console.WriteLine("decimal");
            //}
           

        }
    }
}
