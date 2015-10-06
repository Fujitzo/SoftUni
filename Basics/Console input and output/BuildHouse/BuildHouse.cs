using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildHouse
{
    class BuildHouse
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            for (int row = 0; row <n/2+1; row++)
            {
                int dashescount = n / 2 - row;
                string dashes = new string('-', dashescount);
                string asterix = new string('*', row * 2 + 1);
                Console.Write(dashes);
                Console.Write(asterix);
                Console.Write(dashes);
          
            Console.WriteLine();
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)

                    if (col == 0 || col == n-1)
                    {
                        Console.Write('|');
                    }
                    else
                    {
                        Console.Write('*');
                    }
                Console.WriteLine();
            }
            
            
        }
    }
}
