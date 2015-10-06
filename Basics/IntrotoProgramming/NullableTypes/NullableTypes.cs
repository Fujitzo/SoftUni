using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    class NullableTypes
    {
        static void Main(string[] args)

        {
            int? someInteger = null;
            Console.WriteLine("This is the integer with Null value -> ",someInteger);
            someInteger =15;
            Console.WriteLine("This is the integer with value 5 -> " +someInteger);
            someInteger = 10;
            Console.WriteLine("This is the integer with value 10-> " +someInteger);

        }
    }
}
