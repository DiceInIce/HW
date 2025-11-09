using HouseBuilder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder.Parts
{
    public class Window : IPart
    {
        public string Name => "Окно";
        public bool IsBuilt { get; set; }
    }
}
