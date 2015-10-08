using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedSubsetSums
{
    class SortedSubsetSum
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).Distinct().ToArray();
            
            double combinations = Math.Pow(2, inputNumbers.Length);
            
            List<List<int>> allSums = new List<List<int>>();
            int count = 0;

            for (int mask = 1; mask < combinations; mask++)
            {
                List<int> subset = new List<int>();
                for (int pos = 0; pos < inputNumbers.Length; pos++)
                {
                    if ((mask & (1 << pos)) != 0)
                    {
                        subset.Add(inputNumbers[pos]);
                    }
                }
                if (subset.Sum() != sum) continue;
                {
                    allSums.Add(subset);
                    subset.Sort();
                    count++;
                    
                }

              
            }
            if (count == 0)
            {
                Console.WriteLine("No matching subsets.");
            }
            else
            {
                //allSums.ForEach(list => list.Sort());
                allSums.OrderBy(x => x.Count).ToList(); 
                allSums.OrderBy(y => y.First()).ToList();

                foreach(var list in allSums)
                {
                Console.WriteLine("{0} = {1}", string.Join(" + ", list), sum);
                }

            
            }


        }
    }
}
