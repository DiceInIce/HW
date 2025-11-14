

using ServerMonitoring.Models;
using ServerMonitoring.Monitoring;
using ServerMonitoring.Notifiers;

internal class Programm
{
    static void Main(string[] args)
    {
        var monitor = new ServerMonitor();

        var alertsManager = new AlertManager();

        var consoleNotifier = new ConsoleNotifier();

        var emailNotifier = new EmailNotifier();// Подписка на события

        var dashboard = new DashboardUpdater(monitor);

        monitor.OnServerStatusChanged += consoleNotifier.HandleStatusChange;

        monitor.OnPerformanceAlert += consoleNotifier.HandlePerformanceAlert;

        monitor.OnServerDown += emailNotifier.HandleServerDown;// Добавление серверов для мониторинга

        //monitor.OnServerStatusChanged += dashboard.HandleStatusChange;

        //monitor.OnPerformanceAlert += dashboard.HandlePerformanceAlert;

        //monitor.OnServerDown += dashboard.HandleServerDown;

        //alertsManager.ChangeRAMWarn(13);          //Алерт менеджер
        //alertsManager.ToggleStatusChange(false);
        //alertsManager.SetDelay(100);

        monitor.AddServer(new Server { Name = "Web Server", IPAddress = "192.168.1.10" });
        monitor.AddServer(new Server { Name = "DB Server", IPAddress = "192.168.1.20" }); // Запуск мониторинга

        monitor.StartMonitoring();

    }
}