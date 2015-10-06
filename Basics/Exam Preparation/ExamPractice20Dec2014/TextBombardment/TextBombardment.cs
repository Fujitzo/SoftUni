using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBombardment
{
    class TextBombardment
    {
        static void Main(string[] args)
        {
            string inputmsg = Console.ReadLine();
            int width = int.Parse(Console.ReadLine());
            string bombs = Console.ReadLine();

            List<int> bombsList = new List<int>(bombs.Split().ToList().Select(x => Convert.ToInt32(x)));

            int rows = 0;
            if (inputmsg.Length%width==0)
            {
            rows = inputmsg.Length/width;
            }
            else
            {
                rows = inputmsg.Length/width + 1;
            }

            char[] inputmsgCharArr = inputmsg.ToCharArray();
            char[,] inputmsgMatrix = new char[rows,width];
            Console.WriteLine();

            for (int i = 0; i <rows; i++)
            {

                for (int j = 0, k = i * width; j < width  && k < inputmsg.Length ; j++, k++)
                {
                    { 
                    inputmsgMatrix[i, j] = inputmsgCharArr[k];

                    for (int l = 0; l < bombsList.Count; l++)
                    {
                        if (inputmsgMatrix[i, bombsList[l]] != ' ')
                        {
                            inputmsgMatrix[i, bombsList[l]] = ' ';
                        }
                        //else if (inputmsgMatrix[0, bombsList[l]] == ' ')
                        //{
                        //    inputmsgMatrix[i, bombsList[l]] = ' ';
                        //}            


                        else if (inputmsgMatrix[i, bombsList[l]] == ' ' && i != 0 && i!=1)
                        {                      
                            inputmsgMatrix[i, bombsList[l]] = inputmsgMatrix[i, j];
                            break;
                        }
                       
                    }

                    Console.Write(inputmsgMatrix[i,j]);
                    }
                       
                }
                
            }
            Console.WriteLine();
            //string result = new string(inputmsgMatrix);

         
               
            

            
          
            
           

            
           
            





        }
    }
}
