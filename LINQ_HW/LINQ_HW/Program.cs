using System.Linq;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }

    public override string ToString()
    {
        return $"{Name} {Age} {City}";
    }

}

public class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public override string ToString()
    {
        return $"{Name} {Category} {Price} {Stock}";
    }
}

internal class Program
{


    static void Main(string[] args)
    {
        void PrintNums(IEnumerable<int> nums) { foreach (int i in nums) { Console.Write($"{i} "); } }
        void PrintPeoples(IEnumerable<Person> people) { foreach (Person p in people) { Console.WriteLine(p.ToString()); } }
        void PrintProducts(IEnumerable<Product> products) { foreach (Product p in products) { Console.WriteLine(p.ToString()); } }

        Console.WriteLine("Задание 1\n"); // 1111111111111

        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        var evenNums = from n in numbers
                       where n % 2 == 0
                       select n;
        Console.WriteLine("Четные сила :");
        PrintNums(evenNums);


        var someNums = from n in numbers
                       where n > 5 && n < 15
                       select n;
        Console.WriteLine("\nЧисла больше 5 и меньше 15:"); PrintNums(someNums);


        var sumNums = numbers.Sum();
        Console.WriteLine($"\nСумма чисел: {sumNums.ToString()}");


        int maxNum = numbers.Max();
        int minNum = numbers.Min();
        Console.WriteLine($"Максимальное и минимальное: {maxNum.ToString()}, {minNum.ToString()}");


        var sortedDescNums = numbers.OrderDescending();
        Console.WriteLine("Сортировка по убыванию: "); PrintNums(sortedDescNums);


        Console.WriteLine("\n\nЗадание 2\n"); // 2222222222222

        List<Person> people = new List<Person> {
            new Person { Name = "Анна", Age = 25, City = "Москва" },
            new Person { Name = "Иван", Age = 30, City = "Санкт-Петербург" },
            new Person { Name = "Мария", Age = 22, City = "Москва" },
            new Person { Name = "Петр", Age = 35, City = "Казань" },
            new Person { Name = "Ольга", Age = 28, City = "Москва" }
        };


        var peopleOver25 = from p in people
                           where p.Age > 25
                           select p;
        Console.WriteLine("\nСтарше 25: "); PrintPeoples(peopleOver25);


        var peopleFromMoscow = from p in people
                               where p.City == "Москва"
                               select p;
        Console.WriteLine("\nЛюди из Москвы: "); PrintPeoples(peopleFromMoscow);


        var groupedByCity = people.GroupBy(p => p.City);
        Console.WriteLine("\nГруппировка по городам: ");
        foreach (var group in groupedByCity)
        {
            Console.WriteLine($"Город: {group.Key}");

            foreach (var person in group) Console.WriteLine(person.ToString());

            Console.WriteLine();
        }


        var averageAge = people.Average(p => p.Age);
        Console.WriteLine($"\nСредний возраст: {averageAge}");


        var sortedDescAge = people.OrderByDescending(p => p.Age);
        Console.WriteLine("\nСортировка по убыванию возраста: "); PrintPeoples(sortedDescAge);


        Console.WriteLine("\n\nЗадание 3\n"); //33333333333333

        List<Product> products = new List<Product>
        {
            new Product { Name = "Ноутбук", Category = "Электроника", Price = 50000, Stock = 10 },
            new Product { Name = "Мышь", Category = "Электроника", Price = 1500, Stock = 25 },
            new Product { Name = "Стул", Category = "Мебель", Price = 8000, Stock = 15 },
            new Product { Name = "Стол", Category = "Мебель", Price = 12000, Stock = 8 },
            new Product { Name = "Клавиатура", Category = "Электроника", Price = 3000, Stock = 0 }
        };


        var missingProducts = from p in products
                              where p.Stock == 0
                              select p;
        Console.WriteLine("Продукты которых нет в наличии:"); PrintProducts(missingProducts);


        var groupedCategory = products.GroupBy(p => p.Category);

        Console.WriteLine("\n\nГруппировка по категории:\n");
        foreach (var category in groupedCategory)
        {
            Console.WriteLine($"Категория: {category.Key}");

            var prodCount = category.Sum(p => p.Stock);
            Console.WriteLine($"Количетсво товара: {prodCount}");

            var averagePrice = category.Average(p => p.Price);
            Console.WriteLine($"Средняя цена: {(int)averagePrice}");

            var mostEpensive = category.OrderByDescending(p => p.Price).FirstOrDefault();
            Console.WriteLine($"Самый дорогой товар: {mostEpensive?.ToString()}");

            Console.WriteLine();
        }


        var productsOver2000 = products.Where(p => p.Price > 2000).OrderByDescending(p => p.Price);
        Console.WriteLine("\n\nТовары дороже 2000 и сортированные по убыванию:\n");
        PrintProducts(productsOver2000);


        var allCost = products.Sum(p => p.Price * p.Stock);
        Console.WriteLine($"\n\nОбщая стоимсть всех товаров на складе: {(int)allCost}\n");
    }
}