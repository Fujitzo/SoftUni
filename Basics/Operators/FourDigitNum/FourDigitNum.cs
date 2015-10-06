using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourDigitNum
{
    class FourDigitNum
    {
        static void Main(string[] args)
        {

            int abcd = int.Parse(Console.ReadLine());

            int d = abcd % 10;
            int c = abcd / 10 % 10;
            int b = abcd / 100 % 10;
            int a = abcd / 1000 % 10;

            string a1 = Convert.ToString(a);
            string b1 = Convert.ToString(b);
            string c1 = Convert.ToString(c);
            string d1 = Convert.ToString(d);

            Console.WriteLine("Sum of digits{0}", a+b+c+d);
            Console.WriteLine("Reverse {0}", d1+c1+b1+a1 );
            Console.WriteLine("Last digit in first position {0}", d1+a1+b1+c1);
            Console.WriteLine("2nd and 3rd exchanged {0}", a1+c1+b1+d1);
           
            



        }
    }
}
