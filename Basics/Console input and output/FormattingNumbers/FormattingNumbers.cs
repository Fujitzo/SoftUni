using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattingNumbers
{
    class FormattingNumbers
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            string binA = Convert.ToString(a, 2);
            float b = float.Parse(Console.ReadLine());
            float c = float.Parse(Console.ReadLine());

                     Console.WriteLine("|{0,-10:X}|{1}|{2,10:0.00}|{3,-10:0.000}|",a,binA.PadLeft(10, '0'),b,c);
           
        }
    }
}
