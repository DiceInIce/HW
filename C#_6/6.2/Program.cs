
public class Device
{
    public string name { get; set; }
    public string sound { get; set; } = "Бип боп\n";
    public string description { get; set; } = "Какой то девайс";

    public Device (string nm, string desc)
    {
        name = nm;
        description = desc;
    }

    public void Sound ()
    {
        Console.WriteLine(sound);
        Console.WriteLine(sound);
        Console.WriteLine(sound);
    }

    public void Show()
    {
        Console.WriteLine(name);
    }

    public void Desc()
    {
        Console.WriteLine(description);
    }

}


public class Kettle : Device
{
    public Kettle(string nm, string desc) : base(nm, desc)
    {
        name = nm;
        description = desc;
        sound = "Бульк бульк бульк";
    }
}

public class Microwave : Device
{
    public Microwave(string nm, string desc) : base(nm, desc)
    {
        name = nm;
        description = desc;
        sound = "Вжжжжжжжжж\n";
    }
}

public class Car : Device
{
    public Car(string nm, string desc) : base(nm, desc)
    {
        name = nm;
        description = desc;
        sound = "Врум врум врум\n";
    }
}

public class Steamboat : Device
{
    public Steamboat(string nm, string desc) : base(nm, desc)
    {
        name = nm;
        description = desc;
        sound = "Без понятие как написать звук парохода\n";
    }
}


internal class Programm
{
    static void Main()
    {
        Kettle chainik = new Kettle("Bosch", "Обычный чайник");
        Microwave pechka = new Microwave("Samsung", "Обычная печка");
        Car brichka = new Car("Lada", "Тазы валят");
        Steamboat parahod = new Steamboat("Parahodic", "Паром");

        chainik.Show();
        chainik.Desc();
        chainik.Sound();

        pechka.Show();
        pechka.Desc();
        pechka.Sound();

        brichka.Show();
        brichka.Desc();
        brichka.Sound();

        parahod.Show();
        parahod.Desc();
        parahod.Sound();
    }
}