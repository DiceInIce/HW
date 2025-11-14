using ServerMonitoring.Notifiers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitoring.Monitoring
{
    public class AlertManager
    {
        public void ChangeCPUWarn(double num)
        {
            if (num >= 0 && num < 100 
                && ServerMonitor.warnCPU + num < ServerMonitor.overlCPU
                && ServerMonitor.warnCPU + num < ServerMonitor.maxCPUUsage) ServerMonitor.warnCPU = num;
            else Console.WriteLine("Неправильно заданный порог");
        }
        public void ChangeCPUOverload(double num)
        {
            if (num >= 0 && num < 100 
                && ServerMonitor.overlCPU + num > ServerMonitor.warnCPU
                && ServerMonitor.overlCPU + num < ServerMonitor.maxCPUUsage) ServerMonitor.overlCPU = num;
            else Console.WriteLine("Неправильно заданный порог");
        }
        public void ChangeRAMWarn(double num)
        {
            if (num >= 0 && num < 100
                && ServerMonitor.warnRAM+ num < ServerMonitor.maxRAMUsage) ServerMonitor.warnRAM = num;
            else Console.WriteLine("Неправильно заданный порог");
        }
        public void ChangeMaxRAM(double num)
        {
            if (num >= 0 && num <= 100
                && ServerMonitor.maxRAMUsage + num > ServerMonitor.warnRAM) ServerMonitor.maxRAMUsage = num;
            else Console.WriteLine("Неправильно заданный порог");
        }
        public void ChangeMaxCPU(double num)
        {
            if (num >= 0 && num <= 100
                 && ServerMonitor.maxCPUUsage + num > ServerMonitor.overlCPU) ServerMonitor.maxCPUUsage = num;
            else Console.WriteLine("Неправильно заданный порог");
        }

        public void TogglePerformanceAlert(bool param) { 
            ServerMonitor.PerformansAlertToggle = param;
        }
        public void ToggleStatusChange(bool param) { 
            ServerMonitor.StatusChangedToggle = param;
        }
        public void ToggleServerDown(bool param) { 
            ServerMonitor.ServerDownToggle = param;
        }

        public void SetDelay(int d) {
            ServerMonitor.delay = d;
        }
    }
}
