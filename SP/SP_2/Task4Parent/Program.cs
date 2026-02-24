using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Введите полный путь к файлу: ");
        string? filePath = Console.ReadLine();

        Console.Write("Введите слово для поиска: ");
        string? word = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filePath) || string.IsNullOrWhiteSpace(word))
        {
            Console.WriteLine("Файл и слово должны быть заданы.");
            return;
        }

        string childPath = GetChildPath();

        if (!File.Exists(childPath))
        {
            Console.WriteLine($"Не найден дочерний: {childPath}");
            return;
        }

        var psi = new ProcessStartInfo
        {
            FileName = childPath,
            Arguments = $"\"{filePath}\" \"{word}\"",
            UseShellExecute = false
        };

        try
        {
            using Process? child = Process.Start(psi);

            if (child == null)
            {
                Console.WriteLine("Не удалось запустить Task4Child.exe");
                return;
            }

            child.WaitForExit();
            Console.WriteLine($"Task4Child завершён. Код: {child.ExitCode}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка запуска дочернего процесса: {ex.Message}");
        }
    }

    private static string GetChildPath()
    {
        // 1. Пытаемся найти рядом с текущим .exe
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        string directPath = Path.Combine(baseDir, "Task4Child.exe");
        if (File.Exists(directPath))
            return directPath;

        // 2. Пытаемся найти в типичной структуре ...\SP_2\Task4Child\bin\<Config>\<TFM>\Task4Child.exe
        var currentDir = new DirectoryInfo(baseDir);
        // baseDir: ...\Task4Parent\bin\Debug\net8.0\
        var tfmDir = currentDir;
        var configDir = tfmDir.Parent;
        var binDir = configDir?.Parent;
        var projectDir = binDir?.Parent;
        var solutionDir = projectDir?.Parent;

        if (solutionDir != null && configDir != null && tfmDir != null)
        {
            string candidate = Path.Combine(
                solutionDir.FullName,
                "Task4Child",
                "bin",
                configDir.Name,
                tfmDir.Name,
                "Task4Child.exe");

            if (File.Exists(candidate))
                return candidate;
        }

        // Возвращаем путь "по умолчанию" рядом с exe — он просто не найдётся, и выше выведется ошибка
        return directPath;
    }
}

