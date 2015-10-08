using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Copy_Binary_File
{
    class CopyBinaryFile
    {
        static void Main(string[] args)
        {

            using (var source = new FileStream("../../pic.jpg", FileMode.Open))
            {
                using (var copy = new FileStream("../../pic_copy.jpg", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    
                    while(true)
                    {
                    int readBytes = source.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }
                    copy.Write(buffer, 0, readBytes);
                    
                    }
                    
                }
            }
        }
    }
}
