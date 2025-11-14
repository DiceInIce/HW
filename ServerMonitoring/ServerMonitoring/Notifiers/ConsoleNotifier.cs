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
    public class ConsoleNotifier : INotifier
    {
        public void HandlePerformanceAlert(Server server)
        {
            if (server.Status == (ServerStatus)3 && server.CPUUsage > ServerMonitor.warnCPU)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Сервер {server.Name} превышает использование СPU: {server.CPUUsage.ToString("F2")}%");
                Console.ResetColor();
            } 
            if (server.Status == (ServerStatus)3 && server.MemoryUsage > ServerMonitor.warnRAM) 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Сервер {server.Name} превышает использование RAM: {server.MemoryUsage.ToString("F2")}%");
                Console.ResetColor();
            }
            if (server.Status == (ServerStatus)2 && server.CPUUsage > ServerMonitor.overlCPU)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Сервер {server.Name} превышает использование СPU: {server.CPUUsage.ToString("F2")}%");
                Console.ResetColor();
            }
        }
        public void HandleServerDown(Server server)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Сервер {server.Name} экстренно завершил работу");
            Console.ResetColor();
        }
        public void HandleStatusChange(Server server)
        {
            switch (server.Status)
            {
                case (ServerStatus)3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Сервер {server.Name} сменил статус на {server.Status}.");
                    Console.ResetColor();
                    break;
                case (ServerStatus)2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Сервер {server.Name} сменил статус на {server.Status}.");
                    Console.ResetColor();
                    break;
                case (ServerStatus)1:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"Сервер {server.Name} сменил статус на {server.Status}.");
                    Console.ResetColor();
                    break;
                case (ServerStatus)0:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Сервер {server.Name} в порядке.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
