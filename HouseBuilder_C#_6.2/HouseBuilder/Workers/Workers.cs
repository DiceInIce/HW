using HouseBuilder.Interfaces;
using HouseBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder.Workers
{
    public class Worker : IWorker
    {
        public string Name { get; }

        public Worker(string name)
        {
            Name = name;
        }

        public void Work(House house)
        {
            // реализация в Team через этапы
        }

        public void BuildPart(IPart part)
        {
            if (!part.IsBuilt)
            {
                part.IsBuilt = true;
                Console.WriteLine($"{Name} построил: {part.Name}");
                Thread.Sleep(400);
            }
        }
    }
}
