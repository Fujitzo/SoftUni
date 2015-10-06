using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThridDigitIs7
{
    class ThridDigitIs7
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool is7 = false;

            List<int> listOfInts = new List<int>();
            while (number > 0)
            {
                listOfInts.Add(number % 10);
                number = number / 10;
            }   
            listOfInts.Reverse();

            int thirdPosition = listOfInts.Count - 3;

            if (listOfInts[thirdPosition] == 7)
            {
                is7 = true;
            }
            Console.WriteLine(is7);
            
                         

        }
    }
}
