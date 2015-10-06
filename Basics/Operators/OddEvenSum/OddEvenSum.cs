using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddEvenSum
{
    class OddEvenSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arrNum = new int[2*n];

            for (int i = 0; i < 2*n; i++ )
            {
                arrNum[i] = int.Parse(Console.ReadLine());
            }

            int[] arrOdd = new int[n];

            for (int i = 0; i < n; i++ )
            {
                arrOdd[i] = arrNum[2 * i];
            }

            int[] arrEven = new int[n];

            for (int i = 0; i < n; i++)
            {
                arrEven[i] = arrNum[2 * i+1];
            }
            int sumOdd = arrOdd.Sum();
            int sumEven = arrEven.Sum();

            if (sumOdd == sumEven)
            {
                Console.WriteLine("Yes.The sum is {0}", sumEven);
            }
            else
                Console.WriteLine("No, the difference is {0}" , Math.Abs(sumOdd - sumEven));


        }
    }
}
