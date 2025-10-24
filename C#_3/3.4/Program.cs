using System;

class Website
{
    private string name;
    private string url;
    private string description;
    private string ip;

    public void InputData()
    {
        Console.Write("Введите название сайта: ");
        name = Console.ReadLine();
        Console.Write("Введите путь (URL): ");
        url = Console.ReadLine();
        Console.Write("Введите описание сайта: ");
        description = Console.ReadLine();
        Console.Write("Введите IP адрес: ");
        ip = Console.ReadLine();
    }

    public void DisplayData()
    {
        Console.WriteLine($"\nНазвание: {name}\nURL: {url}\nОписание: {description}\nIP: {ip}");
    }

    public string GetName() => name;
    public void SetName(string value) => name = value;

    public string GetUrl() => url;
    public void SetUrl(string value) => url = value;

    public string GetDescription() => description;
    public void SetDescription(string value) => description = value;

    public string GetIp() => ip;
    public void SetIp(string value) => ip = value;
}
