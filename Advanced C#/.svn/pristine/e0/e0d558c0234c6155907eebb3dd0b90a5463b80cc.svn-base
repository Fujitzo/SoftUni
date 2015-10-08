using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingArrays_SelectMethod_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++ )
            {
                int minValue = numbers[i]; 
                int temp = 0;
                int jPosition = 0;
                for (int j = i; j<numbers.Length; j++)
                {
                    if (numbers[j] <= minValue)
                    {
                        minValue = numbers[j];
                        jPosition = j;
                    }
                          
                }
                 temp = numbers[i];
                 numbers[i] = minValue;
                 numbers[jPosition] = temp;

            }
            Console.WriteLine(string.Join(" ", numbers));
            
            
        }
    }
}
