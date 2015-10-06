using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfSum
{
    class HalfSum
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the numbers count in each group:");
            int n = int.Parse(Console.ReadLine());


            Console.WriteLine("Now, please enter the numbers themselves, each on a new line");

            int[] firstHalf = new int[n];
            int[] secondHalf = new int[n];

            for (int i = 0; i < firstHalf.Length; i++)

            { 
                firstHalf[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < secondHalf.Length; i++)
            {
                secondHalf[i] = int.Parse(Console.ReadLine());
            } 

            if (firstHalf.Sum() ==secondHalf.Sum())
            {
                Console.WriteLine("Yes, the sum is {0}", firstHalf.Sum()); 
            }
            else
                //double diff = Convert.ToInt32(Math.Abs(firstHalf.Sum()-secondHalf.Sum()));

                Console.WriteLine("No, the diff is {0}" , Math.Abs(firstHalf.Sum()-secondHalf.Sum()));










        }
    }
}
