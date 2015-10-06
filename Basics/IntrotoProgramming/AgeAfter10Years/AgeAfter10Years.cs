using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeAfter10Years
{
    class AgeAfter10Years
    {
        static void Main()
        {
            Console.WriteLine("please enter your birthday in the dd.mm.yyyy format:");

            DateTime birthday = DateTime.Parse(Console.ReadLine());
            TimeSpan period = DateTime.Now.Subtract(birthday);  // period is in the "timespan" format
            long periodInSeconds = period.Ticks;
            
            Console.WriteLine("Your age in seconds is {0}", periodInSeconds);
            
            int age = new DateTime(periodInSeconds).Year-1;
       

            Console.WriteLine("you are {0} years old", age);
            Console.WriteLine("your age after 10 years will be {0}", age + 10);
        }
    }
}

