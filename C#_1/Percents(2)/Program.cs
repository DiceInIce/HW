using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите число: ");
        double value = double.Parse(Console.ReadLine());

        Console.Write("Введите процент: ");
        double percent = double.Parse(Console.ReadLine());

        double result = value * percent / 100;
        Console.WriteLine($"{percent}% от {value} = {result}");
    }
}