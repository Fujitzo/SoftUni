using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintASCIITable
{
    class PrintASCIITable
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
       
            int i = 0;

            for (i = 0; i < 128; i++)
            {
                char ascii = Convert.ToChar(i);
                Console.WriteLine(ascii);
                
            }

           

        }
    }
}
