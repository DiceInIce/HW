using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race_C_.Cars
{
    public abstract class Car
    {
        public string Name { get; set; }
        public double Speed { get; set; }
        public double Position { get; set; }

        public event Action<Car> Finished;

        public static Random random = new Random();

        public Car(string name)
        {
            Name = name;
            Speed = 0;
            Position = 0;
        }
        public abstract void Move();
        public abstract void UpdateSpeed();

        protected void OnFinish()
        {
            Finished?.Invoke(this);
        }
    }
}
