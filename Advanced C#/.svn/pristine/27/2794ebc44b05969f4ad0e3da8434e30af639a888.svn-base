using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../text.txt");
            StreamWriter writer = new StreamWriter("../../modified.txt");
            using (reader)
            {
                using (writer)
                {
                    int lineNUmber = 1;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine("{0} -> {1}", lineNUmber, line);
                        line = reader.ReadLine();
                        lineNUmber++;
                    }
                
                }

            }
        }
    }
}
