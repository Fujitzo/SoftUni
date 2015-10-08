using System;
using System.Collections.Generic;

class ToTheStars
{
    static void Main()
    {
        Dictionary<string, Tuple<double, double>> starSystemsDictionary = new Dictionary<string, Tuple<double, double>>();

        string startSystemName = String.Empty;
        double starSystemCoordinateX = 0;
        double starSystemCoordinateY = 0;
        string[] starSystemsTokens;
        for (int i = 0; i < 3; i++)
        {
            starSystemsTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            startSystemName = starSystemsTokens[0];
            starSystemCoordinateX = double.Parse(starSystemsTokens[1]);
            starSystemCoordinateY = double.Parse(starSystemsTokens[2]);

            starSystemsDictionary[startSystemName] = new Tuple<double, double>(starSystemCoordinateX, starSystemCoordinateY);
        }

        string[] spaceshipStartCordinates = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int numberOfMoves = int.Parse(Console.ReadLine());
        double spaceshipX = double.Parse(spaceshipStartCordinates[0]);
        double spaceshipY = double.Parse(spaceshipStartCordinates[1]);

        bool isInStarSystem = false;
        while (numberOfMoves >= 0)
        {
            isInStarSystem = false;
            foreach (var pair in starSystemsDictionary)
            {
                if (IsInStarSystem(pair.Value.Item1, pair.Value.Item2, spaceshipX, spaceshipY))
                {
                    Console.WriteLine(pair.Key.ToLower());
                    isInStarSystem = true;
                    break;
                }
            }

            if (!isInStarSystem)
            {
                Console.WriteLine("space");
            }

            spaceshipY++;
            numberOfMoves--;
        }
    }

    private static bool IsInStarSystem(double starX, double starY, double spaceshipX, double spaceshipY)
    {
        if ((spaceshipX >= starX - 1 && spaceshipX <= starX + 1) && (spaceshipY >= starY - 1 && spaceshipY <= starY + 1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
