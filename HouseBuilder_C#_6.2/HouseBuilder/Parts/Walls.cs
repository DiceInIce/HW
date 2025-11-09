using HouseBuilder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder.Parts
{
    public class Walls : IPart
    {
        public string Name => "Стена";
        public bool IsBuilt { get; set; }
    }
}
