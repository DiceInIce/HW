using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitoring.Models
{
    public class Server
    {
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public ServerStatus Status { get; set; } = (ServerStatus)0;
        public double CPUUsage { get; set; } = 0; // в процентах
        public double MemoryUsage { get; set; } = 0; // в процентах
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
