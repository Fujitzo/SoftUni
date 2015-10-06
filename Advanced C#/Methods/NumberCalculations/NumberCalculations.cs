using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberCalculations
{
    class NumberCalculations
    {
        static void Main(string[] args)
        {
            //int[] arr = { -10, 5, 4, 0, -3, 201, 0 };
            //float[] arr = { 0.22F, -0.5F, 46.2F, 17, 5.00001F };
            decimal[] arr = { 0.0000000005M, 56, 1.000000000009M};

            Console.WriteLine("Max: {0}", FindMax(arr));
            Console.WriteLine("Min: {0}", FindMin(arr));
            Console.WriteLine("Sum: {0}", FindSum(arr));
            Console.WriteLine("Average: {0}", FindAverage(arr));
            Console.WriteLine("Product: {0}", FindProduct(arr));

            
        }
        static int FindMax(int[] arr)
        {
            int max = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
                return max;
        }
        static float FindMax(float[] arr)
        {
            float max = float.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }
        static decimal FindMax(decimal[] arr)
        {
            decimal max = decimal.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }
        
        /// //////////////////////////////////////////////////////////////////////////////////////
        
        static int FindMin(int[] arr)
        {
            int min = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            return min;
        }
        static float FindMin(float[] arr)
        {
            float min = float.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            return min;
        }
        static decimal FindMin(decimal[] arr)
        {
            decimal min = decimal.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            return min;
        }
        
        /// //////////////////////////////////////////////////////////////////////////////////////////////
      
        static float FindAverage(int[] arr)
        {
            float sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            float avg = sum / arr.Length;
            return avg; 
        
        }
        static float FindAverage(float[] arr)
        {
            float sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            float avg = sum / arr.Length;
            return avg;

        }
        static decimal FindAverage(decimal[] arr)
        {
            decimal sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            decimal avg = sum / arr.Length;
            return avg;

        }
       
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////
       
        static int FindSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }
        static float FindSum(float[] arr)
        {
            float sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }
        static decimal FindSum(decimal[] arr)
        {
            decimal sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////
        /// 
        static int FindProduct(int[] arr)
        {
            int product = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                product *= arr[i];
            }

            return product;
        }
        static float FindProduct(float[] arr)
        {
            float product = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                product = product*arr[i];
            }

            return product;
        }
        static decimal FindProduct(decimal[] arr)
        {
            decimal product = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                product *= arr[i];
            }

            return product;
        }
    }
}
