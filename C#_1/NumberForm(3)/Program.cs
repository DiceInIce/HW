using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите 4 цифры (по одной за раз):");
        string num = "";

        for (int i = 1; i <= 4; i++)
        {
            char digit;
            while (true)
            {
                Console.Write($"Цифра {i}: ");
                string input = Console.ReadLine();

                if (input.Length == 1 && char.IsDigit(input[0]))
                {
                    digit = input[0];
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите ОДНУ цифру (0–9).");
                }
            }

            num += digit;
        }

        Console.WriteLine($"Получилось число: {num}");
    }
}