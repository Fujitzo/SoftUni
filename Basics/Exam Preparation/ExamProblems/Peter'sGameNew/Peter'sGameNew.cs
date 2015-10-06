using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peter_sGame
{
    class Program
    {
        static void Main(string[] args)
        {

            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            string replacementStr = Console.ReadLine();

            int sum = 0;
            for (int i = start; i < end; i++)
            {
                if (i % 5 == 0)
                {
                    sum = sum + i;
                }
                else
                {
                    sum = sum + (i % 5);
                }
            }

            //Console.WriteLine(sum);
            int[] arrSumInt = sum.ToString().Select(i => Convert.ToInt32(i)).ToArray();
            string[] arrSumStr = Array.ConvertAll(arrSumInt, i => i.ToString());
            string lastDigit = arrSumStr.Last();
            string firstDigit = arrSumStr.First();


            if (sum % 2 != 0)
            {
                for (int i = 0; i < arrSumStr.Length; i++)
                {

                    if (arrSumStr[i] == lastDigit)
                    {
                        arrSumStr[i] = replacementStr;
                        Console.Write(arrSumStr[i]);
                    }
                }

            }

            else if (sum % 2 == 0)
            {
                for (int i = 0; i < arrSumStr.Length; i++)
                {

                    if (arrSumStr[i] == firstDigit)
                    {
                        arrSumStr[i] = replacementStr;
                        Console.Write(arrSumStr[i]);
                    }
                }



            }

            Console.WriteLine();
        }
    }
}
