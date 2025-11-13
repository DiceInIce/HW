
using Race_C_.MainRace;
using Race_C_.Cars;
using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace RacingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Race race = new();
            int count = 0;

            race.AddCar(new SportCar("Феррари"));
            race.AddCar(new SportCar("Ламборгини"));
            race.AddCar(new SimpleCar("Копейка"));
            race.AddCar(new SimpleCar("Лада"));
            race.AddCar(new Truck("Дальнобой"));
            race.AddCar(new Bus("Маршрутка"));

            race.OnStart += (car) => Console.WriteLine($"{car.Name} Стартанул");
            race.OnMove += (car) =>
            {
                int progressLength = (int)car.Position;
                string progress = new string('=', progressLength > 100 ? 100 : progressLength / 2);
                Console.WriteLine($"{car.Name,-15}: {progress}> {car.Position:0.0} км (скорость {car.Speed:0.0} км/ч)");
            };
            race.OnFinish += (car) => Console.WriteLine($"{car.Name} пересёк финиш\n");

            race.StartRace();
        }
    }
}