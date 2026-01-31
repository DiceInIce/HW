using FitnessTracker.Models;
using FitnessTracker.Services;

namespace FitnessTracker.Presentation;

public class ExerciseMenu
{
    private readonly ExerciseService _service;

    public ExerciseMenu(ExerciseService service) => _service = service;

    public void Run()
    {
        bool running = true;
        while (running)
        {
            UIHelper.PrintMenu("УПРАВЛЕНИЕ УПРАЖНЕНИЯМИ",
                "1. Добавить новое упражнение",
                "2. Показать все упражнения",
                "3. Найти упражнение по ID",
                "4. Найти упражнения по сложности",
                "5. Найти упражнения по группе мышц",
                "6. Изменить упражнение",
                "7. Удалить упражнение",
                "8. Вернуться в главное меню");

            switch (Console.ReadLine())
            {
                case "1": Add(); break;
                case "2": ShowAll(); break;
                case "3": FindById(); break;
                case "4": FindByDifficulty(); break;
                case "5": FindByMuscleGroup(); break;
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
        Console.WriteLine("=== ДОБАВЛЕНИЕ УПРАЖНЕНИЯ ===");
        Console.Write("Название: ");
        string name = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(name)) { UIHelper.Error("Название не может быть пустым"); Console.ReadKey(); return; }

        Console.Write("Уровень сложности: ");
        string difficulty = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(difficulty)) { UIHelper.Error("Сложность не может быть пустой"); Console.ReadKey(); return; }

        Console.Write("Оборудование: ");
        string equipment = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(equipment)) { UIHelper.Error("Оборудование не может быть пустым"); Console.ReadKey(); return; }

        Console.Write("Группа мышц: ");
        string muscleGroup = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(muscleGroup)) { UIHelper.Error("Группа мышц не может быть пустой"); Console.ReadKey(); return; }

        var exercise = new Exercise { Name = name, DifficultyLevel = difficulty, EquipmentRequired = equipment, TargetMuscleGroup = muscleGroup };
        _service.Add(exercise);
        UIHelper.Success($"Упражнение добавлено с ID: {exercise.Id}");
        Console.ReadKey();
    }

    private void ShowAll()
    {
        Console.Clear();
        var exercises = _service.GetAll();
        if (exercises.Count == 0) { UIHelper.Info("Упражнения не найдены"); Console.ReadKey(); return; }

        Console.WriteLine("=== СПИСОК УПРАЖНЕНИЙ ===");
        Console.WriteLine(string.Format("{0,-5} {1,-20} {2,-15} {3,-20} {4,-20}", "ID", "Название", "Сложность", "Оборудование", "Группа мышц"));
        Console.WriteLine(new string('-', 85));
        foreach (var ex in exercises)
            Console.WriteLine($"{ex.Id,-5} {ex.Name,-20} {ex.DifficultyLevel,-15} {ex.EquipmentRequired,-20} {ex.TargetMuscleGroup,-20}");
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }

    private void FindById()
    {
        Console.Clear();
        Console.Write("ID упражнения: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) { UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

        var exercise = _service.GetById(id);
        if (exercise == null) { UIHelper.Error("Упражнение не найдено"); Console.ReadKey(); return; }

        Display(exercise);
        Console.ReadKey();
    }

    private void FindByDifficulty()
    {
        Console.Clear();
        Console.Write("Уровень сложности: ");
        string difficulty = Console.ReadLine() ?? "";
        var exercises = _service.GetByDifficulty(difficulty);

        if (exercises.Count == 0) { UIHelper.Info("Упражнения не найдены"); Console.ReadKey(); return; }
        Console.WriteLine($"\nНайдено: {exercises.Count}");
        Console.WriteLine(new string('-', 85));
        foreach (var ex in exercises) { Display(ex); Console.WriteLine(new string('-', 85)); }
        Console.ReadKey();
    }

    private void FindByMuscleGroup()
    {
        Console.Clear();
        Console.Write("Группа мышц: ");
        string muscleGroup = Console.ReadLine() ?? "";
        var exercises = _service.GetByMuscleGroup(muscleGroup);

        if (exercises.Count == 0) { UIHelper.Info("Упражнения не найдены"); Console.ReadKey(); return; }
        Console.WriteLine($"\nНайдено: {exercises.Count}");
        Console.WriteLine(new string('-', 85));
        foreach (var ex in exercises) { Display(ex); Console.WriteLine(new string('-', 85)); }
        Console.ReadKey();
    }

    private void Update()
    {
        Console.Clear();
        Console.Write("ID упражнения: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) { UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

        var exercise = _service.GetById(id);
        if (exercise == null) { UIHelper.Error("Упражнение не найдено"); Console.ReadKey(); return; }

        Console.WriteLine("\nТекущие данные:");
        Display(exercise);

        Console.Write("\nНовое название (оставить пустым для пропуска): ");
        string newName = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(newName)) exercise.Name = newName;

        Console.Write("Новая сложность: ");
        string newDiff = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(newDiff)) exercise.DifficultyLevel = newDiff;

        Console.Write("Новое оборудование: ");
        string newEquip = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(newEquip)) exercise.EquipmentRequired = newEquip;

        Console.Write("Новая группа мышц: ");
        string newMuscle = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(newMuscle)) exercise.TargetMuscleGroup = newMuscle;

        if (UIHelper.Confirm("Подтвердить изменения?"))
        {
            _service.Update(exercise);
            UIHelper.Success("Упражнение обновлено");
        }
        else UIHelper.Info("Отменено");
        Console.ReadKey();
    }

    private void Delete()
    {
        Console.Clear();
        Console.Write("ID упражнения: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) { UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

        var exercise = _service.GetById(id);
        if (exercise == null) { UIHelper.Error("Упражнение не найдено"); Console.ReadKey(); return; }

        Console.WriteLine("\nУдаляемое упражнение:");
        Display(exercise);

        if (UIHelper.Confirm("Вы уверены? Это действие необратимо!"))
        {
            _service.Delete(id);
            UIHelper.Success("Упражнение удалено");
        }
        else UIHelper.Info("Отменено");
        Console.ReadKey();
    }

    private void Display(Exercise ex)
    {
        Console.WriteLine($"ID: {ex.Id}");
        Console.WriteLine($"Название: {ex.Name}");
        Console.WriteLine($"Сложность: {ex.DifficultyLevel}");
        Console.WriteLine($"Оборудование: {ex.EquipmentRequired}");
        Console.WriteLine($"Группа мышц: {ex.TargetMuscleGroup}");
    }
}
