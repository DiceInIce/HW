


public class Money
{
    public int wholePart { get; set; }
    public int hundredths { get; set; }


    public void Print()
    {
        Console.WriteLine($"{wholePart}.{hundredths} $");
    }
}

public class Product : Money
{
    public string name { get; set; }

    public Product( string newName, double price )
    {
        name = newName;
        wholePart =(int)price / 1;
        hundredths =(int) (price % 1 >= 0.10? price % 1 * 100 : price % 1 * 10);
    }

    public void changePrice(int newWhole, int newHundredths)
    {
        wholePart -= newWhole;
        if (hundredths >= newHundredths) {
            hundredths -= newHundredths; 
        } else throw new Exception("Ошибка в центах");

    }
}



internal class Programm
{
    static void Main()
    {
        Product prod = new Product("Арбуз", 10.3);
        Product prod1 = new Product("Футболка", 20.50);

        prod.Print();
        prod1.Print();

        prod.changePrice(2, 10);
        prod1.changePrice(3, 15);

        prod.Print();
        prod1.Print();

    }
}