using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст:");
        string text = Console.ReadLine();

        Console.Write("Введите недопустимое слово: ");
        string badWord = Console.ReadLine();

        int count = 0;

        string pattern = $@"\b{Regex.Escape(badWord)}\b";
        string result = Regex.Replace(text, pattern, m =>
        {
            count++;
            return new string('*', badWord.Length);
        }, RegexOptions.IgnoreCase);

        Console.WriteLine("\nРезультат:");
        Console.WriteLine(result);
        Console.WriteLine($"\nСтатистика: {count} замен слова \"{badWord}\".");
    }
}
