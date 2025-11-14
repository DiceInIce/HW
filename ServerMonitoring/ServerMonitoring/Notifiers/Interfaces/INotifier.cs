using ServerMonitoring.Models;
using ServerMonitoring.Monitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitoring.Notifiers.Interfaces
{
    internal interface INotifier
    {
        // Для Задачи 4 для легкого добавления
        public void HandleStatusChange(Server server);
        public void HandlePerformanceAlert(Server server);
        public void HandleServerDown(Server server);

    }
}
