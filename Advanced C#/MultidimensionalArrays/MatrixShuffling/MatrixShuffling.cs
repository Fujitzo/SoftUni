using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixShuffling
{
    class MatrixShuffling
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(Console.ReadLine());
                }
            }

            string[] command = Console.ReadLine().Split().Select(Convert.ToString).ToArray();
            int temp = 0;
            while (command[0] != "END")
            
            {
                if (command[0] == "swap" && int.Parse(command[1]) >= 0 && int.Parse(command[1]) < rows && int.Parse(command[2]) >= 0 && int.Parse(command[2]) < cols
                    && int.Parse(command[3]) >= 0 && int.Parse(command[3]) < rows && int.Parse(command[4]) >= 0 && int.Parse(command[4]) < cols && command.Length==5)
                    {
                        temp = matrix[int.Parse(command[3]), int.Parse(command[4])];
                        matrix[int.Parse(command[3]), int.Parse(command[4])] = matrix[int.Parse(command[1]), int.Parse(command[2])];
                        matrix[int.Parse(command[1]), int.Parse(command[2])] = temp;

                        Console.WriteLine("Swapped Matrix");

                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                Console.Write(matrix[row,col]);
                            }
                            Console.WriteLine();
                        }
                        Array.Clear(command, 0, command.Length);
                        command = Console.ReadLine().Split().Select(Convert.ToString).ToArray();
                    }
                else
                {
                    Console.WriteLine("Invalid Input");
                    Array.Clear(command, 0, command.Length);
                    command = Console.ReadLine().Split().Select(Convert.ToString).ToArray();
                }
            }


        }
    }
}
