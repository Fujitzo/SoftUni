using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sumof3numbers
{
    class SumOf3Numbers
    {
        static void Main(string[] args)
        {

            float a = float.Parse(Console.ReadLine());
            float b = float.Parse(Console.ReadLine());
            float c = float.Parse(Console.ReadLine());

            Console.WriteLine("The sum is: {0}", a+b+c);
        }
    }
}
