using System;

class Magazine
{
    private string _name = "";
    private int _year = 1900;
    private string _description = "";
    private string _phone = "";
    private string _email = "";
    private int _employeers = 0;

    public Magazine() { }
    public void InputData()
    {
        Console.WriteLine("Введите название журнала: ");
        SetName(Console.ReadLine());
        Console.WriteLine("Введите год основания: ");
        SetYear(int.Parse(Console.ReadLine()));
        Console.WriteLine("Введите описание: ");
        SetDescription(Console.ReadLine());
        Console.WriteLine("Введите контактный телефон: ");
        SetPhone(Console.ReadLine());
        Console.WriteLine("Введите контактный e-mail: ");
        SetEmail(Console.ReadLine());
        Console.WriteLine("Введите количество сотрудников: ");
        SetEmpl(int.Parse(Console.ReadLine()));
    }

    public void DisplayData()
    {
        Console.WriteLine($"\nЖурнал: {_name}\nГод основания: {_year}\nОписание: {_description}\nТелефон: {_phone}\nEmail: {_email} \nСотрудников: {_employeers}");
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

    public int GetEmpl() => _employeers;
    public void SetEmpl(int value) => _employeers = value;

    public static Magazine operator + (Magazine a, int b)
    {
        a.SetEmpl(a.GetEmpl() + b);
        return a;
    }
    public static Magazine operator - (Magazine a, int b)
    {
        a.SetEmpl(a.GetEmpl() - b);
        return a;
    }
    public static bool operator == (Magazine a, Magazine b) { return a.GetEmpl() == b.GetEmpl();}
    public static bool operator < (Magazine a, Magazine b) { return a.GetEmpl() < b.GetEmpl(); }
    public static bool operator > (Magazine a, Magazine b) { return a.GetEmpl() > b.GetEmpl(); }
    public static bool operator != (Magazine a, Magazine b) { return !(a.GetEmpl() == b.GetEmpl()); }
    public override bool Equals (object? obj) {
        if (obj is not Magazine other)
            return false;
        return this.GetEmpl() == other.GetEmpl(); 
    }

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

        Console.WriteLine("\n---- Задание на количество работников ----");

        Magazine magazine1 = new Magazine();

        magazine1.InputData();
        magazine1.DisplayData();

        magazine1 = magazine1 + 2;
        magazine1 = magazine1 - 1;
        magazine1.DisplayData();

        Console.WriteLine(magazine == magazine1);
        Console.WriteLine(magazine < magazine1);
        Console.WriteLine(magazine > magazine1);
        Console.WriteLine(magazine != magazine1);
        Console.WriteLine(magazine.Equals(magazine1));
    }
}