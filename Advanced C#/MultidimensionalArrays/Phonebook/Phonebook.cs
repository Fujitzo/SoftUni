using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while (input != "search")
            { 
                List<string> contact = input.Split().ToList();
                phonebook.Add(contact[0], contact[1]);
                input = Console.ReadLine();
            }
            string name = Console.ReadLine();
            while(!String.IsNullOrEmpty(name))
            {
                    if (phonebook.ContainsKey(name))
                    {
                        Console.WriteLine("{0} -> {1}" , name, phonebook[name]);
                        name = Console.ReadLine();
                    }
                    else
                    {
                    Console.WriteLine("Contact {0} does not exist", name);
                    name = Console.ReadLine();
                    
                    }
            }

                }
            }
        }

