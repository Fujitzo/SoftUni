using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peter_sGameClean
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
         
            string sumStr = Convert.ToString(sum);
            int sumLength = sumStr.Length;
      
            Console.WriteLine();
            if (sum % 2 == 0)
            {
                Console.Write(replacementStr);
                for (int i = 1; i < sumLength; i++)
                {
                    int firstDigit = sum / ((int)(Math.Pow(10, sumLength - 1))) % 10;
                    int nextDigit = sum / ((int)(Math.Pow(10, sumLength - i - 1))) % 10;


                    if (nextDigit == firstDigit)
                    {

                        Console.Write(replacementStr);

                    }
                    else
                        Console.Write(nextDigit);
                }
            }
            else if (sum % 2 != 0)
            {
                for (int i = 0; i < sumLength - 1; i++)
                {
                    int lastDigit = sum % 10;
                    int nextDigit = sum / ((int)(Math.Pow(10, sumLength - i - 1))) % 10;

                    if (nextDigit == lastDigit)
                    {
                        Console.Write(replacementStr);
                    }
                    else
                        Console.Write(nextDigit);
                }
                Console.Write(replacementStr);
            }

            Console.WriteLine();

        }
    }
}
