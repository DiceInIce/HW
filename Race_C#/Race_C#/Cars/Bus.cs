using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race_C_.Cars
{
    public class Bus : Car
    {
        public double MaxSpeed { get; set; }

        public Bus(string name) : base(name)
        {
            MaxSpeed = 60;
        }

        public override void UpdateSpeed()
        {
            int add = random.Next(1, 5);
            Speed += add;
            if (Speed > MaxSpeed) Speed = MaxSpeed;
        }
        public override void Move()
        {
            UpdateSpeed();

            Position += Speed / 60;

            if (Position >= 100)
            {
                Position = 100;
                OnFinish();
            }
        }
    }
}
