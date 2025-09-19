
namespace AbstactFactory
{
    public interface ITransport
    {
        void deliver();
        string getType();
    }

    public interface ITruck : ITransport
    {
        int getCargoCapacity();

    }

    public interface IShip : ITransport
    {
        int getDisplacement();

    }


    public class CargoTruck : ITruck
    {
        private string _type = "Грузовик";
        private int _capacity = 100;

        public void deliver()
        {
            Console.WriteLine("Грузовик что то доставляет \n");
        }

        public int getCargoCapacity()
        {
            return _capacity;
        }

        public string getType()
        {
            return _type;
        }

    }
    public class PassengerVan : ITruck
    {
        private string _type = "Автобус";
        private int _capacity = 30;

        public void deliver()
        {
            Console.WriteLine("Автобус кого то везет \n");
        }

        public int getCargoCapacity()
        {
            return _capacity;
        }

        public string getType()
        {
            return _type;
        }
    }
    public class CargoShip : IShip
    {
        private string _type = "Грузовой";
        private int _displacement = 1000;

        public void deliver()
        {
            Console.WriteLine("Грузовой корабль что то доставляет \n");
        }

        public int getDisplacement()
        {
            return _displacement;
        }

        public string getType()
        {
            return _type;
        }
    }
    public class PassengerFerry : IShip
    {
        private string _type = "Паром";
        private int _displacement = 80;

        public void deliver()
        {
            Console.WriteLine("Паром кого то везет");
        }

        public int getDisplacement()
        {
            return _displacement;
        }

        public string getType()
        {
            return _type;
        }
    }


    public interface ITransportFactory
    {
        ITruck createTruck();
        IShip createShip();

    }

    public class CargoTransportFactory : ITransportFactory
    {
        public IShip createShip()
        {
            return new CargoShip();
        }

        public ITruck createTruck()
        {
            return new CargoTruck();
        }
    }

    public class PassengerTransportFactory : ITransportFactory
    {
        public IShip createShip()
        {
            return new PassengerFerry();
        }

        public ITruck createTruck()
        {
            return new PassengerVan();
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Создаем грузовые: \n");
            ClientMethod(new CargoTransportFactory());

            Console.WriteLine("Создаем транспортные: \n");
            ClientMethod(new PassengerTransportFactory());

        }

        public void ClientMethod(ITransportFactory factory)
        {
            var truck = factory.createTruck();
            var ship = factory.createShip();

            Console.WriteLine($"- {truck.getType()} с вместимостью {truck.getCargoCapacity()} \n");
            Console.WriteLine($"- {ship.getType()} с вместимостью {ship.getDisplacement()} \n");

        }

    }

    class Program
    {
        static void Main()
        {
            new Client().Main();
        }
    }

}