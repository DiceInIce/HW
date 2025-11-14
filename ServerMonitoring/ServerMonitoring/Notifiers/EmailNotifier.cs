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
    internal class EmailNotifier : INotifier
    {
        public void HandlePerformanceAlert(Server server)
        {
            if (server.Status == (ServerStatus)3 && server.CPUUsage > ServerMonitor.warnCPU)
            {
                Console.WriteLine($"EMAIL: Сервер {server.Name} превышает использование СPU: {server.CPUUsage.ToString("F2")}%");
            }
            if (server.Status == (ServerStatus)3 && server.MemoryUsage > ServerMonitor.warnRAM)
            {
                Console.WriteLine($"EMAIL: Сервер {server.Name} превышает использование RAM: {server.MemoryUsage.ToString("F2")}%");
            }
            if (server.Status == (ServerStatus)2 && server.CPUUsage > ServerMonitor.overlCPU)
            {
                Console.WriteLine($"EMAIL: Сервер {server.Name} превышает использование СPU: {server.CPUUsage.ToString("F2")}%");
            }
        }
        public void HandleServerDown(Server server)
        {
            Console.WriteLine($"EMAIL: Сервер {server.Name} экстренно завершил работу");
        }
        public void HandleStatusChange(Server server)
        {
            switch (server.Status)
            {
                case (ServerStatus)3:
                    Console.WriteLine($"EMAIL: Сервер {server.Name} сменил статус на {server.Status}.");
                    break;
                case (ServerStatus)2:
                    Console.WriteLine($"EMAIL: Сервер {server.Name} сменил статус на {server.Status}.");
                    break;
                case (ServerStatus)1:
                    Console.WriteLine($"EMAIL: Сервер {server.Name} сменил статус на {server.Status}.");
                    break;
                // Не критическое событие?
                //case (ServerStatus)0:
                //    Console.WriteLine($"EMAIL: Сервер {server.Name} сменил статус на {server.Status}.");
                //    break;
            }
        }
    }
}
