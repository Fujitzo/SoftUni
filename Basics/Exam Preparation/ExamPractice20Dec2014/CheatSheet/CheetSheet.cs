using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatSheet
{
    class CheetSheet
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            long startNumRow = int.Parse(Console.ReadLine());
            long startNumCol = int.Parse(Console.ReadLine());

            for (long i = startNumRow; i < rows+startNumRow; i++ )
            {
                for (long j = startNumCol; j < cols + startNumCol; j++)
                {
                    if (j == cols + startNumCol)
                    {
                        Console.Write(j*i);
                    }
                    else
                    {
                        Console.Write("{1}{0}"," ", j*i);
                    }
                        
                }
                //Console.Write("{0}{1}{0}", " ", i);
                Console.WriteLine();
            }
        }
    }
}
