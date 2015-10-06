using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../text.txt");
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    reader.ReadLine();
                    line = reader.ReadLine();
                }
                           
            
            }



        }
    }
}
