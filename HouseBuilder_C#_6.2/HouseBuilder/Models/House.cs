using HouseBuilder.Interfaces;
using HouseBuilder.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder.Models
{
    public class House
    {
        public List<IPart> Parts { get; } = new List<IPart>();
        public List<ConstructionStage> Stages { get; } = new List<ConstructionStage>();

        public House()
        {
            var foundation = new List<IPart> { new Basement() };
            var walls = new List<IPart> { new Walls(), new Walls(), new Walls(), new Walls() };
            var door = new List<IPart> { new Door() };
            var windows = new List<IPart> { new Window(), new Window(), new Window(), new Window() };
            var roof = new List<IPart> { new Roof() };

            Stages.Add(new ConstructionStage("Фундамент", foundation));
            Stages.Add(new ConstructionStage("Стены", walls));
            Stages.Add(new ConstructionStage("Дверь", door));
            Stages.Add(new ConstructionStage("Окна", windows));
            Stages.Add(new ConstructionStage("Крыша", roof));

            Parts.AddRange(Stages.SelectMany(s => s.Parts));
        }

        public bool IsComplete => Parts.TrueForAll(p => p.IsBuilt);

        public void ShowHouse()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Дом готов!\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("        /\\");
            Console.WriteLine("       /  \\");
            Console.WriteLine("      /    \\");
            Console.WriteLine("     /______\\");
            Console.WriteLine("    /________\\");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("    | __  __ |");
            Console.WriteLine("    ||  ||  ||");
            Console.WriteLine("    ||__||__||");
            Console.WriteLine("    |   __   |");
            Console.WriteLine("    |  |  |  |");
            Console.WriteLine("    |__|__|__|");
            Console.ResetColor();
        }
    }
}
