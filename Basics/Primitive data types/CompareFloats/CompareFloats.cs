using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareFloats
{
    class CompareFloats
    {
        static void Main(string[] args)
        {
            double numA = -4.999999;
            double numB = -4.999998;
            double eps = 0.000001;

            double difference = numA - numB;
            difference = Math.Abs(difference);

            //bool result = (difference < eps);
            //Console.WriteLine(result);

            //second variant:

            if (difference > eps)
            {
                Console.WriteLine("The numbers are not equal");
            }
            else
            {   
                Console.WriteLine("The numbers are equal");
            }
        }
    }
}
