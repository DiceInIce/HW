using HouseBuilder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder.Parts
{
    public class Door : IPart
    {
        public string Name => "Дверь";
        public bool IsBuilt { get; set; }
    }
}
