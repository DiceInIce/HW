using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите шестизначное число: ");
        string number = Console.ReadLine();

        if (number.Length != 6 || !int.TryParse(number, out _))
        {
            Console.WriteLine("Ошибка: нужно ввести шестизначное число.");
            return;
        }

        Console.Write("Введите номер первой позиции для обмена (1–6): ");
        int a = int.Parse(Console.ReadLine()) - 1;
        Console.Write("Введите номер второй позиции для обмена (1–6): ");
        int b = int.Parse(Console.ReadLine()) - 1;

        char[] digits = number.ToCharArray();

        char temp = digits[a];
        digits[a] = digits[b];
        digits[b] = temp;

        Console.WriteLine("Результат: " + new string(digits));
    }
}