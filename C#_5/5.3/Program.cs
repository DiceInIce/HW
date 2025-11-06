using System.Linq;

public class Book
{
    public string name { get; set; }
    public string description { get; set; }
    public int year { get; set; }
    public string author { get; set; }

    public Book(string nm, string desc, int yr, string auth )
    {
        name = nm;
        description = desc;
        year = yr;
        author = auth;
    }

    public void DisplayBook()
    {
        Console.WriteLine($"Книга {name}, {year} года, автор - {author}. Описание: {description}\n");
    }
}

public class Library
{
    private string _name;
    public List<Book> books;

    public Library(string name) { _name = name; }


    public void DisplayAll()
    {
        Console.WriteLine($"\n----- {_name} -----\n");
        foreach (Book book in books) book.DisplayBook();
        Console.WriteLine($"-------------------------\n\n");
    }

    public void BooksCount()
    {
        books.Count();
    }

    public Book GetBook(int i)
    {
        return books[i];
    }

    public void SortBy(string prop)
    {
        switch (prop.ToLower()) {
            case "name":
                books.Sort((b1, b2) => b1.name.CompareTo(b2.name));
                break;
            case "year":
                books.Sort((b1, b2) => b1.year.CompareTo(b2.year));
                break;
            case "author":
                books.Sort((b1, b2) => b1.author.CompareTo(b2.author));
                break;
        }
    }

    public void FindBookByName (string value)
    {
        if (books.FindAll(i => i.name == value) != null) 
        {
            Console.WriteLine($"\nПоиск книги {value}:");
            books.FirstOrDefault(i => i.name == value).DisplayBook();
              
        } else Console.WriteLine("Такой книги нет\n");
    }

    public void FindBooksByYear (int year)
    {
        var matchBooks = books.Where(b => b.year == year);
        if (matchBooks.Any())
        {
            Console.WriteLine($"\nПоиск книг по {year} году:");
            foreach (var i in matchBooks) i.DisplayBook();
        }
        else Console.WriteLine("Нет книг такого года");
    }

    public void FindBooksByAuthor(string author)
    {
        var matchBooks = books.Where(b => b.author == author);
        if (matchBooks.Any())
        {
            Console.WriteLine($"\nПоиск книг автора {author}:");
            foreach (var i in matchBooks) i.DisplayBook();
        }
        else Console.WriteLine("Нет книг такого автора");
    }

    public Book this[int index]
    {
        get { return books[index]; }
        set { books[index] = value; }
    }

    public static Library operator +(Library a, Book b)
    {
        a.books.Add(b);
        return a;
    }

    public static Library operator -(Library a, Book b)
    {
        a.books.Remove(b);
        return a;
    }

    public static bool operator ==(Library a, Book b)
    {
        return a.books.Contains(b);
    }
    public static bool operator !=(Library a, Book b)
    {
        return !(a.books.Contains(b));
    }

}


class Program
{
    static void Main()
    {

        Library lib = new Library("Моя библиотека");
        lib.books = new List<Book>();

        Book b1 = new Book("Понедельник начинается в субботу", "Чудесная книга", 1965, "Стругацкие");
        Book b2 = new Book("Скотный двор", "Аллюзия на коммунизм", 1945, "Оруэлл");
        Book b3 = new Book("Приступление и наказание", "Радикальные методы решения жилищного вопроса", 1866, "Достоевский");

        lib += b1;
        lib += b2;
        lib += b3;

        Console.WriteLine("\nCортируем книги");
        lib.DisplayAll();

        Console.WriteLine("\nПо имени");
        lib.SortBy("name");
        lib.DisplayAll();

        Console.WriteLine("\nПо году");
        lib.SortBy("year");
        lib.DisplayAll();

        Console.WriteLine("\nПо автору");
        lib.SortBy("author");
        lib.DisplayAll();

        lib.FindBookByName("Скотный двор");
        lib.FindBooksByYear(1965);
        lib.FindBooksByAuthor("Достоевский");


        Console.WriteLine("\nПроверка на наличии книг 1 и 2");
        Console.WriteLine(lib == b2);
        Console.WriteLine(lib != b2);

        Console.WriteLine("\nУдаляем 2 книгу");
        lib -= b2;
        lib.DisplayAll();

        Console.WriteLine("\nПерезаписываем книгу\n");
        Book first = lib[0];
        first.DisplayBook();
        lib[0] = new Book("О дивный новый мир", "Гамлет нового мира", 2019, "Хаксли");
        lib[0].DisplayBook();

        Console.WriteLine($"Книг в библиотеке: {lib.books.Count}");

    }

}