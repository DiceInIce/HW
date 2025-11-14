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

    internal class Logger : INotifier
    {
        public List<string> Logs { get; set; }

        public void HandlePerformanceAlert(Server server)
        {
            if (server.Status == (ServerStatus)3 && server.CPUUsage > ServerMonitor.warnCPU)
            {
                Logs.Add($"Сервер {server.Name} превышает использование СPU: {server.CPUUsage.ToString("F2")}%");
            }
            if (server.Status == (ServerStatus)3 && server.MemoryUsage > ServerMonitor.warnRAM)
            {
                Logs.Add($"Сервер {server.Name} превышает использование RAM: {server.MemoryUsage.ToString("F2")}%");
            }
            if (server.Status == (ServerStatus)2 && server.CPUUsage > ServerMonitor.overlCPU)
            {
                Logs.Add($"Сервер {server.Name} превышает использование СPU: {server.CPUUsage.ToString("F2")}%");
            }
        }
        public void HandleServerDown(Server server)
        {
            Logs.Add($"Сервер {server.Name} экстренно завершил работу");
        }
        public void HandleStatusChange(Server server)
        {
            switch (server.Status)
            {
                case (ServerStatus)3:
                    Logs.Add($"Сервер {server.Name} сменил статус на {server.Status}.");
                    break;
                case (ServerStatus)2:
                    Logs.Add($"Сервер {server.Name} сменил статус на {server.Status}.");
                    break;
                case (ServerStatus)1:
                    Logs.Add($"Сервер {server.Name} сменил статус на {server.Status}.");
                    break;
                case (ServerStatus)0:
                    Logs.Add($"Сервер {server.Name} сменил статус на {server.Status}.");
                    break;
            }
        }
    }
}
