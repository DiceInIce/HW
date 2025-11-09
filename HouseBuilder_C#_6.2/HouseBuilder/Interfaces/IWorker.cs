using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseBuilder.Models;

namespace HouseBuilder.Interfaces
{
    public interface IWorker
    {
        string Name { get; }
        void Work(House house);
    }
}
