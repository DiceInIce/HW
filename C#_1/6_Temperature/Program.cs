using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("1 — из Фаренгейта в Цельсий");
        Console.WriteLine("2 — из Цельсия в Фаренгейт");
        Console.Write("Ваш выбор: ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Введите температуру: ");
        double temp = double.Parse(Console.ReadLine());

        if (choice == 1)
        {
            double celsius = (temp - 32) * 5 / 9;
            Console.WriteLine($"Результат: {celsius:F2} °C");
        }
        else if (choice == 2)
        {
            double fahrenheit = temp * 9 / 5 + 32;
            Console.WriteLine($"Результат: {fahrenheit:F2} °F");
        }
        else
        {
            Console.WriteLine("Неверный выбор!");
        }
    }
}