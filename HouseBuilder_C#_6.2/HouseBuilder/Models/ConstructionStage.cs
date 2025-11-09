using HouseBuilder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder.Models

{
    public class ConstructionStage
    {
        public string Name { get; }
        public List<IPart> Parts { get; }

        public ConstructionStage(string name, List<IPart> parts)
        {
            Name = name;
            Parts = parts;
        }
    }
}
