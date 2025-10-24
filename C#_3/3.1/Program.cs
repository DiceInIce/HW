using System;

class Program
{
    static void Main()
    {
        PrintSquare(5, '#');
    }

    static void PrintSquare(int size, char symbol)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(symbol);
            }
            Console.WriteLine();
        }
    }
}