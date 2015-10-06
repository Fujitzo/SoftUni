using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    struct Position
    {
        public int row;
        public int col;
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
    class SnakeGame
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Position[] directions = new Position[] 
                {
                new Position(0,1), //right
                new Position(0,-1), //left
                new Position(1,0), //down
                new Position(-1,0), //up
                };

            Random randomNum = new Random();
            
            Position food = new Position(randomNum.Next(0, Console.WindowHeight), randomNum.Next(0, Console.WindowWidth));

            Console.WriteLine("*******Snake Game********\n\nControl the snake with the arrow keys\nPause the game with spacebar\n"+
            "If you go overboard - GameOver!\nKeep playing there are some surprises! :)\n\n\nPress Enter to start the game");
            ConsoleKeyInfo startSignal = Console.ReadKey();
            if (startSignal.Key == ConsoleKey.Enter)
            {
                Queue<Position> snakeElements = new Queue<Position>();
                for (int i = 0; i < 5; i++)
                {
                    snakeElements.Enqueue(new Position(0, i));
                }

                foreach (Position position in snakeElements)
                {
                    Console.SetCursorPosition(position.col, position.row);
                    Console.Write('*');
                }

                int direction = 0;
                int delay = 0;
                int foodCounter = 0;
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo input = Console.ReadKey();
                        if (input.Key == ConsoleKey.RightArrow)
                        {
                            direction = 0;
                        }
                        if (input.Key == ConsoleKey.LeftArrow)
                        {
                            direction = 1;
                        }
                        if (input.Key == ConsoleKey.DownArrow)
                        {
                            direction = 2;
                        }
                        if (input.Key == ConsoleKey.UpArrow)
                        {
                            direction = 3;
                        }
                        if (input.Key == ConsoleKey.Spacebar)
                        {
                            Console.SetCursorPosition(0, Console.WindowHeight / 2);
                            Console.WriteLine("Your current score is {0}!\n To resume the game press spacebar again.", foodCounter);
                            input = Console.ReadKey();
                            while (input.Key != ConsoleKey.Spacebar)
                            {
                                input = Console.ReadKey();
                            }
                        }
                    }
                    snakeElements.Dequeue();
                    Position snakeHead = snakeElements.Last();
                    Position nextDirection = directions[direction];
                    Position snakeNewHead = new Position(snakeHead.row + nextDirection.row, snakeHead.col + nextDirection.col);
                    snakeElements.Enqueue(snakeNewHead);

                    Console.Clear();
                    Console.SetCursorPosition(food.col, food.row);
                    Console.Write("@");

                    if (snakeNewHead.row == food.row && snakeNewHead.col == food.col)
                    {
                        snakeElements.Enqueue(snakeNewHead);
                        food = new Position(randomNum.Next(0, Console.WindowHeight), randomNum.Next(0, Console.WindowWidth));
                        foodCounter++;
                        if (foodCounter % 2 == 0)
                        {
                            delay += 10;
                            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                            Console.WriteLine("New Speed -10ms");
                            Thread.Sleep(500);
                        }                     
                    }
                    if (snakeNewHead.row == -1 || snakeNewHead.row == Console.WindowHeight + 1 || snakeNewHead.col == -1 || snakeNewHead.col == Console.WindowWidth + 1)
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                        Console.WriteLine("Game Over! Your score is {0}", foodCounter);
                        Console.ReadKey();
                        break;
                    }
                    if (foodCounter >= 1)
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                        Console.WriteLine("OH SNAP! A second snake appeared!");
                        Thread.Sleep(500);
                        Queue<Position> secondSnakeElements = new Queue<Position>();
                        for (int i = 1; i < 10; i++)
                        {
                            secondSnakeElements.Enqueue(new Position(1, i));
                        }

                        foreach (Position position in secondSnakeElements)
                        {
                            Console.SetCursorPosition(position.col, position.row);
                            Console.Write('#');
                        }
                        bool hitCeiling = false;
                        bool hitFloor = false;
                        bool hitLeftWall = false;
                        bool hitRightWall = false;

                        while (true)
                        {
                            if (Console.KeyAvailable)
                            {
                                ConsoleKeyInfo input = Console.ReadKey();
                                if (input.Key == ConsoleKey.RightArrow)
                                {
                                    direction = 0;
                                }
                                if (input.Key == ConsoleKey.LeftArrow)
                                {
                                    direction = 1;
                                }
                                if (input.Key == ConsoleKey.DownArrow)
                                {
                                    direction = 2;
                                }
                                if (input.Key == ConsoleKey.UpArrow)
                                {
                                    direction = 3;
                                }
                                if (input.Key == ConsoleKey.Spacebar)
                                {
                                    Console.SetCursorPosition(0, Console.WindowHeight / 2);
                                    Console.WriteLine("Your current score is {0}!\n To resume the game press spacebar again.", foodCounter);
                                    input = Console.ReadKey();
                                    while (input.Key != ConsoleKey.Spacebar)
                                    {
                                        input = Console.ReadKey();
                                    }
                                }
                            }
                            snakeElements.Dequeue();
                            snakeHead = snakeElements.Last();
                            nextDirection = directions[direction];
                            snakeNewHead = new Position(snakeHead.row + nextDirection.row, snakeHead.col + nextDirection.col);
                            snakeElements.Enqueue(snakeNewHead);

                            int secondDirection = 0;
                            secondDirection = randomNum.Next(0, 3);
                            secondSnakeElements.Dequeue();
                            Position secondSnakeHead = secondSnakeElements.Last();
                            Position secondSnakeNewHead = new Position();
                            Position nextSecondDirection = directions[secondDirection];
                            if (hitCeiling == false && hitFloor == false && hitLeftWall == false && hitRightWall == false)
                            {
                                secondSnakeNewHead = new Position(secondSnakeHead.row + nextSecondDirection.row, secondSnakeHead.col + nextSecondDirection.col);
                            }
                            if (hitCeiling)
                            {
                                secondSnakeNewHead = new Position(secondSnakeHead.row + 1 + nextSecondDirection.row, secondSnakeHead.col + nextSecondDirection.col);
                                hitCeiling = false;
                            }
                            if (hitFloor)
                            {
                                secondSnakeNewHead = new Position(secondSnakeHead.row-1 + nextSecondDirection.row, secondSnakeHead.col + nextSecondDirection.col);
                                hitFloor = false;
                            }
                            if (hitLeftWall)
                            {
                                secondSnakeNewHead = new Position(secondSnakeHead.row + nextSecondDirection.row, secondSnakeHead.col+1 + nextSecondDirection.col);
                                hitLeftWall = false;
                            }
                            if (hitRightWall)
                            {
                                secondSnakeNewHead = new Position(secondSnakeHead.row + nextSecondDirection.row, secondSnakeHead.col-1 + nextSecondDirection.col);
                                hitRightWall = false;
                            }
                            secondSnakeElements.Enqueue(secondSnakeNewHead);
                            
                            Console.Clear();
                            Console.SetCursorPosition(food.col, food.row);
                            Console.Write("@");

                            if (snakeNewHead.row == food.row && snakeNewHead.col == food.col)
                            {
                                snakeElements.Enqueue(snakeNewHead);
                                food = new Position(randomNum.Next(0, Console.WindowHeight), randomNum.Next(0, Console.WindowWidth));
                                foodCounter++;
                                if (foodCounter%3 == 0)
                                {
                                    delay += 10;
                                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                                    Console.WriteLine("New Speed -10ms");
                                    Thread.Sleep(500);
                                }
                            }
                            if (snakeNewHead.row == -1 || snakeNewHead.row == Console.WindowHeight + 1 || snakeNewHead.col == -1 || snakeNewHead.col == Console.WindowWidth + 1)
                            {
                                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                                //Console.WriteLine("Game Over! Your score is {0}", foodCounter);
                                //Console.ReadKey();
                                goto breakout;
                            }
                            
                            
                            foreach (Position position in snakeElements)
                            {
                                Console.SetCursorPosition(position.col, position.row);
                                Console.Write('*');
                            }
                            
                            if (secondSnakeNewHead.row == 0)
                            {
                                hitCeiling = true;                                
                            }
                            if (secondSnakeNewHead.row == Console.WindowHeight-1)
                            {
                                hitFloor = true;                                                                    
                            }
                            if (secondSnakeNewHead.col == 0)
                            {
                                hitLeftWall = true;                                    
                            }
                            if (secondSnakeNewHead.col == Console.WindowWidth-1)
                            {
                                hitRightWall = true;                                   
                            }
                            foreach (Position position in secondSnakeElements)
                               {
                               Console.SetCursorPosition(position.col, position.row);
                               Console.Write('#');                           

                               }
                            Thread.Sleep(70 - delay);
                        } //closing the inner while (true) cycle                        
                    }
                    
                    foreach (Position position in snakeElements)
                    {
                        Console.SetCursorPosition(position.col, position.row);
                        Console.Write('*');
                    }
                    Thread.Sleep(70 - delay);
                
                }//closing outer while (true) cycle
            breakout: Console.WriteLine("Game Over! Your score is {0}", foodCounter);
                      Console.ReadKey();
            }

            
           

        }
    }
}
