using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersInInterval
{
    class NumbersInInterval
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter start point n =");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter start point m =");
            
            int m = int.Parse(Console.ReadLine()); 

            int p = 0;

            for (int i = n; i <= m; i++)
            {
                if (i%5==0)
                {
                    p++;
                }
            }
             Console.WriteLine("Between n and m there are {0} numbers that can be devided by 5", p); 


        }
    }
}
