using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите первое число: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите второе число: ");
        int b = int.Parse(Console.ReadLine());

        if (a > b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        Console.WriteLine($"Чётные числа от {a} до {b}:");
        for (int i = a; i <= b; i++)
        {
            if (i % 2 == 0)
                Console.Write(i + " ");
        }
    }
}