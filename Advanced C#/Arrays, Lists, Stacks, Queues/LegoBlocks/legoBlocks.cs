using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBlocks
{
    class LegoBlocks
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<List<int>> leftSide = new List<List<int>>();
            List<List<int>> rightSide = new List<List<int>>();
            List<int> leftLength = new List<int>();
            List<int> rightLength = new List<int>();

            for (int i = 0; i < n; i++)
            {
                List<int> row = Console.ReadLine().Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();
                leftSide.Add(row);
                leftLength.Add(row.Count);
            }            
            for (int i = 0; i < n; i++)
            {
                List<int> row = Console.ReadLine().Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();
                row.Reverse();
                rightSide.Add(row);
                rightLength.Add(row.Count);
            }
            
            bool isMatrix = true;

            for (int i = 1; i < n; i++)
            {
                if (leftSide[i].Count + rightSide[i].Count != leftSide[i - 1].Count + rightSide[i - 1].Count)
                {

                    isMatrix = false;
                    break;
                }
            }
            if (isMatrix)
                { 
                for (int i = 0; i<n; i++)
                    {
                
                    Console.Write("[{0},", string.Join(", ", leftSide[i]));
                    Console.Write(" {0}]", string.Join(", ", rightSide[i]));
                    Console.WriteLine();
                    }
                 }
                else
                {
                    Console.WriteLine("The total number of cells is: {0}", rightLength.Sum() + leftLength.Sum());

                }
            }
                
            
            }
        }
 

