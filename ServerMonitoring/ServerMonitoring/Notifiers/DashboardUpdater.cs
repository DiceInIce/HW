using ServerMonitoring.Models;
using ServerMonitoring.Monitoring;
using ServerMonitoring.Notifiers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitoring.Notifiers
{
    internal class DashboardUpdater : INotifier
    {
        public List<Server> dashboard = new List<Server>();

        public DashboardUpdater(ServerMonitor monitor) 
        {
            dashboard = ServerMonitor.servers;
        }

        public void HandlePerformanceAlert(Server server)
        {
            Console.Clear();
            Console.WriteLine("---------------Dashboard----------------");
            foreach (var s in dashboard) {
                Console.WriteLine($"Сервер {s.Name} ({s.IPAddress}): Статус - {s.Status}, CPU - {s.CPUUsage.ToString("F2")}, RAM - {s.MemoryUsage.ToString("F2")}, обновлено - {s.LastUpdated} ");
            }
            Console.WriteLine("----------------------------------------");
        }

        public void HandleServerDown(Server server)
        {
            Console.Clear();
            Console.WriteLine("---------------Dashboard----------------");
            foreach (var s in dashboard)
            {
                Console.WriteLine($"Сервер {s.Name} ({s.IPAddress}): Статус - {s.Status}, CPU - {s.CPUUsage.ToString("F2")}, RAM - {s.MemoryUsage.ToString("F2")}, обновлено - {s.LastUpdated} ");
            }
            Console.WriteLine("----------------------------------------");
        }

        public void HandleStatusChange(Server server)
        {
            Console.Clear();
            Console.WriteLine("---------------Dashboard----------------");
            foreach (var s in dashboard)
            {
                Console.WriteLine($"Сервер {s.Name} ({s.IPAddress}): Статус - {s.Status}, CPU - {s.CPUUsage.ToString("F2")}, RAM - {s.MemoryUsage.ToString("F2")}, обновлено - {s.LastUpdated} ");
            }
            Console.WriteLine("----------------------------------------");
        }
    }
}
