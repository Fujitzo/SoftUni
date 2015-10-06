using System;
using System.Collections.Generic;

class ActivityTracker
{
    static void Main()
    {
        SortedDictionary<int, SortedDictionary<string, int>> dataDictionary =
                                            new SortedDictionary<int, SortedDictionary<string, int>>();

        int dataLinesNumber = int.Parse(Console.ReadLine());
        string lineContents = String.Empty;
        string[] lineTokens;
        int month = 0;
        string user = String.Empty;
        int distance = 0;
        for (int i = 0; i < dataLinesNumber; i++)
        {
            lineContents = Console.ReadLine();
            lineTokens = lineContents.Split(new char[] { ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);
            month = int.Parse(lineTokens[1]);
            user = lineTokens[3];
            distance = int.Parse(lineTokens[4]);

            if (!dataDictionary.ContainsKey(month))
            {
                dataDictionary[month] = new SortedDictionary<string, int>();
            }

            if (!dataDictionary[month].ContainsKey(user))
            {
                dataDictionary[month][user] = distance;
            }
            else
            {
                dataDictionary[month][user] += distance;
            }
        }

        bool isFirstPair = true;
        foreach (var dataPair in dataDictionary)
        {
            Console.Write("{0}: ", dataPair.Key);
            isFirstPair = true;
            foreach (var subPair in dataPair.Value)
            {
                if (isFirstPair)
                {
                    Console.Write("{0}({1})", subPair.Key, subPair.Value);
                    isFirstPair = false;
                }
                else
                {
                    Console.Write(", {0}({1})", subPair.Key, subPair.Value);
                }
            }
            Console.WriteLine();
        }
    }
}
