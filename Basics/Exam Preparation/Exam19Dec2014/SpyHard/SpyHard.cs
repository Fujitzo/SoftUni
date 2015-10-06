using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyHard
{
    class SpyHard
    {
        static void Main(string[] args)
        {
            int baseNum = int.Parse(Console.ReadLine());

            char[] msgArr = Console.ReadLine().ToCharArray();

            for (int i = 0; i < msgArr.Length; i++)
            {
                //switch (msgArr[i])
                //{


                //}

                if ((msgArr[i] >= 65 && msgArr[i] <= 90) || (msgArr[i] >= 65 && msgArr[i] <= 90))
                {
                    msgArr[i] = msgArr[i];
                }



            }

        }
    }
}
