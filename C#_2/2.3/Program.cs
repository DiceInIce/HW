using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите текст: ");
        string text = Console.ReadLine();

        Console.Write("Введите сдвиг (например, 3): ");
        int shift = int.Parse(Console.ReadLine());

        string encrypted = Caesar(text, shift);
        string decrypted = Caesar(encrypted, -shift);

        Console.WriteLine($"\nЗашифровано: {encrypted}");
        Console.WriteLine($"Расшифровано: {decrypted}");
    }

    static string Caesar(string input, int shift)
    {
        string result = "";
        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                char baseChar = char.IsUpper(c) ? 'A' : 'a';
                result += (char)((((c - baseChar) + shift + 26) % 26) + baseChar);
            }
            else
            {
                result += c;
            }
        }
        return result;
    }
}