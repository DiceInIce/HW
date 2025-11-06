public class MusicDevice
{
    public string name { get; set; }
    public string sound { get; set; }
    public string description { get; set; }
    public string history { get; set; }

    public MusicDevice(string nm, string desc)
    {
        name = nm;
        description = desc;
    }

    public void Sound()
    {
        Console.WriteLine(sound);
        Console.WriteLine(sound);
        Console.WriteLine(sound);
    }

    public void Show()
    {
        Console.WriteLine($"\n{name}");
    }

    public void Desc()
    {
        Console.WriteLine(description);
    }
    public void Hist()
    {
        Console.WriteLine(history);
    }

}


public class Violin : MusicDevice
{
    public Violin(string nm, string desc) : base(nm, desc)
    {
        name = nm;
        description = desc;
        sound = "Скрип скрип скрип";
        history = "Современная скрипка была разработана в Северной Италии в XVI веке. Первые скрипки с четырьмя струнами и близкие по форме к современным, созданы в мастерских Андреа Амати из города Кремона. Именно Амати приписывают стандартизацию формы и размеров скрипки, что положило начало её широкому распространению.";
    }
}

public class Trombone : MusicDevice
{
    public Trombone(string nm, string desc) : base(nm, desc)
    {
        name = nm;
        description = desc;
        sound = "Бу бу бу\n";
        history = "Тромбон — духовой медный мундштучный музыкальный инструмент басово-тенорового регистра. В переводе с итальянского языка означает «большая труба»";
    }
}

public class Ukulele : MusicDevice
{
    public Ukulele(string nm, string desc) : base(nm, desc)
    {
        name = nm;
        description = desc;
        sound = "трунь трунь трунь ТРУНЬ\n";
        history = "Укулеле зародился на Гавайских островах во второй половине XIX века. Португальские иммигранты с Мадейры и Азорских островов привезли на острова небольшие гитароподобные инструменты — брагинью и кавакиньо, которые стали прототипами укулеле.";
    }
}

public class Violoncello : MusicDevice
{
    public Violoncello(string nm, string desc) : base(nm, desc)
    {
        name = nm;
        description = desc;
        sound = "Вввуууум вууууум вум\n";
        history = "Появление виолончели относится к началу XVI века. Первоначально инструмент применялся как басовый для сопровождения пения или исполнения на инструменте более высокого регистра. Существовали многочисленные разновидности виолончели, отличавшиеся размерами, количеством струн, строем (чаще всего встречалась настройка на тон ниже современной)";
    }
}
internal class Programm
{
    static void Main()
    {
        Violin skripka = new Violin("Stradivarius", "Дорогущая скрипка");
        Trombone trombone = new Trombone("Омский тромбончик", "Дешевый тромбон");
        Ukulele ukulelechka = new Ukulele("Veston", "Красного цвета");
        Violoncello violonchel = new Violoncello("Antonio Lavazza", "50 тыщ");

        skripka.Show();
        skripka.Desc();
        skripka.Sound();
        skripka.Hist();

        trombone.Show();
        trombone.Desc();
        trombone.Sound();
        trombone.Hist();

        ukulelechka.Show();
        ukulelechka.Desc();
        ukulelechka.Sound();
        ukulelechka.Hist();

        violonchel.Show();
        violonchel.Desc();
        violonchel.Sound();
        violonchel.Hist();

    }
}