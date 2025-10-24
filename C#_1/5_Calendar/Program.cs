using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.Write("Введите дату (в формате дд.мм.гггг): ");
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);

        string season = "";
        int month = date.Month;

        if (month == 12 || month == 1 || month == 2) season = "Winter";
        else if (month >= 3 && month <= 5) season = "Spring";
        else if (month >= 6 && month <= 8) season = "Summer";
        else season = "Autumn";

        string dayOfWeek = date.ToString("dddd", new CultureInfo("en-US"));
        Console.WriteLine($"{season} {dayOfWeek}");
    }
}