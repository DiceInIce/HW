using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.Write("Введите полный путь к дочернему .exe: ");
        string? path = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(path))
        {
            Console.WriteLine("Путь не задан.");
            return;
        }

        var psi = new ProcessStartInfo
        {
            FileName = path,
            UseShellExecute = false
        };

        try
        {
            using Process? child = Process.Start(psi);

            if (child == null)
            {
                Console.WriteLine("Не удалось запустить процесс.");
                return;
            }

            Console.WriteLine($"Запущен дочерний процесс. PID = {child.Id}. Ждём завершения...");
            child.WaitForExit();
            Console.WriteLine($"Дочерний процесс завершён. Код: {child.ExitCode}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка запуска процесса: {ex.Message}");
        }
    }
}

