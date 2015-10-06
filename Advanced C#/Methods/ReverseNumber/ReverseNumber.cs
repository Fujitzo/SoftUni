using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseNumber
{
    class ReverseNumber
    {
        static void Main(string[] args)
        {
            float number = float.Parse(Console.ReadLine());

            Console.WriteLine(GetReversed(number));
        }

                static string  GetReversed(float number)
        {
            char[] reversedArr = number.ToString().Reverse().ToArray();
            string reversed = new string(reversedArr);

            for (int i = 0; i < reversedArr.Length; i++)
            {
                if (reversedArr[i] == '.')
                {
                    for (int j = i+1; j < reversedArr.Length; j++)
                    {
                        if (reversedArr[j] != '0')
                        { 
                        break;
                        }                       
                        if (reversedArr[j] == '0' && j == reversedArr.Length-1 )
                        {
                            char[] shortenRevArr = new char[i];
                            Array.Copy(reversedArr, shortenRevArr, shortenRevArr.Length);
                            reversed = new string(shortenRevArr);
                            
                        }

                    }

                }

                
            }
            return reversed;
        }



    }
}
