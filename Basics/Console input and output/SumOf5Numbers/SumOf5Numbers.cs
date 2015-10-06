using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOf5Numbers
{
    class SumOf5Numbers
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter 5 numbers separated by space in 1 line");
            
            string[] delimitedNum = Console.ReadLine().Split();

            if (delimitedNum.Length != 5)
            {
                Console.WriteLine("You have not entered exactly 5 numbers! Please start over");
            }

            else
            { 
            double[] numbers = Array.ConvertAll(delimitedNum, double.Parse);
            Console.WriteLine(numbers.Sum());
            }
            
            
            
                  
                           
            

            


        }
    }
}
