using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Is7_2nd_variant
{
    class Program
    {
        static void Main(string[] args)
        {

            string number = Console.ReadLine();

            bool is7 = false;

            char[] charArray = number.ToCharArray();

            int[] intArray = Array.ConvertAll(charArray, c => (int)char.GetNumericValue(c));

                     

            int thirdPosition = number.Length - 3;

            if (intArray[thirdPosition] == 7)

            {
                is7 = true;
            }
            Console.WriteLine(is7);
        }
    }
}
