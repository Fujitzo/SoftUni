using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Word_Count
{
    class WordCount
    {
        static void Main(string[] args)
        {
            using (StreamReader readerW = new StreamReader("../../words.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../results.txt"))
                {
                    string word = readerW.ReadLine().ToLower();
                    while (word != null)
                    {
                        int matches = 0;
                        using (StreamReader readerT = new StreamReader("../../text.txt"))
                        {
                            string line = readerT.ReadLine();
                            line.ToLower();
                            while (line != null)
                            {
                                if (line.Contains(word))
                                {
                                    matches++;
                                }
                                line = readerT.ReadLine();
                            }
                            writer.WriteLine("{0} - {1}", word, matches);
                            word = readerW.ReadLine();
                        }
                    }
                }
            }
            // Ordering the results in the results.txt file
                      
            
            string[] linesInResult = File.ReadAllLines("../../results.txt");
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var line in linesInResult)
            {
                dict.Add(line, (int)Char.GetNumericValue(line.Last()));
            }
            
            

            using (StreamWriter writer = new StreamWriter("../../results.txt"))
            {
             foreach(var pair in dict.OrderByDescending(pair => pair.Value))
             {
                writer.WriteLine(pair.Key);
             }
            }
        }
    }
}

// I don't think Regex is needed here as string.Contains works fine. It picks up the word if it is 
//surrounded by punctoation or white space and does not pick it if it is part of another word 
//(like "is" in "his" for example) The only problem is that for some reason .ToLower() does not work 
//correctly, so I'm not getting the second "quick". If you have an idea why - tell me :)