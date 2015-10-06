using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<double> processednumbers = new List<double>();
            
            

            foreach (string entry in input)
            {
                char firstLetter = entry[0];
                char secondLetter = entry.Last();
                //StringBuilder numberStr = new StringBuilder(entry); 
                //numberStr.Remove(0, 1);
                //numberStr.Remove(entry.Length-2, 1);
                //Console.WriteLine(numberStr.ToString());
                //double number = Convert.ToDouble(numberStr.ToString());
                double number = double.Parse(entry.Substring(1,entry.Length-2));
                int position = 0;

                if (Convert.ToInt32(firstLetter) >= 65 && Convert.ToInt32(firstLetter) <= 90)
                {
                    position = Convert.ToInt32(firstLetter) - 64;
                    number = number / position;
                }
                if (Convert.ToInt32(firstLetter) >= 97 && Convert.ToInt32(firstLetter) <= 122)
                {
                    position = Convert.ToInt32(firstLetter) - 96;
                    number = number * position;
                }
                if (Convert.ToInt32(secondLetter) >= 65 && Convert.ToInt32(secondLetter) <= 90)
                {
                    position = Convert.ToInt32(secondLetter) - 64;
                    number = number - position;

                }
                if (Convert.ToInt32(secondLetter) >= 97 && Convert.ToInt32(secondLetter) <= 122)
                {
                    position = Convert.ToInt32(secondLetter) - 96;
                    number = number + position;
                }

                processednumbers.Add(number);
          
            }

            Console.WriteLine("{0:0.00}", processednumbers.Sum());


            
        }
    }
}
