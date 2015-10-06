using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsUp
{
    class BitsUp
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter numbers count");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter step");
            int step = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the numbers themseleves (from 0 to 255)");
            int[] arrBytes = new int[n];
            for (int i =0; i<n; i++)
            {
            arrBytes[i] = int.Parse(Console.ReadLine());
            }

            for (int currentStep = 1; currentStep<n*8; currentStep += step)
            {
            int bytePosition = currentStep / 8;
            int bitPosition = currentStep % 8;
            int mask = 1 << 7 - (currentStep % 8);
            arrBytes[bytePosition] = arrBytes[bytePosition] | mask;
            }

            foreach (int number in arrBytes)
            { 
            Console.WriteLine(number);
            }
                

           
            }

            
            
            

        }
    }

