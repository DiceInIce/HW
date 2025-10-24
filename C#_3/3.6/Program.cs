using System;
using System.Net;
using System.Numerics;

class Store
{
    private string _name = "";
    private string _address = "";
    private string _description = "";
    private string _phone = "";
    private string _email = "";

    public void InputData()
    {
        Console.Write("Введите название магазина: ");
        _name = Console.ReadLine();
        Console.Write("Введите адрес: ");
        _address = Console.ReadLine();
        Console.Write("Введите описание профиля: ");
        _description = Console.ReadLine();
        Console.Write("Введите телефон: ");
        _phone = Console.ReadLine();
        Console.Write("Введите e-mail: ");
        _email = Console.ReadLine();
    }

    public void DisplayData()
    {
        Console.WriteLine($"\nМагазин: {_name}\nАдрес: {_address}\nПрофиль: {_description}\nТелефон: {_phone}\nEmail: {_email}");
    }

    // Методы доступа
    public string GetName() => _name;
    public void SetName(string value) => _name = value;

    public string GetAddress() => _address;
    public void SetAddress(string value) => _address = value;

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
        Console.WriteLine("---- Создание объекта 'Магазин' ----");
        Store store = new Store();

        store.InputData();
        store.DisplayData();

        Console.WriteLine("\nИзменим название магазина через SetName:");
        store.SetName("ТехноМаркет");
        Console.WriteLine($"Новое название: {store.GetName()}");
    }
}
