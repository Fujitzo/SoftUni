using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSorting
{
    class GenericArraySort
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 3, 4, 5, 1, 0, 5 };
            List<string> strings = new List<string> { "I'm tired of C#", "I'm sick of C#", "But I'm not giving up", "aaaa" };
            List<DateTime> dates  = new List<DateTime> { new DateTime(2011, 8, 8), new DateTime(2010, 8, 8), new DateTime(2015, 22, 9) };

            GenericSort(numbers);
            Console.WriteLine();
            GenericSort(strings);
            Console.WriteLine();
            GenericSort(dates);
            Console.WriteLine();

         }
        static void GenericSort<T>(List<T> List) where T: IComparable
            
        {
                    
            for (int i = 0; i < List.Count; i++)
            {
                var minValue = List[i];
                
                int jPosition = 0;
                for (int j = i; j < List.Count; j++)
                {
                    if (List[j].CompareTo(minValue) < 0 )
                    {
                        minValue = List[j];
                        jPosition = j;
                    }

                }
                T temp = default(T); 
                temp = List[i];
                List[i] = minValue;
                List[jPosition] = temp;

            }
            foreach (var l in List)
            {
                Console.Write(l + " ");
            }
            
            //I'm sorry I didn't have enough time to debug.. 
        
        }






        }
    }

