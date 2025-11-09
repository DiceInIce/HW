using HouseBuilder.Interfaces;
using HouseBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder.Workers
{
    public class TeamLeader : IWorker
    {
        public string Name { get; }

        public TeamLeader(string name)
        {
            Name = name;
        }

        public void Work(House house)
        {
            int built = house.Parts.FindAll(p => p.IsBuilt).Count;
            int total = house.Parts.Count;
            Console.WriteLine($"\n Отчет от {Name}: построено {built}/{total} частей ({(built * 100) / total}%).");
        }
    }
}
