using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Полученные аргументы командной строки:");

        if (args.Length < 3)
        {
            Console.WriteLine("Ожидается 3 аргумента: <число1> <число2> <оператор>");
            return;
        }

        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine($"arg[{i}] = {args[i]}");
        }

        string aStr = args[0];
        string bStr = args[1];
        string op = args[2];

        if (!double.TryParse(aStr, out double a) ||
            !double.TryParse(bStr, out double b))
        {
            Console.WriteLine("Не удалось преобразовать аргументы к числам.");
            return;
        }

        double result;
        switch (op)
        {
            case "+":
                result = a + b;
                break;
            case "-":
                result = a - b;
                break;
            case "*":
                result = a * b;
                break;
            case "/":
                if (b == 0)
                {
                    Console.WriteLine("Ошибка: деление на ноль.");
                    return;
                }
                result = a / b;
                break;
            default:
                Console.WriteLine($"Неизвестный оператор: {op}");
                return;
        }

        Console.WriteLine($"Результат: {a} {op} {b} = {result}");
    }
}

