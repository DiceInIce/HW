using FitnessTracker.Models;
using FitnessTracker.Services;

namespace FitnessTracker.Presentation;

public class TrainerMenu
{
	private readonly TrainerService _service;

	public TrainerMenu(TrainerService service) => _service = service;

	public void Run()
	{
		bool running = true;
		while (running)
		{
			UIHelper.PrintMenu("УПРАВЛЕНИЕ ТРЕНЕРАМИ",
					"1. Добавить нового тренера",
					"2. Показать всех тренеров",
					"3. Найти тренера по ID",
					"4. Найти тренеров по специализации",
					"5. Найти тренеров по стажу",
					"6. Изменить тренера",
					"7. Удалить тренера",
					"8. Вернуться в главное меню");

			switch (Console.ReadLine())
			{
				case "1": Add(); break;
				case "2": ShowAll(); break;
				case "3": FindById(); break;
				case "4": FindBySpecialization(); break;
				case "5": FindByExperience(); break;
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
		try
		{
			Console.Clear();
			Console.WriteLine("=== ДОБАВЛЕНИЕ ТРЕНЕРА ===");
			Console.Write("Полное имя: ");
			string fullName = Console.ReadLine() ?? "";
			if (string.IsNullOrWhiteSpace(fullName)) { UIHelper.Error("Имя не может быть пустым"); Console.ReadKey(); return; }

			Console.Write("Специализация: ");
			string specialization = Console.ReadLine() ?? "";
			if (string.IsNullOrWhiteSpace(specialization)) { UIHelper.Error("Специализация не может быть пустой"); Console.ReadKey(); return; }

			Console.Write("Стаж (в годах): ");
			if (!int.TryParse(Console.ReadLine(), out int experienceYears) || experienceYears < 0) { UIHelper.Error("Неверный стаж"); Console.ReadKey(); return; }

			Console.Write("Номер телефона: ");
			string phoneNumber = Console.ReadLine() ?? "";
			if (string.IsNullOrWhiteSpace(phoneNumber)) { UIHelper.Error("Номер телефона не может быть пустым"); Console.ReadKey(); return; }

			var trainer = new Trainer { FullName = fullName, Specialization = specialization, ExperienceYears = experienceYears, PhoneNumber = phoneNumber };
			bool success = _service.Add(trainer);
			if (success)
			{
				LoggerHelper.LogSuccess($"Тренер добавлен: {fullName} (ID: {trainer.Id})");
				UIHelper.Success($"Тренер добавлен с ID: {trainer.Id}");
			}
			else
				LoggerHelper.LogError("Не удалось добавить тренера");
		}
		catch (InvalidOperationException ex)
		{
			LoggerHelper.LogError(ex.Message);
			UIHelper.Error(ex.Message);
		}
		Console.ReadKey();
	}

	private void ShowAll()
	{
		Console.Clear();
		var trainers = _service.GetAll();
		if (trainers.Count == 0) { UIHelper.Info("Тренеры не найдены"); Console.ReadKey(); return; }

		Console.WriteLine("=== СПИСОК ТРЕНЕРОВ ===");
		Console.WriteLine(string.Format("{0,-5} {1,-20} {2,-20} {3,-10} {4,-20}", "ID", "Имя", "Специализация", "Стаж", "Телефон"));
		Console.WriteLine(new string('-', 85));
		foreach (var t in trainers)
			Console.WriteLine($"{t.Id,-5} {t.FullName,-20} {t.Specialization,-20} {t.ExperienceYears,-10} {t.PhoneNumber,-20}");
		Console.WriteLine("\nНажмите любую клавишу...");
		Console.ReadKey();
	}

	private void FindById()
	{
		Console.Clear();
		Console.Write("ID тренера: ");
		if (!int.TryParse(Console.ReadLine(), out int id)) { UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

		var trainer = _service.GetById(id);
		if (trainer == null) { UIHelper.Error("Тренер не найден"); Console.ReadKey(); return; }

		Display(trainer);
		Console.ReadKey();
	}

	private void FindBySpecialization()
	{
		Console.Clear();
		Console.Write("Специализация: ");
		string specialization = Console.ReadLine() ?? "";
		var trainers = _service.GetBySpecialization(specialization);

		if (trainers.Count == 0) { UIHelper.Info("Тренеры не найдены"); Console.ReadKey(); return; }
		Console.WriteLine($"\nНайдено: {trainers.Count}");
		Console.WriteLine(new string('-', 85));
		foreach (var t in trainers) { Display(t); Console.WriteLine(new string('-', 85)); }
		Console.ReadKey();
	}

	private void FindByExperience()
	{
		Console.Clear();
		Console.Write("Минимальный стаж (лет): ");
		if (!int.TryParse(Console.ReadLine(), out int minExperience)) { UIHelper.Error("Неверный формат"); Console.ReadKey(); return; }

		var trainers = _service.GetByMinimumExperience(minExperience);
		if (trainers.Count == 0) { UIHelper.Info("Тренеры не найдены"); Console.ReadKey(); return; }
		Console.WriteLine($"\nНайдено: {trainers.Count}");
		Console.WriteLine(new string('-', 85));
		foreach (var t in trainers) { Display(t); Console.WriteLine(new string('-', 85)); }
		Console.ReadKey();
	}

	private void Update()
	{
		try
		{
			Console.Clear();
			Console.Write("ID тренера: ");
			if (!int.TryParse(Console.ReadLine(), out int id)) { LoggerHelper.LogError("Некорректный ID"); UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

			var trainer = _service.GetById(id);
			if (trainer == null) { LoggerHelper.Log($"Тренер с ID {id} не найден"); UIHelper.Error("Тренер не найден"); Console.ReadKey(); return; }

			Console.WriteLine("\nТекущие данные:");
			Display(trainer);

			Console.Write("\nНовое имя: ");
			string newName = Console.ReadLine() ?? "";
			if (!string.IsNullOrWhiteSpace(newName)) trainer.FullName = newName;

			Console.Write("Новая специализация: ");
			string newSpec = Console.ReadLine() ?? "";
			if (!string.IsNullOrWhiteSpace(newSpec)) trainer.Specialization = newSpec;

			Console.Write("Новый стаж (лет): ");
			string expInput = Console.ReadLine() ?? "";
			if (!string.IsNullOrWhiteSpace(expInput) && int.TryParse(expInput, out int newExp)) trainer.ExperienceYears = newExp;

			Console.Write("Новый телефон: ");
			string newPhone = Console.ReadLine() ?? "";
			if (!string.IsNullOrWhiteSpace(newPhone)) trainer.PhoneNumber = newPhone;

			if (UIHelper.Confirm("Подтвердить изменения?"))
			{
				bool success = _service.Update(trainer);
				if (success) { LoggerHelper.LogSuccess($"Тренер обновлен (ID: {id})"); UIHelper.Success("Тренер обновлен"); }
				else LoggerHelper.LogError("Не удалось обновить тренера");
			}
			else { LoggerHelper.Log("Обновление отменено"); UIHelper.Info("Отменено"); }
		}
		catch (InvalidOperationException ex) { LoggerHelper.LogError(ex.Message); UIHelper.Error(ex.Message); }
		Console.ReadKey();
	}

	private void Delete()
	{
		try
		{
			Console.Clear();
			Console.Write("ID тренера: ");
			if (!int.TryParse(Console.ReadLine(), out int id)) { LoggerHelper.LogError("Некорректный ID"); UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

			var trainer = _service.GetById(id);
			if (trainer == null) { LoggerHelper.Log($"Тренер с ID {id} не найден"); UIHelper.Error("Тренер не найден"); Console.ReadKey(); return; }

			Console.WriteLine("\nУдаляемый тренер:");
			Display(trainer);

			if (UIHelper.Confirm("Вы уверены? Это действие необратимо!"))
			{
				bool success = _service.Delete(id);
				if (success) { LoggerHelper.LogSuccess($"Тренер удален: {trainer.FullName} (ID: {id})"); UIHelper.Success("Тренер удален"); }
				else LoggerHelper.LogError("Не удалось удалить тренера");
			}
			else { LoggerHelper.Log("Удаление отменено"); UIHelper.Info("Отменено"); }
		}
		catch (InvalidOperationException ex) { LoggerHelper.LogError(ex.Message); UIHelper.Error(ex.Message); }
		Console.ReadKey();
	}

	private void Display(Trainer t)
	{
		Console.WriteLine($"ID: {t.Id}");
		Console.WriteLine($"Имя: {t.FullName}");
		Console.WriteLine($"Специализация: {t.Specialization}");
		Console.WriteLine($"Стаж: {t.ExperienceYears} лет");
		Console.WriteLine($"Телефон: {t.PhoneNumber}");
	}
}
