using FitnessTracker.Models;
using FitnessTracker.Services;

namespace FitnessTracker.Presentation;

public class WorkoutSessionMenu
{
    private readonly WorkoutSessionService _service;

    public WorkoutSessionMenu(WorkoutSessionService service) => _service = service;

    public void Run()
    {
        bool running = true;
        while (running)
        {
            UIHelper.PrintMenu("УПРАВЛЕНИЕ ТРЕНИРОВКАМИ",
                "1. Добавить новую тренировку",
                "2. Показать все тренировки",
                "3. Найти тренировку по ID",
                "4. Найти тренировки по типу",
                "5. Найти тренировки по диапазону дат",
                "6. Изменить тренировку",
                "7. Удалить тренировку",
                "8. Вернуться в главное меню");

            switch (Console.ReadLine())
            {
                case "1": Add(); break;
                case "2": ShowAll(); break;
                case "3": FindById(); break;
                case "4": FindByType(); break;
                case "5": FindByDateRange(); break;
                case "6": Update(); break;
                case "7": Delete(); break;
                case "8": running = false; break;
                default:
                    UIHelper.Error("Неверный выбор");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void Add()
    {
        Console.Clear();
        Console.WriteLine("=== ДОБАВЛЕНИЕ ТРЕНИРОВКИ ===");
        Console.Write("Дата (yyyy-MM-dd HH:mm): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime date)) { UIHelper.Error("Неверный формат даты"); Console.ReadKey(); return; }

        Console.Write("Длительность (минут): ");
        if (!int.TryParse(Console.ReadLine(), out int duration) || duration <= 0) { UIHelper.Error("Неверная длительность"); Console.ReadKey(); return; }

        Console.Write("Сожженные калории: ");
        if (!int.TryParse(Console.ReadLine(), out int calories) || calories < 0) { UIHelper.Error("Неверное количество калорий"); Console.ReadKey(); return; }

        Console.Write("Тип тренировки: ");
        string sessionType = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(sessionType)) { UIHelper.Error("Тип не может быть пустым"); Console.ReadKey(); return; }

        var session = new WorkoutSession { Date = date, DurationMinutes = duration, CaloriesBurned = calories, SessionType = sessionType };
        _service.Add(session);
        UIHelper.Success($"Тренировка добавлена с ID: {session.Id}");
        Console.ReadKey();
    }

    private void ShowAll()
    {
        Console.Clear();
        var sessions = _service.GetAll();
        if (sessions.Count == 0) { UIHelper.Info("Тренировки не найдены"); Console.ReadKey(); return; }

        Console.WriteLine("=== СПИСОК ТРЕНИРОВОК ===");
        Console.WriteLine(string.Format("{0,-5} {1,-20} {2,-8} {3,-10} {4,-20}", "ID", "Дата", "Мин", "Калории", "Тип"));
        Console.WriteLine(new string('-', 85));
        foreach (var s in sessions)
            Console.WriteLine($"{s.Id,-5} {s.Date:yyyy-MM-dd HH:mm,-20} {s.DurationMinutes,-8} {s.CaloriesBurned,-10} {s.SessionType,-20}");
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }

    private void FindById()
    {
        Console.Clear();
        Console.Write("ID тренировки: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) { UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

        var session = _service.GetById(id);
        if (session == null) { UIHelper.Error("Тренировка не найдена"); Console.ReadKey(); return; }

        Display(session);
        Console.ReadKey();
    }

    private void FindByType()
    {
        Console.Clear();
        Console.Write("Тип тренировки: ");
        string sessionType = Console.ReadLine() ?? "";
        var sessions = _service.GetBySessionType(sessionType);

        if (sessions.Count == 0) { UIHelper.Info("Тренировки не найдены"); Console.ReadKey(); return; }
        Console.WriteLine($"\nНайдено: {sessions.Count}");
        Console.WriteLine(new string('-', 85));
        foreach (var s in sessions) { Display(s); Console.WriteLine(new string('-', 85)); }
        Console.ReadKey();
    }

    private void FindByDateRange()
    {
        Console.Clear();
        Console.Write("Начальная дата (yyyy-MM-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate)) { UIHelper.Error("Неверный формат даты"); Console.ReadKey(); return; }

        Console.Write("Конечная дата (yyyy-MM-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate)) { UIHelper.Error("Неверный формат даты"); Console.ReadKey(); return; }

        var sessions = _service.GetByDateRange(startDate, endDate);
        if (sessions.Count == 0) { UIHelper.Info("Тренировки не найдены"); Console.ReadKey(); return; }
        Console.WriteLine($"\nНайдено: {sessions.Count}");
        Console.WriteLine(new string('-', 85));
        foreach (var s in sessions) { Display(s); Console.WriteLine(new string('-', 85)); }
        Console.ReadKey();
    }

    private void Update()
    {
        Console.Clear();
        Console.Write("ID тренировки: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) { UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

        var session = _service.GetById(id);
        if (session == null) { UIHelper.Error("Тренировка не найдена"); Console.ReadKey(); return; }

        Console.WriteLine("\nТекущие данные:");
        Display(session);

        Console.Write("\nНовая длительность (мин): ");
        string durInput = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(durInput) && int.TryParse(durInput, out int newDur)) session.DurationMinutes = newDur;

        Console.Write("Новые калории: ");
        string calInput = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(calInput) && int.TryParse(calInput, out int newCal)) session.CaloriesBurned = newCal;

        Console.Write("Новый тип: ");
        string newType = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(newType)) session.SessionType = newType;

        if (UIHelper.Confirm("Подтвердить изменения?"))
        {
            _service.Update(session);
            UIHelper.Success("Тренировка обновлена");
        }
        else UIHelper.Info("Отменено");
        Console.ReadKey();
    }

    private void Delete()
    {
        Console.Clear();
        Console.Write("ID тренировки: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) { UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

        var session = _service.GetById(id);
        if (session == null) { UIHelper.Error("Тренировка не найдена"); Console.ReadKey(); return; }

        Console.WriteLine("\nУдаляемая тренировка:");
        Display(session);

        if (UIHelper.Confirm("Вы уверены? Это действие необратимо!"))
        {
            _service.Delete(id);
            UIHelper.Success("Тренировка удалена");
        }
        else UIHelper.Info("Отменено");
        Console.ReadKey();
    }

    private void Display(WorkoutSession s)
    {
        Console.WriteLine($"ID: {s.Id}");
        Console.WriteLine($"Дата: {s.Date:yyyy-MM-dd HH:mm}");
        Console.WriteLine($"Длительность: {s.DurationMinutes} мин");
        Console.WriteLine($"Калории: {s.CaloriesBurned}");
        Console.WriteLine($"Тип: {s.SessionType}");
    }
}
