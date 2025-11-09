using HouseBuilder.Interfaces;
using HouseBuilder.Workers;
using HouseBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder.Team
{
    public class Team
    {
        public List<IWorker> Workers { get; } = new List<IWorker>();
        public TeamLeader Leader { get; }

        public Team(TeamLeader leader)
        {
            Leader = leader;
            Workers.Add(leader);
        }

        public void AddWorker(Worker worker)
        {
            Workers.Add(worker);
        }

        public void BuildHouse(House house)
        {
            Console.WriteLine(" Начинается строительство дома...\n");

            var builders = Workers.OfType<Worker>().ToList();
            int workerIndex = 0;

            while (!house.IsComplete)
            {
                var worker = builders[workerIndex];

                var nextPart = house.Parts.FirstOrDefault(p => !p.IsBuilt);
                if (nextPart != null)
                {
                    worker.BuildPart(nextPart);
                }

                Leader.Work(house);

                workerIndex = (workerIndex + 1) % builders.Count;
                Thread.Sleep(500);
            }

            Console.WriteLine("\n++ Все этапы завершены!");
            house.ShowHouse();
        }
    }
}
