using System;

class Store
{
    private string _name = "";
    private string _address = "";
    private string _description = "";
    private string _phone = "";
    private string _email = "";
    private int _area = 0;

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
        Console.Write("Введите площадь: ");
        _area = int.Parse(Console.ReadLine());
    }

    public void DisplayData()
    {
        Console.WriteLine($"\nМагазин: {_name}\nАдрес: {_address}\nПрофиль: {_description}\nТелефон: {_phone}\nEmail: {_email} \nПлощадь: {_area}");
    }

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

    public int GetArea() => _area;
    public void SetArea(int value) => _area = value;

    public static Store operator + (Store a, int b)
    {
        a.SetArea(a.GetArea() + b);
        return a;
    }
    public static Store operator - (Store a, int b)
    {
        a.SetArea(a.GetArea() - b);
        return a;
    }
    public static bool operator == (Store a, Store b) { return a.GetArea() == b.GetArea(); }
    public static bool operator < (Store a, Store b) { return a.GetArea() < b.GetArea(); }
    public static bool operator > (Store a, Store b) { return a.GetArea() > b.GetArea(); }
    public static bool operator != (Store a, Store b) { return !(a.GetArea() == b.GetArea()); }
    public override bool Equals (object? obj)
    {
        if (obj is not Store other)
            return false;
        return this.GetArea() == other.GetArea();
    }



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

        Console.WriteLine("\n---- Задание на площадь ----");

        Store store1 = new Store();

        store1.InputData();
        store1.DisplayData();

        store1 = store1 + 2;
        store1 = store1 - 1;
        store1.DisplayData();

        Console.WriteLine(store == store1);
        Console.WriteLine(store < store1);
        Console.WriteLine(store > store1);
        Console.WriteLine(store != store1);
        Console.WriteLine(store.Equals(store1));
    }
}
