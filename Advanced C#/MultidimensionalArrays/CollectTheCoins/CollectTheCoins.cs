using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectTheCoins
{
    class CollectTheCoins
    {
        static void Main(string[] args)
        {
            char[][] board = new char[4][];
            for (int row = 0; row < 4; row++)
            {
                board[row] = Console.ReadLine().ToCharArray(); 
            }

            char[] commands = Console.ReadLine().ToCharArray();

            List<char> path = new List<char>();
            path.Add(board[0][0]);
            int currentRow = 0;
            int currentCol = 0;
            int wallsHit = 0;
            int coinsCollected = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                try
                {
                    if (commands[i] == '>')
                    {
                        path.Add(board[currentRow][currentCol + 1]);
                        currentCol = currentCol + 1;
                        
                    }

                    if (commands[i] == '<')
                    {
                        path.Add(board[currentRow][currentCol - 1]);
                        currentCol = currentCol - 1;
                        
                    }
                    if (commands[i] == 'V')
                    {
                        path.Add(board[currentRow + 1][currentCol]);
                        currentRow = currentRow + 1;
                        
                    }
                    if (commands[i] == '^')
                    {
                        path.Add(board[currentRow - 1][currentCol]);
                        currentRow = currentRow - 1;
                        
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    wallsHit++;
                }
            }
            foreach (var sign in path)
            {
                if (sign == '$')
                {
                    coinsCollected++;
                }
            }

            Console.WriteLine("Coins Collected: {0}", coinsCollected);
            Console.WriteLine("Walls hit: {0}", wallsHit);


        }
    }
}
