using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythagoreanNumbers
{
    class PythagoreanNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++ )
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            List<List<int>> matchingNumbers = new List<List<int>>();

            int combinations = (int)Math.Pow(2, n);
            int count = 0;
            for (int mask = 1; mask < combinations; mask++)
            {
                List<int> subset = new List<int>();
                for (int pos = 0; pos < arr.Length; pos++)
                {
                    if ((mask & (1 << pos)) != 0)
                    {
                        subset.Add(arr[pos]);
                        subset.Sort();
                    }
                }
                if (subset.Count == 3)
                {
                    if (((subset[0] * subset[0]) + (subset[1] * subset[1])) == (subset[2] * subset[2]))
                    {
                        matchingNumbers.Add(subset);
                        count++;
                    }
                }
                if (subset[0] == 0 && (subset.Count == 2 || subset.Count == 1)) 
                {
                       matchingNumbers.Add(subset);
                       count++;
                }
                
            }
            if (count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                foreach (var list in matchingNumbers)
                {
                    if(list.Count == 1)
                    {
                    Console.WriteLine("{0}*{0} + {0}*{0} = {0}*{0}", list[0]);
                    }
                    if(list.Count == 2)
                    {
                    Console.WriteLine("{0}*{0} + {1}*{1} = {1}*{1}", list[0], list[1]);
                    }
                    if (list.Count == 3)
                    { 
                    Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", list[0], list[1], list[2]);
                    }
                    
                }


            }


        }
    }
}
