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
            Console.WriteLine();
            Console.WriteLine("*******  Snake Game  ********\n\nControl the snake with the arrow keys\n\nPause the game with spacebar\n\n" +
            "If you go overboard - GameOver!\n\nKeep playing there are some surprises! :)\n\n\n\n\n\nPress Enter to start the game");
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
                int enemyFoodCounter = 0;
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
                            Console.WriteLine("Your current score is {0}\n To resume the game press spacebar again.", foodCounter);
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
                        if (foodCounter % 5 == 0)
                        {
                            delay += 10;
                            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                            Console.WriteLine("New Speed -10ms");
                            Thread.Sleep(1000);
                        }
                    }
                   
                    if (snakeNewHead.row == -1 || snakeNewHead.row == Console.WindowHeight + 1 || snakeNewHead.col == -1 || snakeNewHead.col == Console.WindowWidth + 1)
                    {
                        goto breakout;
                    }
                    if (foodCounter == 3)
                    {
                        Console.SetCursorPosition(0, Console.WindowHeight / 2);
                        Console.WriteLine("OH SNAP! A second snake came by!");
                        Thread.Sleep(2000);
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

                        bool shownText = false;

                        while (true)
                        {
                            
                            if (foodCounter == 7 && shownText == false)
                            {
                            Console.SetCursorPosition(0, Console.WindowHeight / 2);
                            Console.WriteLine("But it's not very smart.\nIt keeps banging its head into the wall...");
                            Thread.Sleep(2500);
                            shownText = true;

                            }
                            if (foodCounter == 12)
                            {
                                break;
                            }
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
                                secondSnakeNewHead = new Position(secondSnakeHead.row - 1 + nextSecondDirection.row, secondSnakeHead.col + nextSecondDirection.col);
                                hitFloor = false;
                            }
                            if (hitLeftWall)
                            {
                                secondSnakeNewHead = new Position(secondSnakeHead.row + nextSecondDirection.row, secondSnakeHead.col + 1 + nextSecondDirection.col);
                                hitLeftWall = false;
                            }
                            if (hitRightWall)
                            {
                                secondSnakeNewHead = new Position(secondSnakeHead.row + nextSecondDirection.row, secondSnakeHead.col - 1 + nextSecondDirection.col);
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
                                if (foodCounter % 5 == 0)
                                {
                                    delay += 10;
                                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                                    Console.WriteLine("New Speed -10ms");
                                    Thread.Sleep(1000);
                                }
                                                        
                            }
                            
                            if (snakeNewHead.row == -1 || snakeNewHead.row == Console.WindowHeight + 1 || snakeNewHead.col == -1 || snakeNewHead.col == Console.WindowWidth + 1)
                            {
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
                            if (secondSnakeNewHead.row == Console.WindowHeight - 1)
                            {
                                hitFloor = true;
                            }
                            if (secondSnakeNewHead.col == 0)
                            {
                                hitLeftWall = true;
                            }
                            if (secondSnakeNewHead.col == Console.WindowWidth - 1)
                            {
                                hitRightWall = true;
                            }
                            foreach (Position position in secondSnakeElements)
                            {
                                Console.SetCursorPosition(position.col, position.row);
                                Console.Write('#');

                            }
                            Thread.Sleep(100 - delay);
                        } //closing the inner while (true) cycle                        
                    }
                    if (foodCounter == 12)
                    {
                        Console.SetCursorPosition(0, Console.WindowHeight / 2);
                        Console.WriteLine("This snake is supposed to be smarter!\n\nWatch Out!");
                        Thread.Sleep(2500);
                        Queue<Position> secondSnakeElements = new Queue<Position>();
                        for (int i = 1; i < 7; i++)
                        {
                            secondSnakeElements.Enqueue(new Position(1, i));
                        }

                        foreach (Position position in secondSnakeElements)
                        {
                            Console.SetCursorPosition(position.col, position.row);
                            Console.Write('#');
                        }
                        //bool hitCeiling = false;
                        //bool hitFloor = false;
                        //bool hitLeftWall = false;
                        //bool hitRightWall = false;
                        bool shownText2 = false;
                        bool shownText3 = false;
                        bool killedEnemy = false;

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
                                    Console.WriteLine("Your current score is {0}!\nYour oponent score is {1}\nDon't let him eat more apples than you!\n\n\n"+
                                    "To resume the game press spacebar again.", foodCounter, enemyFoodCounter);
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
                            secondSnakeElements.Dequeue();
                            Position secondSnakeHead = secondSnakeElements.Last();
                            if (food.col > secondSnakeHead.col)
                            {
                                secondDirection = 0;
                            }
                            if (food.col < secondSnakeHead.col)
                            {
                                secondDirection = 1;
                            }
                            if (food.col == secondSnakeHead.col)
                            {
                                if (food.row > secondSnakeHead.row)
                                {
                                    secondDirection = 2;
                                }
                                if (food.row < secondSnakeHead.row)
                                {
                                    secondDirection = 3;
                                }
                                if (food.row == secondSnakeHead.row)
                                {
                                    food = new Position(randomNum.Next(0, Console.WindowHeight), randomNum.Next(0, Console.WindowWidth));
                                    enemyFoodCounter++;
                                }
                            }
                            Position nextSecondDirection = directions[secondDirection];
                            Position secondSnakeNewHead = new Position(secondSnakeHead.row + nextSecondDirection.row, secondSnakeHead.col + nextSecondDirection.col);
                            secondSnakeElements.Enqueue(secondSnakeNewHead);
                                             

                            Console.Clear();
                            Console.SetCursorPosition(food.col, food.row);
                            Console.Write("@");

                            if (snakeNewHead.row == food.row && snakeNewHead.col == food.col)
                            {
                                snakeElements.Enqueue(snakeNewHead);
                                food = new Position(randomNum.Next(0, Console.WindowHeight), randomNum.Next(0, Console.WindowWidth));
                                foodCounter++;
                                if (foodCounter % 5 == 0)
                                {
                                    delay += 10;
                                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                                    Console.WriteLine("New Speed -10ms");
                                    Thread.Sleep(1000);
                                }
                                
                            }
                            
                            if (snakeNewHead.row == -1 || snakeNewHead.row == Console.WindowHeight || snakeNewHead.col == -1 || snakeNewHead.col == Console.WindowWidth)
                            {
                                goto breakout;
                            }
                            if (enemyFoodCounter >= 11 && killedEnemy == false)
                            {
                                food = new Position(randomNum.Next(0, Console.WindowHeight), Console.WindowWidth-1);
                                killedEnemy = true;
                            }
                            if (secondSnakeNewHead.row == -1 || secondSnakeNewHead.row == Console.WindowHeight || secondSnakeNewHead.col == -1 || secondSnakeNewHead.col == Console.WindowWidth)
                            {
                                Console.WriteLine("Oh well, it killed itself! So it is not so smart after all\n\nNow we're on our own again!");
                                Thread.Sleep(2500);
                                bool shownText4 = false;
                                bool shownText5 = false;

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
                                            Console.WriteLine("Your current score is {0}!" +
                                            "To resume the game press spacebar again.", foodCounter, enemyFoodCounter);
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


                                    Console.Clear();
                                    Console.SetCursorPosition(food.col, food.row);
                                    Console.Write("@");

                                    if (snakeNewHead.row == food.row && snakeNewHead.col == food.col)
                                    {
                                        snakeElements.Enqueue(snakeNewHead);
                                        food = new Position(randomNum.Next(0, Console.WindowHeight), randomNum.Next(0, Console.WindowWidth));
                                        foodCounter++;
                                        if (foodCounter % 5 == 0)
                                        {
                                            delay += 10;
                                            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                                            Console.WriteLine("New Speed -10ms");
                                            Thread.Sleep(1000);
                                        }

                                    }
                                    if (foodCounter == 20&& shownText4 == false)
                                    {
                                        Console.SetCursorPosition(0, Console.WindowHeight / 2);
                                        Console.WriteLine("No more functionalities implemented. You can crash into the wall if you feel bored");
                                        Thread.Sleep(2500);
                                        shownText4 = true;
                                    }
                                    if (foodCounter == 33 && shownText5 == false)
                                    {
                                        Console.SetCursorPosition(0, Console.WindowHeight / 2);
                                        Console.WriteLine("Well Done! You made it to the hall of fame!!!\n\n\n\nPS: I'm sorry but you're probably going to crash after this message disappears");
                                        Thread.Sleep(4500);
                                        shownText5 = true;
                                    }

                                    if (snakeNewHead.row == -1 || snakeNewHead.row == Console.WindowHeight || snakeNewHead.col == -1 || snakeNewHead.col == Console.WindowWidth)
                                    {
                                        goto breakout;
                                    }
                                    foreach (Position position in snakeElements)
                                    {
                                        Console.SetCursorPosition(position.col, position.row);
                                        Console.Write('*');
                                    }
                                    Thread.Sleep(100 - delay);
                                }


                            }
                            foreach (Position position in snakeElements)
                            {
                                Console.SetCursorPosition(position.col, position.row);
                                Console.Write('*');
                            }

                           
                            foreach (Position position in secondSnakeElements)
                            {
                                Console.SetCursorPosition(position.col, position.row);
                                Console.Write('#');
                            }
                            if (enemyFoodCounter == 3 && shownText2 == false)
                            {
                                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                                Console.WriteLine("Oh no, it's eating my apples !?!?");
                                Thread.Sleep(1500);
                                shownText2 = true;
                            }
                            if (enemyFoodCounter == 7 && shownText3 == false)
                            {
                                Console.SetCursorPosition(0, Console.WindowHeight / 2);
                                Console.WriteLine("Play smart! There is no chance to outrun it!\nYou can pause the game to see how you're doing");
                                Thread.Sleep(3000);
                                shownText3 = true;
                            }
                            //if (enemyFoodCounter > foodCounter)
                            //{
                            //    goto breakout;
                            //}
                            Thread.Sleep(100 - delay);
                        } //closing the inner while (true) cycle                        
                    }

                    foreach (Position position in snakeElements)
                    {
                        Console.SetCursorPosition(position.col, position.row);
                        Console.Write('*');
                    }
                    Thread.Sleep(100 - delay);

                }//closing outer while (true) cycle
            breakout:
                if (enemyFoodCounter > foodCounter)
                {
                    Console.SetCursorPosition(0, Console.WindowHeight / 2);
                    Console.WriteLine("Game Over! You let the other snake eat more apples than you. Your score is {0}", foodCounter);
                    Console.ReadKey();
                }
                else
                { 
                Console.SetCursorPosition(0, Console.WindowHeight / 2);
                Console.WriteLine("Game Over! Your score is {0}", foodCounter);
                Console.ReadKey();
                
                }
                      
            }




        }
    }
}


