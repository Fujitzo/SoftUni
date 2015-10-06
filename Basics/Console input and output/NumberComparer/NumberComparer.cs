using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberComparer
{
    class NumberComparer
    {
        static void Main(string[] args)
        {

            float a = float.Parse(Console.ReadLine());
            float b = float.Parse(Console.ReadLine());

            Console.WriteLine("Greater number is:{0}", Math.Max(a,b));

        }
    }
}
