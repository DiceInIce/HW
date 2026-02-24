using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string childPath = GetChildPath();

        if (!File.Exists(childPath))
        {
            Console.WriteLine($"Не найден дочерний: {childPath}");
            return;
        }

        Console.Write("Введите первое число: ");
        string? first = Console.ReadLine();

        Console.Write("Введите второе число: ");
        string? second = Console.ReadLine();

        Console.Write("Введите оператор (+, -, *, /): ");
        string? op = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(first) ||
            string.IsNullOrWhiteSpace(second) ||
            string.IsNullOrWhiteSpace(op))
        {
            Console.WriteLine("Все три аргумента должны быть заданы.");
            return;
        }

        var psi = new ProcessStartInfo
        {
            FileName = childPath,
            Arguments = $"{first} {second} {op}",
            UseShellExecute = false
        };

        try
        {
            using Process? child = Process.Start(psi);

            if (child == null)
            {
                Console.WriteLine("Не удалось запустить Task3Child.exe");
                return;
            }

            Console.WriteLine($"Запущен дочерний процесс: {childPath} (PID={child.Id})");
            child.WaitForExit();
            Console.WriteLine($"Task3Child завершён. Код: {child.ExitCode}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка запуска дочернего процесса: {ex.Message}");
        }
    }

    private static string GetChildPath()
    {

        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        string directPath = Path.Combine(baseDir, "Task3Child.exe");
        if (File.Exists(directPath))
            return directPath;


        var currentDir = new DirectoryInfo(baseDir);

        var tfmDir = currentDir;
        var configDir = tfmDir.Parent;
        var binDir = configDir?.Parent;
        var projectDir = binDir?.Parent;
        var solutionDir = projectDir?.Parent;

        if (solutionDir != null && configDir != null && tfmDir != null)
        {
            string candidate = Path.Combine(
                solutionDir.FullName,
                "Task3Child",
                "bin",
                configDir.Name,
                tfmDir.Name,
                "Task3Child.exe");

            if (File.Exists(candidate))
                return candidate;
        }

        return directPath;
    }
}

