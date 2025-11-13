using Race_C_.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race_C_.MainRace
{
    internal class Race
    {
        public delegate void RaceAction(Car car);
        public event RaceAction OnStart;
        public event RaceAction OnMove;
        public event RaceAction OnFinish;

        public List<Car> cars = new List<Car>();
        private bool raceFinished = false;
        public static int count = 1;

        public void AddCar(Car car) {
            car.Finished += CarFinished;
            cars.Add(car);
        }

        public void StartRace()
        {
            Console.WriteLine("Начало гонки");

            foreach (var car in cars)
            {
                OnStart?.Invoke(car);
            }

            while (!raceFinished)
            {
                foreach (var car in cars)
                {

                    car.Move();

                    if (raceFinished) // Я не понимаю, почему без этого происходит еще 1 проскальзывание
                        break;                    // движения, хотя по логике цикл должен прерываться


                    OnMove?.Invoke(car);

                    if (count != cars.Count())
                    {
                        count++;
                    } else
                    {
                        count = 1;
                        Console.WriteLine();
                    }

                    Thread.Sleep(100);
                }
            }
        }

        private void CarFinished(Car car)
        {
            if (!raceFinished) { 
                raceFinished = true;
                OnFinish?.Invoke(car);
                Console.WriteLine($"Гонка завершена, победитель {car.Name}");
                
            }
        }
    }
}
