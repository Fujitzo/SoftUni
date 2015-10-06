using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSums
{
    class SubsetSums
    {
        static void Main(string[] args)
        {

            int sum = int.Parse(Console.ReadLine());
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).Distinct().ToArray();
            

            double combinations = Math.Pow(2, inputNumbers.Length);
            List<int> subset = new List<int>();
            int count = 0;

            for (int mask = 1; mask < combinations; mask++)
            {
                for (int pos = 0; pos < inputNumbers.Length; pos++)
                {
                    if ((mask & (1 << pos)) != 0)
                    {
                        subset.Add(inputNumbers[pos]);
                    }
                }
                if (subset.Sum() == sum)
                    {
                        Console.WriteLine("{0} = {1}", string.Join(" + ", subset), sum);
                        count++;
                    }
                   
                    subset.Clear();
            }
           if (count == 0)
                    {
                        Console.WriteLine("No matching subsets.");
                    }

        }
    }
}
