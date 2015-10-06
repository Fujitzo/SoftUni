using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLargerThanNeighbours
{
    class FirstLargerThanNeighbours
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 3, 4, 5, 1, 0, 5 };
            int[] arr2 = { 1, 2, 3, 4, 5, 6, 6 };
            int[] arr3 = { 1, 1, 1 };
            Console.WriteLine(FirstLarger(arr1));
            Console.WriteLine(FirstLarger(arr2));
            Console.WriteLine(FirstLarger(arr3));
        }
        static int FirstLarger(int[] array)
        {
            int pos = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0 && array[i] > array[i + 1])
                {
                    pos = i; break;
                }             
                if (i != 0 && i != array.Length - 1)
                {
                    if (array[i] > array[i + 1] && array[i] > array[i - 1])
                    {
                        pos = i; break;
                    }
                }
                if (i == array.Length - 1 && array[i] > array[i - 1])
                    {
                        pos = i; break;
                    }

                else
                {
                    pos = -1;
                }
            }
                return pos;
        }

    }
}
