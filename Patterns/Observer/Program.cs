public interface INotifier
{
    void Notify(string productName, decimal newPrice);
}

// Класс управления подписками
public class NotificationManager
{
    private List<INotifier> _notifiers = new List<INotifier>();

    public void Subscribe(INotifier subscriber)
    {
        _notifiers.Add(subscriber);
    }

    public void NotifySubs(string productName,  decimal newPrice)
    {
        foreach (INotifier notifier in _notifiers)
        {
            notifier.Notify(productName, newPrice);
        }

        Console.WriteLine("\n");
    }
}

// Главный класс для цен
public class PriceMonitor
{

    public NotificationManager Notifications = new();
    
    public void UpdatePrice(string productName, decimal newPrice)
    {
        Notifications.NotifySubs(productName, newPrice);
    }
}

public class EmailSender : INotifier
{
    private Dictionary<string, decimal> _prices = new();
    private string _email;
    public EmailSender(string email) => _email = email;
    public void Notify(string productName, decimal newPrice)
    {
        decimal oldPrice = _prices.ContainsKey(productName) ? _prices[productName] : 0;
        _prices[productName] = newPrice;
        if (oldPrice > newPrice)
        {
            Console.WriteLine($"Email to {_email}: Цена на {productName} изменилась {oldPrice} до {newPrice}");
        }
    }
}
public class SmsSender : INotifier
{
    private Dictionary<string, decimal> _prices = new();
    private string _number;
    public SmsSender(string number) => _number = number;
    public void Notify(string productName, decimal newPrice)
    {
        decimal oldPrice = _prices.ContainsKey(productName) ? _prices[productName] : 0;
        _prices[productName] = newPrice;

        if (oldPrice !=0 && Math.Abs((newPrice - oldPrice) / oldPrice) * 100 > 20)
        {
            Console.WriteLine($"SMS to {_number}: Большое изменение цены! {productName} : {oldPrice} -> {newPrice}");
        }
    }
}
public class FileLogger : INotifier
{
    private Dictionary<string, decimal> _prices = new();

    private string _filename;
    public FileLogger(string filename) => _filename = filename;
    public void Notify(string productName, decimal newPrice)
    {
        decimal oldPrice = _prices.ContainsKey(productName) ? _prices[productName] : 0;
        _prices[productName] = newPrice; 

        string message = $"{DateTime.Now}: {productName}: {oldPrice} -> {newPrice}";
        Console.WriteLine($"Записано в файл {_filename}: {productName} : {oldPrice} -> { newPrice}");
        File.AppendAllText(_filename, message + Environment.NewLine);
    }
}



class Program
{
    static void Main()
    {
        var monitor = new PriceMonitor();
        // Подписываем разных получателей
        monitor.Notifications.Subscribe(new EmailSender("manager@shop.ru"));
        monitor.Notifications.Subscribe(new SmsSender("+79001112233"));
        monitor.Notifications.Subscribe(new FileLogger("prices.log"));
        // Меняем цены
        monitor.UpdatePrice("Ноутбук", 50000);
        monitor.UpdatePrice("Ноутбук", 45000); // -10%
        monitor.UpdatePrice("Ноутбук", 35000); // -30% - большая скидка!
    }
}