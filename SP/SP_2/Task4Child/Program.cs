using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Ожидаются аргументы: <путь_к_файлу> <слово>");
            return;
        }

        string filePath = args[0];
        string word = args[1];

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл не найден: {filePath}");
            return;
        }

        try
        {
            string text = File.ReadAllText(filePath);
            int count = CountOccurrences(text, word);

            Console.WriteLine(
                $"Слово \"{word}\" встречается в файле {count} раз(а).");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
        }
    }

    static int CountOccurrences(string text, string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            return 0;

        // Считаем только цельные слова, без подстрок вроде "notbicycle"
        var pattern = $@"\b{Regex.Escape(word)}\b";
        var matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);
        return matches.Count;
    }
}

