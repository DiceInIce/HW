using System.Linq;
public interface IStorable
{
    int Id { get; }
    // Уникальный идентификатор товара (только для чтения)
    string Name { get; set; } // Название товара
    int QuantityInStock { get; set; } // Количество единиц на складе
    void Restock(int amount); // Метод для пополнения запасов
    bool Sell(int amount); // Метод для резервирования/продажи товара
}

public interface ISearchable
{
    // Метод, который возвращает true, если объект соответствует поисковому запросу
    bool MatchesSearch(string searchQuery);
}

public class Product : IStorable, ISearchable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int QuantityInStock { get; set; }

    public Product(int id, string name, int quantityInStock)
    {
        Id = id;
        Name = name;
        QuantityInStock = quantityInStock;
    }

    public bool MatchesSearch(string searchQuery)
    {
        return Name.ToLower().Contains(searchQuery.ToLower());
    }

    public void Restock(int amount)
    {
        QuantityInStock += amount;
    }

    public bool Sell(int amount)
    {
        if (amount <= QuantityInStock && amount > 0)
        {
            QuantityInStock -= amount;
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return $"{Name} ({Id} id) в количестве {QuantityInStock} шт.";
    }
}

public class Warehouse
{
    private List<Product> _products;

    public Warehouse()
    {
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void ListAllProduct()
    {
        Console.WriteLine("\tСписок всех продуктов на складе:");

        foreach (Product product in _products)
        {
            Console.WriteLine(product.ToString());
        }
    }

    public List<Product>? SearchProduct(string searchQuery)
    {
        Console.WriteLine($"\n\tПоиск {searchQuery}:");

        List<Product> searched = _products.Where(p => p.MatchesSearch(searchQuery)).ToList();

        if (searched.Count() > 0) foreach (Product product in searched) Console.WriteLine(product.ToString());
        else Console.WriteLine($"Товара {searchQuery} нет");

        return searched;
    }

    public Product this[int index]
    {
        get
        {
            if (index >= 0 && index < _products.Count)
                return _products[index];
            throw new IndexOutOfRangeException($"Индекс {index} находится вне границ списка товаров.");
        }
    }
    public Product? this[string name]
    {
        get
        {
            Product? res = _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (res == null) Console.WriteLine($"Товара {name} нет");
            return res;
        }
    }

}


internal class Programm
{
    static void Main()
    {
        Warehouse warehouse1 = new Warehouse();

        warehouse1.AddProduct(new Product(141, "Молоко", 45));
        warehouse1.AddProduct(new Product(322, "Хлеб", 101));
        warehouse1.AddProduct(new Product(324, "Хлеб", 144));
        warehouse1.AddProduct(new Product(504, "Пиво", 54));
        warehouse1.AddProduct(new Product(135, "Чипсы", 54));

        warehouse1.ListAllProduct();

        Console.WriteLine("\nПоиск индексаторами:");
        Console.WriteLine(warehouse1[0]);
        Console.WriteLine(warehouse1["Молоко"]);
        Console.WriteLine(warehouse1["Сухарики"]);

        Console.WriteLine("Продажа и пополнение:");
        warehouse1[0].Sell(5);
        warehouse1["Молоко"].Restock(19);

        warehouse1.ListAllProduct();

        Console.WriteLine("\nПоиск через SeatchProduct:");
        List<Product>? searched = warehouse1.SearchProduct("Хлеб");
        List<Product>? searched1 = warehouse1.SearchProduct("Сухарики");

    }
}