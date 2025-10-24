using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.Write("Введите текст: ");
        string text = Console.ReadLine();

        string[] sentences = text.Split(new[] { ". " }, StringSplitOptions.None);
        for (int i = 0; i < sentences.Length; i++)
        {
            if (sentences[i].Length > 0)
                sentences[i] = char.ToUpper(sentences[i][0]) + sentences[i].Substring(1);
        }

        string result = string.Join(". ", sentences);
        Console.WriteLine("\nРезультат:");
        Console.WriteLine(result);
    }
}
