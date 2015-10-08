namespace NewGameSnake
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;

    using global::SnakeGame;

    internal class SnakeGame
    {
        private static void Main()
        {
            if (!File.Exists(@"..\..\highscore.txt"))
            {
                using (File.Create(@"..\..\highscore.txt"))
                {
                }
            }


            Console.CursorVisible = false;
            Menu.ConsoleMenu();

            Console.BufferHeight = Console.WindowHeight;
            ConsoleKeyInfo comand = Console.ReadKey();
            if (comand.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();

                string readHighScore = @"..\..\highscore.txt";
                StreamReader reader = new StreamReader(readHighScore);

                using (reader)
                {
                    string line = reader.ReadLine();
                    Console.SetCursorPosition(35, 1);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Highscores:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine();
                    Console.WriteLine();
                    int count = 1;

                    if (line == null)
                    {
                        Console.WriteLine("There is no highscore :(");
                    }

                    while (line != null)
                    {
                        Console.WriteLine("{0}. {1}", count, line);
                        line = reader.ReadLine();
                        count++;
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Press the DEL button if you want to erase the scoreboard!");
                ConsoleKeyInfo delScoreBoard = Console.ReadKey();

                if (delScoreBoard.Key == ConsoleKey.Delete)
                {
                    File.Delete(@"..\..\highscore.txt");
                    Console.WriteLine("The scoreboard has been deleted!");
                }
                Console.WriteLine();
            }

            if (comand.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.SetCursorPosition(35, 10);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Level 1");
                Thread.Sleep(3000);
                Console.Clear();


                int foodCounter = 0;

                byte right = 0;
                byte left = 1;
                byte down = 2;
                byte up = 3;

                Position[] directions = new Position[]
                                            {
                                                new Position(0, 1), //дясно  
                                                new Position(0, -1), //ляво
                                                new Position(1, 0), //долу
                                                new Position(-1, 0), //горе
                                            };
                int snakeSpeed = 100;
                int direction = right;

                int startSnake = 5;

            level1:
                direction = right;
                //food location
                Random randomNumberGenerator = new Random();
                Position food = new Position(
                    randomNumberGenerator.Next(0, Console.WindowHeight),
                    randomNumberGenerator.Next(0, Console.WindowWidth));

                //food drawing
                Console.SetCursorPosition(food.col, food.row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("@");

                Queue<Position> snakeElements = new Queue<Position>();

                //snake begining
                for (int i = 0; i <= startSnake; i++)
                {
                    snakeElements.Enqueue(new Position(0, i));
                }
                bool level = true;
                //#################################################################################################### Level 1 while cycle
                while (level)
                {
                    //moving the snake without pressing a button
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo userInput = Console.ReadKey();
                        //user direction
                        if (userInput.Key == ConsoleKey.RightArrow)
                        {
                            if (direction != left)
                            {
                                direction = right;
                            }
                        }
                        if (userInput.Key == ConsoleKey.LeftArrow)
                        {
                            if (direction != right)
                            {
                                direction = left;
                            }
                        }
                        if (userInput.Key == ConsoleKey.DownArrow)
                        {
                            if (direction != up)
                            {
                                direction = down;
                            }
                        }
                        if (userInput.Key == ConsoleKey.UpArrow)
                        {
                            if (direction != down)
                            {
                                direction = up;
                            }
                        }
                        if (userInput.Key == ConsoleKey.Spacebar)
                        {
                            Console.SetCursorPosition(0, Console.WindowHeight / 2);
                            Console.WriteLine("Your current score is {0}!\nTo resume the game press spacebar again.", foodCounter * 100);
                            userInput = Console.ReadKey();
                            while (userInput.Key != ConsoleKey.Spacebar)
                            {
                                userInput = Console.ReadKey();
                            }
                        }
                    }

                    Position snakeHead = Enumerable.Last(snakeElements);
                    Position nextDirection = directions[direction];
                    Position snakeNewHead = new Position(
                        snakeHead.row + nextDirection.row,
                        snakeHead.col + nextDirection.col);

                    //game over
                    if (snakeNewHead.row < 0 || snakeNewHead.col < 0 || snakeNewHead.row >= Console.WindowHeight
                        || snakeNewHead.col >= Console.WindowWidth || snakeElements.Contains(snakeNewHead))
                    {
                        Console.Clear();
                        Console.SetCursorPosition(35, 10);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(@"Game Over!
                              Your points are: {0}", foodCounter*100);
                        Console.WriteLine();
                        // Highscore Method / read and print from highscore.txt
                        int currentScore = foodCounter * 100; // scores for level 1
                        HighScore(currentScore);

                        return;
                    }

                    //element adding for snake movement
                    snakeElements.Enqueue(snakeNewHead);
                    Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("*");

                    //food crossing
                    if (snakeNewHead.col == food.col && snakeNewHead.row == food.row)
                    {
                        do
                        {
                            food = new Position(
                                randomNumberGenerator.Next(0, Console.WindowHeight),
                                randomNumberGenerator.Next(0, Console.WindowWidth));
                        }
                        while (snakeElements.Contains(food));
                        Console.SetCursorPosition(food.col, food.row);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        snakeSpeed -= 4;
                        foodCounter++;
                    }
                    else
                    {
                        Position lastElement = snakeElements.Dequeue();
                        Console.SetCursorPosition(lastElement.col, lastElement.row);
                        Console.Write(" ");
                    }

                    //slowdown the program process
                    Thread.Sleep(snakeSpeed);

                    if (foodCounter==1)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(35, 5);
                        Console.WriteLine("Congratulations!");
                        Console.WriteLine("You are a champion.");
                        Console.WriteLine();
                        Console.WriteLine("Press Y to become a mazerunner");
                        Console.WriteLine("Press N to keep playing classic snake");

                        ConsoleKeyInfo mazeRunner = Console.ReadKey();

                        if (mazeRunner.Key == ConsoleKey.Y)
                        {
                            level = false;
                        }
                        else if (mazeRunner.Key == ConsoleKey.N)
                        {
                            Console.Clear();
                            goto level1;
                        }
                    }
                }

                //**************************************************************************************************level 2

                Console.Clear();
                Console.SetCursorPosition(35, 10);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Level 2");
                Thread.Sleep(1000);
                Console.Clear();


                right = 0;
                left = 1;
                down = 2;
                up = 3;

                directions = new Position[]
                                 {
                                     new Position(0, 1), //дясно  
                                     new Position(0, -1), //ляво
                                     new Position(1, 0), //долу
                                     new Position(-1, 0), //горе
                                 };

                direction = right;

                //Obstacle drawing
                var obstaclesLevel2 = new List<Position>();

                for (int i = 0; i < Console.WindowWidth - 20; i++)
                {
                    obstaclesLevel2.Add(new Position(6, i));
                    obstaclesLevel2.Add(new Position(12, 20 + i));
                    obstaclesLevel2.Add(new Position(18, i));
                }

                foreach (Position obstacle in obstaclesLevel2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.SetCursorPosition(obstacle.col, obstacle.row);
                    Console.Write("#");
                }

                //food location
                randomNumberGenerator = new Random();
                do
                {
                    food = new Position(
                        randomNumberGenerator.Next(0, Console.WindowHeight),
                        randomNumberGenerator.Next(0, Console.WindowWidth));
                }
                while (snakeElements.Contains(food) || obstaclesLevel2.Contains(food));

                //food drawing
                Console.SetCursorPosition(food.col, food.row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("@");

                snakeElements = new Queue<Position>();

                //snake begining
                for (int i = 0; i <= 5; i++)
                {
                    snakeElements.Enqueue(new Position(0, i));
                }
                level = true;
                //################################################################################################### Level 2 while cycle
                while (level)
                {
                    //moving the snake without pressing a button
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo userInput = Console.ReadKey();

                        //user direction
                        if (userInput.Key == ConsoleKey.RightArrow)
                        {
                            if (direction != left)
                            {
                                direction = right;
                            }
                        }
                        if (userInput.Key == ConsoleKey.LeftArrow)
                        {
                            if (direction != right)
                            {
                                direction = left;
                            }
                        }
                        if (userInput.Key == ConsoleKey.DownArrow)
                        {
                            if (direction != up)
                            {
                                direction = down;
                            }
                        }
                        if (userInput.Key == ConsoleKey.UpArrow)
                        {
                            if (direction != down)
                            {
                                direction = up;
                            }
                        }
                        if (userInput.Key == ConsoleKey.Spacebar)
                        {
                            Console.SetCursorPosition(0, Console.WindowHeight / 2);
                            Console.WriteLine("Your current score is {0}!\nTo resume the game press spacebar again.", foodCounter * 100);
                            userInput = Console.ReadKey();
                            while (userInput.Key != ConsoleKey.Spacebar)
                            {
                                userInput = Console.ReadKey();
                            }
                        }
                    }

                    Position snakeHead = Enumerable.Last(snakeElements);
                    Position nextDirection = directions[direction];
                    Position snakeNewHead = new Position(
                        snakeHead.row + nextDirection.row,
                        snakeHead.col + nextDirection.col);

                    //game over
                    if (snakeNewHead.row < 0 || snakeNewHead.col < 0 || snakeNewHead.row >= Console.WindowHeight
                        || snakeNewHead.col >= Console.WindowWidth || snakeElements.Contains(snakeNewHead)
                        || obstaclesLevel2.Contains(snakeNewHead))
                    {
                        Console.Clear();
                        Console.SetCursorPosition(35, 10);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(@"Game Over!
                             Your points are: {0}", foodCounter*100);
                        Console.WriteLine();
                        // Highscore Method / read and print from highscore.txt
                        int currentScore = foodCounter*100; // score for level 2
                        HighScore(currentScore);

                        return;
                    }

                    //element adding for snake movement
                    snakeElements.Enqueue(snakeNewHead);
                    Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("*");

                    //food crossing
                    if (snakeNewHead.col == food.col && snakeNewHead.row == food.row)
                    {
                        do
                        {
                            food = new Position(
                                randomNumberGenerator.Next(0, Console.WindowHeight),
                                randomNumberGenerator.Next(0, Console.WindowWidth));
                        }
                        while (snakeElements.Contains(food) || obstaclesLevel2.Contains(food));
                        Console.SetCursorPosition(food.col, food.row);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        snakeSpeed -= 4;
                        foodCounter++;
                    }
                    else
                    {
                        Position lastElement = snakeElements.Dequeue();
                        Console.SetCursorPosition(lastElement.col, lastElement.row);
                        Console.Write(" ");
                    }

                    //slowdown the program process
                    Thread.Sleep(snakeSpeed);

                    if (foodCounter==2)
                    {
                        level = false;
                    }
                }

                //*************************************************************************************************************  level 3 beginning

                Console.Clear();
                Console.SetCursorPosition(35, 10);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Level 3");
                Thread.Sleep(1000);
                Console.Clear();

                right = 0;
                left = 1;
                down = 2;
                up = 3;


                directions = new Position[]
                                 {
                                     new Position(0, 1), //дясно  
                                     new Position(0, -1), //ляво
                                     new Position(1, 0), //долу
                                     new Position(-1, 0), //горе
                                 };

                direction = right;

                //Obstacle drawing
                var obstaclesLevel3 = new List<Position>();

                for (int i = 0; i < Console.WindowWidth / 3; i++)
                {
                    obstaclesLevel3.Add(new Position(5, 7 + i));
                    obstaclesLevel3.Add(new Position(10, 7 + i));
                    obstaclesLevel3.Add(new Position(15, 7 + i));
                    obstaclesLevel3.Add(new Position(20, 7 + i));

                    if (i < 19)
                    {
                        obstaclesLevel3.Add(new Position(i + 3, (Console.WindowWidth / 2) + 1));
                        obstaclesLevel3.Add(new Position(i + 3, (Console.WindowWidth / 2) - 2));
                    }

                    obstaclesLevel3.Add(new Position(5, (21 + Console.WindowWidth / 3) + i));
                    obstaclesLevel3.Add(new Position(10, (21 + Console.WindowWidth / 3) + i));
                    obstaclesLevel3.Add(new Position(15, (21 + Console.WindowWidth / 3) + i));
                    obstaclesLevel3.Add(new Position(20, (21 + Console.WindowWidth / 3) + i));
                }

                foreach (Position obstacle in obstaclesLevel3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.SetCursorPosition(obstacle.col, obstacle.row);
                    Console.Write("#");
                }

                //food location
                randomNumberGenerator = new Random();
                do
                {
                    food = new Position(
                        randomNumberGenerator.Next(0, Console.WindowHeight),
                        randomNumberGenerator.Next(0, Console.WindowWidth));
                }
                while (snakeElements.Contains(food) || obstaclesLevel3.Contains(food));

                //food drawing
                Console.SetCursorPosition(food.col, food.row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("@");

                snakeElements = new Queue<Position>();

                //snake begining
                for (int i = 0; i <= 5; i++)
                {
                    snakeElements.Enqueue(new Position(0, i));
                }
                level = true;
                //################################################################################################################ - Level 3 while cycle
                while (level)
                {
                    //moving the snake without pressing a button
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo userInput = Console.ReadKey();

                        //user direction
                        if (userInput.Key == ConsoleKey.RightArrow)
                        {
                            if (direction != left)
                            {
                                direction = right;
                            }
                        }
                        if (userInput.Key == ConsoleKey.LeftArrow)
                        {
                            if (direction != right)
                            {
                                direction = left;
                            }
                        }
                        if (userInput.Key == ConsoleKey.DownArrow)
                        {
                            if (direction != up)
                            {
                                direction = down;
                            }
                        }
                        if (userInput.Key == ConsoleKey.UpArrow)
                        {
                            if (direction != down)
                            {
                                direction = up;
                            }
                        }
                        if (userInput.Key == ConsoleKey.Spacebar)
                        {
                            Console.SetCursorPosition(0, Console.WindowHeight / 2);
                            Console.WriteLine("Your current score is {0}!\nTo resume the game press spacebar again.", foodCounter * 100);
                            userInput = Console.ReadKey();
                            while (userInput.Key != ConsoleKey.Spacebar)
                            {
                                userInput = Console.ReadKey();
                            }
                        }
                    }

                    Position snakeHead = Enumerable.Last(snakeElements);
                    Position nextDirection = directions[direction];
                    Position snakeNewHead = new Position(
                        snakeHead.row + nextDirection.row,
                        snakeHead.col + nextDirection.col);

                    //game over
                    if (snakeNewHead.row < 0 || snakeNewHead.col < 0 || snakeNewHead.row >= Console.WindowHeight
                        || snakeNewHead.col >= Console.WindowWidth || snakeElements.Contains(snakeNewHead)
                        || obstaclesLevel3.Contains(snakeNewHead))
                    {
                        Console.Clear();
                        Console.SetCursorPosition(35, 10);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(@"Game Over!
                             Your points are: {0}", foodCounter * 100);
                        Console.WriteLine();
                        // Highscore Method / read and print from highscore.txt
                        int currentScore = foodCounter * 100; // score for level 3
                        HighScore(currentScore);

                        return;
                    }

                    //element adding for snake movement
                    snakeElements.Enqueue(snakeNewHead);
                    Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("*");

                    //food crossing
                    if (snakeNewHead.col == food.col && snakeNewHead.row == food.row)
                    {
                        do
                        {
                            food = new Position(
                                randomNumberGenerator.Next(0, Console.WindowHeight),
                                randomNumberGenerator.Next(0, Console.WindowWidth));
                        }
                        while (snakeElements.Contains(food) || obstaclesLevel3.Contains(food));
                        Console.SetCursorPosition(food.col, food.row);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        snakeSpeed -= 4;
                        foodCounter++;
                    }
                    else
                    {
                        Position lastElement = snakeElements.Dequeue();
                        Console.SetCursorPosition(lastElement.col, lastElement.row);
                        Console.Write(" ");
                    }
                    if (foodCounter ==3)
                    {
                        level = false;
                    }

                    //slowdown the program process
                    Thread.Sleep(snakeSpeed);
                }
                //************************************************************************************************ Level 4 beginning
                Console.Clear();
                Console.SetCursorPosition(35, 10);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Level 4. Second snake comes along!");
                Thread.Sleep(1000);
                Console.Clear();


                right = 0;
                left = 1;
                down = 2;
                up = 3;

                directions = new Position[]
                                 {
                                     new Position(0, 1), //дясно  
                                     new Position(0, -1), //ляво
                                     new Position(1, 0), //долу
                                     new Position(-1, 0), //горе
                                 };

                direction = right;

                //Obstacle drawing
                //var obstaclesLevel2 = new List<Position>();

                //for (int i = 0; i < Console.WindowWidth - 20; i++)
                //{
                //    obstaclesLevel2.Add(new Position(6, i));
                //    obstaclesLevel2.Add(new Position(12, 20 + i));
                //    obstaclesLevel2.Add(new Position(18, i));
                //}

                //foreach (Position obstacle in obstaclesLevel2)
                //{
                //    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                //    Console.SetCursorPosition(obstacle.col, obstacle.row);
                //    Console.Write("#");
                //}

                //food location
                randomNumberGenerator = new Random();
                do
                {
                    food = new Position(
                        randomNumberGenerator.Next(0, Console.WindowHeight),
                        randomNumberGenerator.Next(0, Console.WindowWidth));
                }
                while (snakeElements.Contains(food)); //obstaclesLevel2.Contains(food));

                //food drawing
                Console.SetCursorPosition(food.col, food.row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("@");

                snakeElements = new Queue<Position>();

                //snake begining
                for (int i = 0; i <= 5; i++)
                {
                    snakeElements.Enqueue(new Position(0, i));
                }

                //second snake beginning

                Queue<Position> secondSnakeElements = new Queue<Position>();
                for (int i = 1; i < 10; i++)
                {
                    secondSnakeElements.Enqueue(new Position(5, i));
                }

                //foreach (Position position in secondSnakeElements)
                //{
                //    Console.SetCursorPosition(position.col, position.row);
                //    Console.ForegroundColor = ConsoleColor.Gray;
                //    Console.Write('#');
                //}
                bool hitCeiling = false;
                bool hitFloor = false;
                bool hitLeftWall = false;
                bool hitRightWall = false;
                level = true;
                //################################################################################################### Level 4 while cycle
                while (level)
                {
                    //moving the snake without pressing a button
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo userInput = Console.ReadKey();

                        //user direction
                        if (userInput.Key == ConsoleKey.RightArrow)
                        {
                            if (direction != left)
                            {
                                direction = right;
                            }
                        }
                        if (userInput.Key == ConsoleKey.LeftArrow)
                        {
                            if (direction != right)
                            {
                                direction = left;
                            }
                        }
                        if (userInput.Key == ConsoleKey.DownArrow)
                        {
                            if (direction != up)
                            {
                                direction = down;
                            }
                        }
                        if (userInput.Key == ConsoleKey.UpArrow)
                        {
                            if (direction != down)
                            {
                                direction = up;
                            }
                        }
                        if (userInput.Key == ConsoleKey.Spacebar)
                        {
                            Console.SetCursorPosition(0, Console.WindowHeight / 2);
                            Console.WriteLine("Your current score is {0}!\n To resume the game press spacebar again.", foodCounter * 100);
                            userInput = Console.ReadKey();
                            while (userInput.Key != ConsoleKey.Spacebar)
                            {
                                userInput = Console.ReadKey();
                            }
                        }
                    }
                    snakeElements.Dequeue();
                    Position snakeHead = Enumerable.Last(snakeElements);
                    Position nextDirection = directions[direction];
                    Position snakeNewHead = new Position(
                        snakeHead.row + nextDirection.row,
                        snakeHead.col + nextDirection.col);

                    //second snake movement generated by a random number

                    int secondDirection = 0;
                    secondDirection = randomNumberGenerator.Next(0, 3);

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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("@");

                    foreach (Position position in secondSnakeElements)
                    {
                        Console.SetCursorPosition(position.col, position.row);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("$");
                    }
                    foreach (Position position in snakeElements)
                    {
                        Console.SetCursorPosition(position.col, position.row);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("*");
                    }



                    //game over
                    if (snakeNewHead.row < 0 || snakeNewHead.col < 0 || snakeNewHead.row >= Console.WindowHeight
                        || snakeNewHead.col >= Console.WindowWidth || snakeElements.Contains(snakeNewHead))
                    {
                        Console.Clear();
                        Console.SetCursorPosition(35, 10);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(@"Game Over!
                             Your points are: {0}", foodCounter * 100);
                        Console.WriteLine();
                        // Highscore Method / read and print from highscore.txt
                        int currentScore = foodCounter * 100; // score for level 4
                        HighScore(currentScore);

                        return;
                    }

                    //element adding for snake movement
                    snakeElements.Enqueue(snakeNewHead);
                    Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("*");

                    //food crossing
                    if (snakeNewHead.col == food.col && snakeNewHead.row == food.row)
                    {
                        do
                        {
                            food = new Position(
                                randomNumberGenerator.Next(0, Console.WindowHeight),
                                randomNumberGenerator.Next(0, Console.WindowWidth));
                        }
                        while (snakeElements.Contains(food) || obstaclesLevel2.Contains(food));
                        Console.SetCursorPosition(food.col, food.row);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        snakeSpeed -= 4;
                        snakeElements.Enqueue(snakeNewHead);
                        foodCounter++;
                    }
                    //else
                    //{
                    //    Position lastElement = snakeElements.Dequeue();
                    //    Console.SetCursorPosition(lastElement.col, lastElement.row);
                    //    Console.Write(" ");
                    //}
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
                    if (foodCounter ==5)
                    {
                        level = false;
                    }
                    //slowdown the program process


                    Thread.Sleep(snakeSpeed);
                }
                //*********************************************************************************************************     Level 5 beginning
                Console.Clear();
                Console.SetCursorPosition(35, 10);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Level 5. This snake is smarter! Watch Out!");
                Thread.Sleep(1000);
                Console.Clear();


                right = 0;
                left = 1;
                down = 2;
                up = 3;

                directions = new Position[]
                                 {
                                     new Position(0, 1), //дясно  
                                     new Position(0, -1), //ляво
                                     new Position(1, 0), //долу
                                     new Position(-1, 0), //горе
                                 };

                direction = right;

                //Obstacle drawing
                //var obstaclesLevel2 = new List<Position>();

                //for (int i = 0; i < Console.WindowWidth - 20; i++)
                //{
                //    obstaclesLevel2.Add(new Position(6, i));
                //    obstaclesLevel2.Add(new Position(12, 20 + i));
                //    obstaclesLevel2.Add(new Position(18, i));
                //}

                //foreach (Position obstacle in obstaclesLevel2)
                //{
                //    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                //    Console.SetCursorPosition(obstacle.col, obstacle.row);
                //    Console.Write("#");
                //}

                //food location
                randomNumberGenerator = new Random();
                do
                {
                    food = new Position(
                        randomNumberGenerator.Next(0, Console.WindowHeight),
                        randomNumberGenerator.Next(0, Console.WindowWidth));
                }
                while (snakeElements.Contains(food)); //obstaclesLevel2.Contains(food));

                //food drawing
                Console.SetCursorPosition(food.col, food.row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("@");

                snakeElements = new Queue<Position>();

                //snake begining
                for (int i = 0; i <= 5; i++)
                {
                    snakeElements.Enqueue(new Position(0, i));
                }
                //second snake declaring and beginning
                secondSnakeElements = new Queue<Position>();
                for (int i = 1; i < 6; i++)
                {
                    secondSnakeElements.Enqueue(new Position(10, i));
                }
                int enemyFoodCounter = 0;
                //################################################################################################### Level 5 while cycle
                while (true)
                {
                    //moving the snake without pressing a button
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo userInput = Console.ReadKey();

                        //user direction
                        if (userInput.Key == ConsoleKey.RightArrow)
                        {
                            if (direction != left)
                            {
                                direction = right;
                            }
                        }
                        if (userInput.Key == ConsoleKey.LeftArrow)
                        {
                            if (direction != right)
                            {
                                direction = left;
                            }
                        }
                        if (userInput.Key == ConsoleKey.DownArrow)
                        {
                            if (direction != up)
                            {
                                direction = down;
                            }
                        }
                        if (userInput.Key == ConsoleKey.UpArrow)
                        {
                            if (direction != down)
                            {
                                direction = up;
                            }
                        }
                        if (userInput.Key == ConsoleKey.Spacebar)
                        {
                            Console.SetCursorPosition(0, Console.WindowHeight / 2);
                            Console.WriteLine("Your current score is {0}!\nYour oponent score is {1}\n To resume the game press spacebar again.", foodCounter * 100, enemyFoodCounter * 100);
                            userInput = Console.ReadKey();
                            while (userInput.Key != ConsoleKey.Spacebar)
                            {
                                userInput = Console.ReadKey();
                            }
                        }
                    }
                    snakeElements.Dequeue();
                    Position snakeHead = Enumerable.Last(snakeElements);
                    Position nextDirection = directions[direction];
                    Position snakeNewHead = new Position(
                        snakeHead.row + nextDirection.row,
                        snakeHead.col + nextDirection.col);

                    //second snake movement generated by a random number

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
                            food = new Position(randomNumberGenerator.Next(0, Console.WindowHeight), randomNumberGenerator.Next(0, Console.WindowWidth));
                            enemyFoodCounter++;
                        }
                    }
                    Position nextSecondDirection = directions[secondDirection];
                    Position secondSnakeNewHead = new Position(secondSnakeHead.row + nextSecondDirection.row, secondSnakeHead.col + nextSecondDirection.col);
                    secondSnakeElements.Enqueue(secondSnakeNewHead);


                    Console.Clear();
                    Console.SetCursorPosition(food.col, food.row);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("@");

                    foreach (Position position in secondSnakeElements)
                    {
                        Console.SetCursorPosition(position.col, position.row);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("$");
                    }
                    foreach (Position position in snakeElements)
                    {
                        Console.SetCursorPosition(position.col, position.row);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("*");
                    }



                    //game over
                    if (snakeNewHead.row < 0 || snakeNewHead.col < 0 || snakeNewHead.row >= Console.WindowHeight
                        || snakeNewHead.col >= Console.WindowWidth || snakeElements.Contains(snakeNewHead))
                    {
                        Console.Clear();
                        Console.SetCursorPosition(35, 10);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(@"Game Over!
                             Your points are: {0}", foodCounter*100);
                        Console.WriteLine();
                        // Highscore Method / read and print from highscore.txt
                        int currentScore = foodCounter * 100; // score for level 4
                        HighScore(currentScore);

                        return;
                    }
                    if (foodCounter < enemyFoodCounter)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(35, 10);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Game Over!\nYou let the other snake eat more apples than you!\nYour points are: {0}", foodCounter * 100);
                        Console.WriteLine();
                        // Highscore Method / read and print from highscore.txt
                        int currentScore = foodCounter * 100; // score for level 4
                        HighScore(currentScore);

                        return;
                    }

                    //element adding for snake movement
                    snakeElements.Enqueue(snakeNewHead);
                    //Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
                    //Console.ForegroundColor = ConsoleColor.Green;
                    //Console.Write("*");

                    //food crossing
                    if (snakeNewHead.col == food.col && snakeNewHead.row == food.row)
                    {
                        do
                        {
                            food = new Position(
                                randomNumberGenerator.Next(0, Console.WindowHeight),
                                randomNumberGenerator.Next(0, Console.WindowWidth));
                        }
                        while (snakeElements.Contains(food) || obstaclesLevel2.Contains(food));
                        Console.SetCursorPosition(food.col, food.row);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        snakeSpeed -= 4;
                        snakeElements.Enqueue(snakeNewHead);
                        foodCounter++;
                    }
                    //else
                    //{
                    //    Position lastElement = snakeElements.Dequeue();
                    //    Console.SetCursorPosition(lastElement.col, lastElement.row);
                    //    Console.Write(" ");
                    //}

                    //slowdown the program process


                    Thread.Sleep(snakeSpeed);
                }




            }
        }
        private static void HighScore(int currentScore)
        {
            Console.CursorVisible = true;
            Console.Write("Please enter your name or leave empty: ");
            string name = Console.ReadLine();
            if (name != "")
            {
                Console.WriteLine("Your score has been saved!");
                Console.WriteLine();
            }
            Dictionary<string, int> scoreBoard = new Dictionary<string, int>();

            MatchCollection matches;
            var rgx = new Regex(@"(\w+\s*\w*\s*\w*)\s-\s(\d+)");

            using (StreamReader reader = new StreamReader(@"..\..\highscore.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    matches = rgx.Matches(line);
                    foreach (Match match in matches)
                    {
                        scoreBoard.Add(match.Groups[1].ToString(), int.Parse(match.Groups[2].Value));
                        line = reader.ReadLine();
                    }
                }
            }
            name += " - " + currentScore;
            matches = rgx.Matches(name);

            foreach (Match match in matches)
            {
                scoreBoard.Add(match.Groups[1].ToString(), int.Parse(match.Groups[2].Value));
            }
            using (StreamWriter writer = new StreamWriter(@"..\..\highscore.txt"))
            {
                foreach (KeyValuePair<string, int> kvp in scoreBoard.OrderByDescending(p => p.Value))
                {
                    writer.WriteLine("{0} - {1}", kvp.Key, kvp.Value);
                }
            }
            Console.WriteLine();
        }
        //кординати на конзолата
        private struct Position
        {
            public int row;

            public int col;

            public Position(int row, int col)
            {
                this.row = row;
                this.col = col;
            }
        }
    }
}