
public abstract class Worker
{
    public abstract void Print();
}

public class President : Worker
{
    public override void Print()
    {
        Console.WriteLine("Я устал, я ухожу\n");
    }
}

public class Security : Worker
{
    public override void Print()
    {
        Console.WriteLine("Ох рано встает охрана\n");
    }
}

public class Manager : Worker
{
    public override void Print()
    {
        Console.WriteLine("Поколения за поколениями люди работают на ненавистных работах только для того, чтобы иметь возможность купить то, что им не нужно\n");
    }
}

public class Engineer : Worker
{
    public override void Print()
    {
        Console.WriteLine("Крутой чел\n");
    }
}

internal class Programm
{
    static void Main()
    {
        President president = new President();
        Security security = new Security();
        Manager manager = new Manager();
        Engineer engineer = new Engineer();

        president.Print();
        security.Print();
        manager.Print();
        engineer.Print();

    }

}