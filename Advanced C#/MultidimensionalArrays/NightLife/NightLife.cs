using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightLife
{
    class NightLife
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, SortedSet<string>>> agenda = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                List<string> agendaDetails = input.Split(';').ToList();
                string city = agendaDetails[0];
                string venue = agendaDetails[1];
                string performer = agendaDetails[2];

                if (!agenda.ContainsKey(city))
                {
                    agenda.Add(city, new SortedDictionary<string, SortedSet<string>>());
                }
                if (!agenda[city].ContainsKey(venue))
                {
                    agenda[city].Add(venue, new SortedSet<string>()); 
                }
                    agenda[city][venue].Add(performer);
                
                input = Console.ReadLine();
            }

                foreach (var citypair in agenda)
                {
                    Console.WriteLine(citypair.Key);
                    foreach (var venuepair in citypair.Value)
                    {
                    Console.WriteLine("-> {0}: {1}" ,venuepair.Key, string.Join(", ", venuepair.Value));
                    }
                        
                }


            
            



        }
    }
}
