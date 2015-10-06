using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation
{
    class QuadraticEquation
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());


            double sqrpart = b * b - 4 * a * c;

            double root1 = (-b + Math.Sqrt(sqrpart)) / (2 * a);
            double root2 = (-b - Math.Sqrt(sqrpart)) / (2 * a);
            if (sqrpart < 0)
            {
                Console.WriteLine("No real roots");
            }
            else
                Console.WriteLine("X1 = {0}, X2 = {1}", root1, root2);
 

            




        }
    }
}
