using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptTheMessage
{
    class EncryptTheMessage
    {
        static void Main(string[] args)
        {
            //Закоментирания код, по долу е от предоставените решения, но незнайно защо не работи при мен за изход от цикъла с "end" или "END" 
            
            //string input = Console.ReadLine();
            //while (input != "start" && input != "START")
            //{
            //    input = Console.ReadLine();
            //}
            //input = Console.ReadLine();
            //List<string> inputListMessages = new List<string>();
            //int msgcount = 0;
            //while (input != "end" && input != "END")
            //{

            //Кода, който е изместен надясно е неправилната , но работеща алтернатива (като изключим това че програмата е в безкраен цикъл)

                                                            while (true)
                                                            {
                                                                string input = Console.ReadLine();

                                                                if (input == "start" || input == "START")
                                                                {
                                                                    List<string> inputListMessages = new List<string>();
                                                                    int msgcount = 0;
                                                                    while ((Console.ReadLine()) != "end") //
                                                                    {
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            input = Console.ReadLine();
                            continue;
                        }

                        inputListMessages.Add(Console.ReadLine());
                        msgcount++;
                    }
                    Console.WriteLine((msgcount == 0) ? "No message sent" : "Total number of messages:{0}", msgcount);

                    foreach (var message in inputListMessages)
                    {
                        char[] msgCharArr = message.ToCharArray();

                        Array.Reverse(msgCharArr);
                        List<char> encWord = new List<char>();
                        for (int i = 0; i < msgCharArr.Length; i++)
                        {
                            char letter = msgCharArr[i];

                            if (letter >= 65 && letter < 78)
                            {
                                int ASCIIPosEnc = Convert.ToInt32(letter) + 13;
                                letter = Convert.ToChar(ASCIIPosEnc);
                                encWord.Add(letter);
                            }
                            else if (letter >= 97 && letter <= 109)
                            {
                                int ASCIIPosEnc = Convert.ToInt32(letter) + 13;
                                letter = Convert.ToChar(ASCIIPosEnc);
                                encWord.Add(letter);
                            }

                            else if (letter >= 78 && letter <= 90)
                            {
                                int ASCIIPosEnc = Convert.ToInt32(letter) - 13;
                                letter = Convert.ToChar(ASCIIPosEnc);
                                encWord.Add(letter);
                            }
                            else if (letter >= 110 && letter <= 122)
                            {
                                int ASCIIPosEnc = Convert.ToInt32(letter) - 13;
                                letter = Convert.ToChar(ASCIIPosEnc);
                                encWord.Add(letter);
                            }
                            else if (letter == 32)
                            {
                                int ASCIIPosEnc = Convert.ToInt32(letter) + 11;
                                letter = Convert.ToChar(ASCIIPosEnc);
                                encWord.Add(letter);
                            }
                            else if (letter == 44)
                            {
                                int ASCIIPosEnc = Convert.ToInt32(letter) - 7;
                                letter = Convert.ToChar(ASCIIPosEnc);
                                encWord.Add(letter);
                            }
                            else if (letter == 46)
                            {
                                int ASCIIPosEnc = Convert.ToInt32(letter) - 8;
                                letter = Convert.ToChar(ASCIIPosEnc);
                                encWord.Add(letter);
                            }
                            else if (letter == 63)
                            {
                                int ASCIIPosEnc = Convert.ToInt32(letter) - 28;
                                letter = Convert.ToChar(ASCIIPosEnc);
                                encWord.Add(letter);
                            }
                            else if (letter == 33)
                            {
                                int ASCIIPosEnc = Convert.ToInt32(letter) + 3;
                                letter = Convert.ToChar(ASCIIPosEnc);
                                encWord.Add(letter);
                            }
                                else
                            {   
                                int ASCIIPosEnc = Convert.ToInt32(letter);
                                letter = Convert.ToChar(ASCIIPosEnc);
                                encWord.Add(letter);
                                
                            }


                        }
                        encWord.Reverse();
                        string encWordStr = string.Join("", encWord.ToArray().Reverse());
                        Console.WriteLine("{0}", encWordStr);
                    }
                }
                
            }
            
            
        }
    }
}