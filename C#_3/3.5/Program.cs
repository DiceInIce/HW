using System;
using System.Numerics;
using System.Xml.Linq;

class Magazine
{
    private string _name = "";
    private int _year = 1900;
    private string _description = "";
    private string _phone = "";
    private string _email = "";

    public void InputData()
    {
        Console.Write("Введите название журнала: ");
        _name = Console.ReadLine();
        Console.Write("Введите год основания: ");
        _year = int.Parse(Console.ReadLine());
        Console.Write("Введите описание: ");
        _description = Console.ReadLine();
        Console.Write("Введите контактный телефон: ");
        _phone = Console.ReadLine();
        Console.Write("Введите контактный e-mail: ");
        _email = Console.ReadLine();
    }

    public void DisplayData()
    {
        Console.WriteLine($"\nЖурнал: {_name}\nГод основания: {_year}\nОписание: {_description}\nТелефон: {_phone}\nEmail: {_email}");
    }

    public string GetName() => _name;
    public void SetName(string value) => _name = value;

    public int GetYear() => _year;
    public void SetYear(int value) => _year = value;

    public string GetDescription() => _description;
    public void SetDescription(string value) => _description = value;

    public string GetPhone() => _phone;
    public void SetPhone(string value) => _phone = value;

    public string GetEmail() => _email;
    public void SetEmail(string value) => _email = value;
}
class Program
{
    static void Main()
    {
        Console.WriteLine("---- Создание объекта 'Журнал' ----");
        Magazine magazine = new Magazine();

        magazine.InputData();
        magazine.DisplayData();

        Console.WriteLine("\nИзменим год основания через SetYear:");
        magazine.SetYear(2024);
        Console.WriteLine($"Новый год основания: {magazine.GetYear()}");
    }
}