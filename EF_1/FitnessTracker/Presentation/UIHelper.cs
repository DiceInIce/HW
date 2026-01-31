namespace FitnessTracker.Presentation;

public static class UIHelper
{
    public static void PrintMenu(string title, params string[] items)
    {
        Console.Clear();
        Console.WriteLine($"=== {title} ===");
        foreach (var item in items) Console.WriteLine(item);
        Console.Write("\nВыберите: ");
    }

    public static void Error(string msg) => Console.WriteLine($"Ошибка: {msg}");
    public static void Success(string msg) => Console.WriteLine($"Успех: {msg}");
    public static void Info(string msg) => Console.WriteLine($"Внимание: {msg}");

    public static bool Confirm(string msg)
    {
        Console.Write($"{msg} (y/n): ");
        return Console.ReadLine()?.ToLower() == "y";
    }
}
