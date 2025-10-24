using System;
using System.Data;

class Program
{
    static void Main()
    {
        Console.Write("Введите выражение (например, 10+5-3): ");
        string expr = Console.ReadLine();

        expr = expr.Replace(" ", "");
        foreach (char c in expr)
        {
            if (!char.IsDigit(c) && c != '+' && c != '-')
            {
                Console.WriteLine("Ошибка: недопустимые символы!");
                return;
            }
        }

        int result = 0;
        int current = 0;
        char operation = '+';

        foreach (char c in expr)
        {
            if (char.IsDigit(c))
            {
                current = current * 10 + (c - '0');
            }
            else
            {
                result = (operation == '+') ? result + current : result - current;
                operation = c;
                current = 0;
            }
        }

        result = (operation == '+') ? result + current : result - current;

        Console.WriteLine($"Результат: {result}");
    }
}
