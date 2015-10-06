using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitLock
{
    class BitLock
    {
        static void Main(string[] args)
        {
            string numbers= Console.ReadLine();
            int[] numArr = numbers.Split(' ').Select(int.Parse).ToArray();

            

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ').Select(x => x.ToString()).ToArray();
                

                if (command.Contains("check"))
                {
                    int bitPos = int.Parse(command[1]);

                    int counter = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        
                        int mask = (int)Math.Pow(2, bitPos);
                        int value = numArr[i] & mask;
                        if (value == mask)
                        {
                            counter++;
                        }
                    }
                    Console.WriteLine(counter);
                }
                if (command.Contains("right"))
                {
                    int row = int.Parse(command[0]);
                    int rotations = int.Parse(command[2]);
                    for (int i = 0; i < rotations; i++)
                    {
                        int mask = 1;
                        int value = mask & numArr[row];
                        numArr[row] = numArr[row] >> 1;
                        if (value == 1)
                        {
                            int mask1 = 2048;
                            numArr[row] = numArr[row] | mask1;
                        }
                        else
                        {
                            int mask0 = ~2048;
                            numArr[row] = numArr[row] & mask0;
                        }
                    }
                }
                if (command.Contains("left"))
                {
                    int row = int.Parse(command[0]);
                    int rotations = int.Parse(command[2]);
                    for (int i = 0; i < rotations; i++)
                    {
                        int mask = 2048;
                        int value = mask & numArr[row];
                        numArr[row] = numArr[row] << 1;
                        numArr[row] = numArr[row] & ~4096;
                        if (value == mask)
                        {
                            int mask1 = 1;
                            numArr[row] = numArr[row] | mask1;
                        }
                        else
                        {
                            int mask0 = ~1;
                            numArr[row] = numArr[row] & mask0;
                        }
                    }



                }

                if (command.Contains("end"))
                {
                    break;
                }
            }

            
                
                //string modifiedNumbers = numArr.ToString();
                string modifiedNumbers = string.Join(" ", numArr);
                Console.WriteLine(modifiedNumbers);
                
                

               
            
            
              
            }




        }
    }

