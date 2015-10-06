using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic9DigitNumbers
{
    class Magic9DigitNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter sum:");
            int sum = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter difference:");
            int diff = int.Parse(Console.ReadLine());

            //string a1 , b1, c1, d1, e1, f1,g1,h1,i1;
            //a1 = b1 = c1 = d1 = e1 = f1 = g1 = h1 = i1 = "1";
            
            //int sub1 = int.Parse(a1 + b1 + c1);
            //int sub2 = int.Parse(d1 + e1 + f1);
            //int sub3 = int.Parse(g1 + h1 + i1);

            //Console.WriteLine(sub1);

            //int a = Convert.ToInt32(a1);
            //int b = Convert.ToInt32(b1);
            //int c = Convert.ToInt32(c1);
            //int d = Convert.ToInt32(d1);
            //int e = Convert.ToInt32(e1);
            //int f = Convert.ToInt32(f1);
            //int g = Convert.ToInt32(g1);
            //int h = Convert.ToInt32(h1);
            //int i = Convert.ToInt32(i1);

            int a, b, c, d, e, f, g, h, i;
            bool condition = false;

            for (a = 1; a <= 7; a++)
            {
                for (b = 1; b <= 7; b++)
                {
                    for (c = 1; c <= 7; c++)
                    {
                        for (d = 1; d <= 7; d++)
                        {
                            for (e = 1; e <= 7; e++)
                            {
                                for (f = 1; f <= 7; f++)
                                {
                                    for (g = 1; g <= 7; g++)
                                    {
                                        for (h = 1; h <= 7; h++)
                                        {
                                            for (i = 1; i <= 7; i++)
                                            {
                                                if (a + b + c + d + e + f + g + h + i == sum)
                                                {

                                                    string first3 = ""+ a + b + c;

                                                    string second3 = "" + d + e + f;

                                                    string third3 = "" + g + h + i;


                                                    int sub1 = int.Parse(first3);
                                                    int sub2 = int.Parse(second3);
                                                    int sub3 = int.Parse(third3);

                                                    if (sub2 - sub1 == diff && sub3 - sub2 == diff && sub1 <= sub2 && sub2 <= sub3)
                                                    
                                                    {
                                                        condition = true;
                                                        Console.WriteLine("Magic 9 numbers: {0}{1}{2}{3}{4}{5}{6}{7}{8}", a, b, c, d, e, f, g, h, i);
                                                    }
                                                    
                                                    //Console.WriteLine("Sub1 sub2 and sub3 {0}{1}{2}", sub1, sub2, sub3);

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (condition == false)
            {
                Console.WriteLine("There are no numbers to fulfil the conditions");   
            }
  
        }
    }
}
