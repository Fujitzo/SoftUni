using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastDigit
{
    class LastDigit
    {
        static string GetLastDigit(int num)
        {
            int lastDigit = num % 10;
            string digitAsWord = null;
            switch (lastDigit)
            {
                case 0: digitAsWord = "zero"; break;
                case 1: digitAsWord = "one"; break;
                case 2: digitAsWord = "two"; break;
                case 3: digitAsWord = "three"; break;
                case 4: digitAsWord = "four"; break;
                case 5: digitAsWord = "five"; break;
                case 6: digitAsWord = "six"; break;
                case 7: digitAsWord = "seven"; break;
                case 8: digitAsWord = "eight"; break;
                case 9: digitAsWord = "nine"; break;
                              
            }

            return digitAsWord;
        }


        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(GetLastDigit(num));
        }
    }
}
