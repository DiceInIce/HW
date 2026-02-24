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

            Console.Write("Ожидать завершения (W) или принудительно завершить (K)? [W/K]: ");
            char choice = char.ToUpperInvariant(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (choice == 'W')
            {
                child.WaitForExit();
                Console.WriteLine($"Процесс завершён. Код: {child.ExitCode}");
            }
            else if (choice == 'K')
            {
                if (!child.HasExited)
                {
                    child.Kill(true);
                    Console.WriteLine("Процесс принудительно завершён.");
                }
                else
                {
                    Console.WriteLine("Процесс уже успел завершиться.");
                }
            }
            else
            {
                Console.WriteLine("Неизвестный выбор.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка работы с процессом: {ex.Message}");
        }
    }
}

