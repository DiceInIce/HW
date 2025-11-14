using ServerMonitoring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitoring.Monitoring
{
    public class ServerMonitor
    {
        public static List<Server> servers { get; set; } = new();
        public bool MonitoringStarted = false;

        public static int delay = 500;
        public static double maxCPUUsage = 100;
        public static double maxRAMUsage = 100;
        public static double warnCPU = 80;
        public static double overlCPU = 95;
        public static double warnRAM = 85;

        public delegate void ServerMonitorDelegate(Server server);

        public event ServerMonitorDelegate OnServerStatusChanged;
        public event ServerMonitorDelegate OnPerformanceAlert;
        public event ServerMonitorDelegate OnServerDown;

        public static bool StatusChangedToggle = true;
        public static bool PerformansAlertToggle = true;
        public static bool ServerDownToggle = true;

        static public Random r = new Random();


        public void AddServer(Server server)
        {
            servers.Add(server);
        }

        public void DeleteServer(Server server)
        {
            servers.Remove(server);
        }

        public void StatusChanged(ServerStatus status, Server server)
        {
            if (server.Status != status)
            {
                server.Status = status;
                if (StatusChangedToggle) OnServerStatusChanged.Invoke(server);
            }
        }

        public void StartMonitoring()
        {
            MonitoringStarted = true;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Сервера запущены");
            Console.ResetColor();

            while (MonitoringStarted)
            {
                foreach (Server server in servers)
                {
                    double changeCPU = r.Next(-3000, 3000)/100.0; //Проверить правильно ли проценты рандомятся
                    double changeMem = r.Next(-3000, 3000)/100.0;
                    ServerStatus status = (ServerStatus)0;

                    if ((server.CPUUsage + changeCPU) >= 0 && (server.CPUUsage + changeCPU) <= 100) 
                    {
                        server.CPUUsage += changeCPU;
                    }

                    if (server.MemoryUsage + changeMem >= 0 && server.MemoryUsage + changeMem <= 100) 
                    {
                        server.MemoryUsage += changeMem;
                    }

                    if (server.CPUUsage == maxCPUUsage || server.MemoryUsage == maxRAMUsage)
                    {
                        status = (ServerStatus)1;
                        StatusChanged(status, server);
                        if (ServerDownToggle) OnServerDown.Invoke(server);
                    }
                    else if (server.CPUUsage > overlCPU) { 
                        status = (ServerStatus)2;
                        StatusChanged(status, server);
                        if (PerformansAlertToggle) OnPerformanceAlert.Invoke(server); 
                    }
                    else if (server.CPUUsage > warnCPU) { 
                        status = (ServerStatus)3;
                        StatusChanged(status, server);
                        if (PerformansAlertToggle) OnPerformanceAlert.Invoke(server); 
                    }

                    if (server.MemoryUsage > warnRAM && status != (ServerStatus)2) { 
                        status = (ServerStatus)3;
                        StatusChanged(status, server);
                        if (PerformansAlertToggle) OnPerformanceAlert.Invoke(server); 
                    }

                    StatusChanged(status, server);

                    server.LastUpdated = DateTime.Now;
                }

                Thread.Sleep(500);
            }
        }

        public void StopMonitoring() { MonitoringStarted = false; }

    }
}
