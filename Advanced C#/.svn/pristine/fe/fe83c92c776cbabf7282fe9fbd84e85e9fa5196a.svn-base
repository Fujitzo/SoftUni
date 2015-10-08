using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythagoreanNumbersCorrect
{
    class PythagoreanNumbersCorrect
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(arr);
            int count = 0;

            for (int a = 0; a < arr.Length; a++)
            {
                for (int b = a; b < arr.Length; b++)
                {
                    for (int c = b; c < arr.Length; c++)
                    {
                        if (arr[a] * arr[a] + arr[b] * arr[b] == arr[c] * arr[c])
                        {
                            Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", arr[a], arr[b], arr[c]);
                            count++;
                        }
                        
                            
                    }
                }
            }
            if (count == 0)
            { 
            Console.WriteLine("No");
            }
        }
    }
}
