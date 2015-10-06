using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfNNumbers
{
    class SumofNNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers to be summed, when you're done enter something that is not a number");
            double userNumbers = 0;
            double number;
            while (Double.TryParse(Console.ReadLine(), out number))
            {
                userNumbers += number;
            }
            Console.WriteLine(userNumbers);
            Console.ReadKey();


        }
    }
}
