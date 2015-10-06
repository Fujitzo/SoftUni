using System;


class Sequence1
{
    static void Main(string[] args)
    {
        //int sequence;
        //for (sequence= 2; sequence <= 11; sequence++) ;


        //Console.WriteLine(sequence);

        int sequence;
        for (int i = 2; i <= 11; i++)
        {
            if (i % 2 == 0)
            {
                sequence = i;
            }
            else
            {
                sequence = i * (-1);
            }
           Console.WriteLine(sequence);
        }
    }
}
