using System.Linq;

public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public decimal TotalAmount { get; set; }

    public override string ToString()
    {
        return $"{OrderId} {CustomerName} {TotalAmount}";
    }
}

public class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string City { get; set; }

    public override string ToString()
    {
        return $"{Name} {Email} {City}";
    }
}

public class Student
{
    public string Name { get; set; }
    public int GroupId { get; set; }
    public List<int> Grades { get; set; }

    public override string ToString()
    {
        return $"ID группы ({GroupId}) {Name} {string.Join(",", Grades.ToArray())}";
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        List<Order> orders = new List<Order>
        {
            new Order { OrderId = 1, CustomerName = "Анна", TotalAmount = 15000 },
            new Order { OrderId = 2, CustomerName = "Иван", TotalAmount = 25000 },
            new Order { OrderId = 3, CustomerName = "Мария", TotalAmount = 18000 }
        };

        List<Customer> customers = new List<Customer>
        {
            new Customer { Name = "Анна", Email = "anna@mail.ru", City = "Москва" },
            new Customer { Name = "Иван", Email = "ivan@mail.ru", City = "Санкт-Петербург" },
            new Customer { Name = "Мария", Email = "maria@mail.ru", City = "Москва" },
            new Customer { Name = "Петр", Email = "petr@mail.ru", City = "Казань" }
        };


        Console.WriteLine("Задание 4\n"); // 44444444444444444

        var CustomersOrders = from c in customers
                              join o in orders on c.Name equals o.CustomerName
                              select new
                              {
                                  Name = c.Name,
                                  Email = c.Email,
                                  City = c.City,
                                  OrderId = o.OrderId,
                                  TotalAmount = o.TotalAmount
                              };

        Console.WriteLine("Объединенные заказы с клиентами по имени и вывод по всем заказам");
        foreach (var order in CustomersOrders)
        {
            Console.WriteLine($"ID {order.OrderId} : {order.Name} {order.Email} {order.City} {order.TotalAmount}");
        }

        var sumByCity = customers.GroupJoin(
                                   orders,
                                   c => c.Name,
                                   o => o.CustomerName,
                                   (c, os) => new
                                   {
                                       c.City,
                                       Orders = os
                                   })
                                   .GroupBy(x => x.City)
                                   .Select(g => new
                                   {
                                       City = g.Key,
                                       TotalAmount = g.Sum(x => x.Orders.Sum(o => o.TotalAmount))
                                   });

        Console.WriteLine("\nОбщая сумма заказа для каждого города");

        foreach (var o in sumByCity)
        {
            Console.WriteLine($"{o.City}: {o.TotalAmount}");
        }


        var customersWithNoOrders = customers.ExceptBy(orders.Select(o => o.CustomerName), c => c.Name);

        Console.WriteLine("\nКлиенты без заказа:");
        foreach (var c in customersWithNoOrders)
        {
            Console.WriteLine($"{c.Name} — {c.City}");
        }



        Console.WriteLine("\nЗадание 5\n"); // 555555555

        List<Student> students = new List<Student>
        {
            new Student { Name = "Алексей", GroupId = 1, Grades = new List<int> { 5, 4, 5, 3 } },
            new Student { Name = "Екатерина", GroupId = 1, Grades = new List<int> { 4, 4, 5, 5 } },
            new Student { Name = "Дмитрий", GroupId = 2, Grades = new List<int> { 3, 4, 3, 4 } },
            new Student { Name = "Светлана", GroupId = 2, Grades = new List<int> { 5, 5, 5, 5 } },
            new Student { Name = "Михаил", GroupId = 1, Grades = new List<int> { 4, 3, 4, 4 } }
        };


        var averagePerStudent = from student in students
                                let average = student.Grades.Average()
                                select new { Name = student.Name, AVG = average };

        Console.WriteLine("\nСредний балл для каждого студента:");
        foreach (var student in averagePerStudent)
        {
            Console.WriteLine($"{student.Name} = {student.AVG}");
        }



        var groupedById = students.GroupBy(s => s.GroupId);

        Console.WriteLine("\nСредний балл по группам и лучший ученик:");
        foreach (var group in groupedById)
        {
            Console.WriteLine($"Id({group.Key}) средний = {group.SelectMany(s => s.Grades).Average()}," +
                $" лучший = {group.MaxBy(s => s.Grades.Average())?.Name}");
        }



        var studentsWithFive = from student in students
                               where student.Grades.Any(g => g == 5)
                               select student;

        Console.WriteLine("\nВсе студенты у которых хотя бы одна оценка 5:");
        foreach (var student in studentsWithFive) Console.WriteLine(student.ToString());



        var sortedStudents = students.OrderByDescending(s => s.Grades.Average());
        Console.WriteLine("\nСортировка по убыванию среднего балла:");
        foreach (var student in sortedStudents) Console.WriteLine(student.ToString());


        var students2 = from student in students
                        let average = student.Grades.Average()
                        let gradesCount = student.Grades.Count()
                        select new
                        {
                            Name = student.Name,
                            GroupId = student.GroupId,
                            AVG = average,
                            GradesCount = gradesCount
                        };

        Console.WriteLine("\nОбновленный список с анонимным типом:");

        foreach (var student in students2)
        {
            Console.WriteLine($"Id группы ({student.GroupId}), имя - {student.Name}, средний балл - {student.AVG} , кол-во оценок - {student.GradesCount}");
        }

    }
}