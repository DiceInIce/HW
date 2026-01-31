using FitnessTracker.Models;
using FitnessTracker.Services;

namespace FitnessTracker.Presentation;

public class WorkoutSessionMenu
{
	private readonly WorkoutSessionService _workoutSessionService;
	private readonly WorkoutExerciseService _workoutExerciseService;
	private readonly ClientService _clientService;
	private readonly TrainerService _trainerService;
	private readonly ExerciseService _exerciseService;

	public WorkoutSessionMenu(
		WorkoutSessionService workoutSessionService,
		WorkoutExerciseService workoutExerciseService,
		ClientService clientService,
		TrainerService trainerService,
		ExerciseService exerciseService)
	{
		_workoutSessionService = workoutSessionService;
		_workoutExerciseService = workoutExerciseService;
		_clientService = clientService;
		_trainerService = trainerService;
		_exerciseService = exerciseService;
	}

	public void Run()
	{
		bool running = true;
		while (running)
		{
			UIHelper.PrintMenu("УПРАВЛЕНИЕ ТРЕНИРОВКАМИ",
					"1. Добавить новую тренировку",
					"2. Добавить тренировку с выбором клиента и тренера",
					"3. Показать все тренировки",
					"4. Найти тренировку по ID",
					"5. Найти тренировки по типу",
					"6. Найти тренировки по диапазону дат",
					"7. Просмотр тренировок клиента",
					"8. Изменить тренировку",
					"9. Удалить тренировку",
					"10. Управление упражнениями в тренировке",
					"11. Вернуться в главное меню");

			switch (Console.ReadLine())
			{
				case "1": Add(); break;
				case "2": AddWithClientAndTrainer(); break;
				case "3": ShowAll(); break;
				case "4": FindById(); break;
				case "5": FindByType(); break;
				case "6": FindByDateRange(); break;
				case "7": GetByClient(); break;
				case "8": Update(); break;
				case "9": Delete(); break;
				case "10": WorkoutExerciseMenu(); break;
				case "11": running = false; break;
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
			Console.WriteLine("=== ДОБАВЛЕНИЕ ТРЕНИРОВКИ ===");
			Console.Write("Дата (yyyy-MM-dd HH:mm): ");
			if (!DateTime.TryParse(Console.ReadLine(), out DateTime date)) { UIHelper.Error("Неверный формат даты"); Console.ReadKey(); return; }
			date = DateTime.SpecifyKind(date, DateTimeKind.Utc);

			Console.Write("Длительность (минут): ");
			if (!int.TryParse(Console.ReadLine(), out int duration) || duration <= 0) { UIHelper.Error("Неверная длительность"); Console.ReadKey(); return; }

			Console.Write("Сожженные калории: ");
			if (!int.TryParse(Console.ReadLine(), out int calories) || calories < 0) { UIHelper.Error("Неверное количество калорий"); Console.ReadKey(); return; }

			Console.Write("Тип тренировки: ");
			string sessionType = Console.ReadLine() ?? "";
			if (string.IsNullOrWhiteSpace(sessionType)) { UIHelper.Error("Тип не может быть пустым"); Console.ReadKey(); return; }

			var session = new WorkoutSession { Date = date, DurationMinutes = duration, CaloriesBurned = calories, SessionType = sessionType };
			bool success = _workoutSessionService.Add(session);
			if (success)
			{
				LoggerHelper.LogSuccess($"Тренировка добавлена: {sessionType} (ID: {session.Id}), длительность: {duration} мин, калории: {calories}");
				UIHelper.Success($"Тренировка добавлена с ID: {session.Id}");
			}
			else
				LoggerHelper.LogError("Не удалось добавить тренировку");
		}
		catch (InvalidOperationException ex)
		{
			LoggerHelper.LogError(ex.Message);
			UIHelper.Error(ex.Message);
		}
		Console.ReadKey();
	}

	private void AddWithClientAndTrainer()
	{
		try
		{
			Console.Clear();
			Console.WriteLine("=== ДОБАВЛЕНИЕ ТРЕНИРОВКИ С КЛИЕНТОМ И ТРЕНЕРОМ ===");

			// Выбор клиента
			var clients = _clientService.GetAll();
			if (clients.Count == 0)
			{
				UIHelper.Error("Нет доступных клиентов. Сначала добавьте клиента.");
				Console.ReadKey();
				return;
			}

			Console.WriteLine("\nДоступные клиенты:");
			Console.WriteLine(string.Format("{0,-5} {1,-30} {2,-20}", "ID", "Имя", "Тип абонемента"));
			Console.WriteLine(new string('-', 60));
			foreach (var c in clients)
				Console.WriteLine($"{c.Id,-5} {c.FullName,-30} {c.MembershipType,-20}");

			Console.Write("\nВыберите ID клиента (или 0 для пропуска): ");
			if (!int.TryParse(Console.ReadLine(), out int clientId)) { UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }
			int? selectedClientId = clientId > 0 ? clientId : null;

			// Выбор тренера
			var trainers = _trainerService.GetAll();
			if (trainers.Count == 0)
			{
				UIHelper.Error("Нет доступных тренеров. Сначала добавьте тренера.");
				Console.ReadKey();
				return;
			}

			Console.WriteLine("\nДоступные тренеры:");
			Console.WriteLine(string.Format("{0,-5} {1,-30} {2,-20}", "ID", "Имя", "Специализация"));
			Console.WriteLine(new string('-', 60));
			foreach (var t in trainers)
				Console.WriteLine($"{t.Id,-5} {t.FullName,-30} {t.Specialization,-20}");

			Console.Write("\nВыберите ID тренера (или 0 для пропуска): ");
			if (!int.TryParse(Console.ReadLine(), out int trainerId)) { UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }
			int? selectedTrainerId = trainerId > 0 ? trainerId : null;

			// Ввод данных тренировки
			Console.Write("\nДата (yyyy-MM-dd HH:mm): ");
			if (!DateTime.TryParse(Console.ReadLine(), out DateTime date)) { UIHelper.Error("Неверный формат даты"); Console.ReadKey(); return; }
			date = DateTime.SpecifyKind(date, DateTimeKind.Utc);

			Console.Write("Длительность (минут): ");
			if (!int.TryParse(Console.ReadLine(), out int duration) || duration <= 0) { UIHelper.Error("Неверная длительность"); Console.ReadKey(); return; }

			Console.Write("Сожженные калории: ");
			if (!int.TryParse(Console.ReadLine(), out int calories) || calories < 0) { UIHelper.Error("Неверное количество калорий"); Console.ReadKey(); return; }

			Console.Write("Тип тренировки: ");
			string sessionType = Console.ReadLine() ?? "";
			if (string.IsNullOrWhiteSpace(sessionType)) { UIHelper.Error("Тип не может быть пустым"); Console.ReadKey(); return; }

			var session = new WorkoutSession 
			{ 
				Date = date, 
				DurationMinutes = duration, 
				CaloriesBurned = calories, 
				SessionType = sessionType,
				ClientId = selectedClientId,
				TrainerId = selectedTrainerId
			};

			bool success = _workoutSessionService.Add(session);
			if (success)
			{
				LoggerHelper.LogSuccess($"Тренировка добавлена: {sessionType} (ID: {session.Id}), клиент: {selectedClientId}, тренер: {selectedTrainerId}");
				UIHelper.Success($"Тренировка добавлена с ID: {session.Id}");
			}
			else
				LoggerHelper.LogError("Не удалось добавить тренировку");
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
		var sessions = _workoutSessionService.GetAll();
		if (sessions.Count == 0) { UIHelper.Info("Тренировки не найдены"); Console.ReadKey(); return; }

		Console.WriteLine("=== СПИСОК ТРЕНИРОВОК ===");
		Console.WriteLine(string.Format("{0,-5} {1,-20} {2,-8} {3,-10} {4,-20} {5,-25} {6,-25}", "ID", "Дата", "Мин", "Калории", "Тип", "Клиент", "Тренер"));
		Console.WriteLine(new string('-', 120));
		foreach (var s in sessions)
		{
			string clientName = s.Client?.FullName ?? "Не указан";
			string trainerName = s.Trainer?.FullName ?? "Не указан";
			Console.WriteLine($"{s.Id,-5} {s.Date,-20:yyyy-MM-dd HH:mm} {s.DurationMinutes,-8} {s.CaloriesBurned,-10} {s.SessionType,-20} {clientName,-25} {trainerName,-25}");
		}
		Console.WriteLine("\nНажмите любую клавишу...");
		Console.ReadKey();
	}

	private void FindById()
	{
		Console.Clear();
		Console.Write("ID тренировки: ");
		if (!int.TryParse(Console.ReadLine(), out int id)) { UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

		var session = _workoutSessionService.GetById(id);
		if (session == null) { UIHelper.Error("Тренировка не найдена"); Console.ReadKey(); return; }

		Display(session);
		Console.ReadKey();
	}

	private void GetByClient()
	{
		Console.Clear();
		Console.WriteLine("=== ТРЕНИРОВКИ КЛИЕНТА ===");
		
		var clients = _clientService.GetAll();
		if (clients.Count == 0)
		{
			UIHelper.Info("Нет доступных клиентов");
			Console.ReadKey();
			return;
		}

		Console.WriteLine("\nДоступные клиенты:");
		Console.WriteLine(string.Format("{0,-5} {1,-30}", "ID", "Имя"));
		Console.WriteLine(new string('-', 40));
		foreach (var c in clients)
			Console.WriteLine($"{c.Id,-5} {c.FullName,-30}");

		Console.Write("\nВыберите ID клиента: ");
		if (!int.TryParse(Console.ReadLine(), out int clientId)) { UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

		var sessions = _workoutSessionService.GetByClientId(clientId);
		if (sessions.Count == 0)
		{
			UIHelper.Info("У этого клиента нет тренировок");
			Console.ReadKey();
			return;
		}

		Console.WriteLine($"\n=== Тренировки клиента (найдено: {sessions.Count}) ===");
		Console.WriteLine(string.Format("{0,-5} {1,-20} {2,-8} {3,-10} {4,-20} {5,-25}", "ID", "Дата", "Мин", "Калории", "Тип", "Тренер"));
		Console.WriteLine(new string('-', 95));
		foreach (var s in sessions)
		{
			string trainerName = s.Trainer?.FullName ?? "Не указан";
			Console.WriteLine($"{s.Id,-5} {s.Date,-20:yyyy-MM-dd HH:mm} {s.DurationMinutes,-8} {s.CaloriesBurned,-10} {s.SessionType,-20} {trainerName,-25}");
		}
		Console.WriteLine("\nНажмите любую клавишу...");
		Console.ReadKey();
	}

	private void FindByType()
	{
		Console.Clear();
		Console.Write("Тип тренировки: ");
		string sessionType = Console.ReadLine() ?? "";
		var sessions = _workoutSessionService.GetBySessionType(sessionType);

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
			startDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);

			Console.Write("Конечная дата (yyyy-MM-dd): ");
			if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate)) { UIHelper.Error("Неверный формат даты"); Console.ReadKey(); return; }
			endDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);

		var sessions = _workoutSessionService.GetByDateRange(startDate, endDate);
		if (sessions.Count == 0) { UIHelper.Info("Тренировки не найдены"); Console.ReadKey(); return; }
		Console.WriteLine($"\nНайдено: {sessions.Count}");
		Console.WriteLine(new string('-', 85));
		foreach (var s in sessions) { Display(s); Console.WriteLine(new string('-', 85)); }
		Console.ReadKey();
	}

	private void Update()
	{
		try
		{
			Console.Clear();
			Console.Write("ID тренировки: ");
			if (!int.TryParse(Console.ReadLine(), out int id)) { LoggerHelper.LogError("Некорректный ID"); UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

			var session = _workoutSessionService.GetById(id);
			if (session == null) { LoggerHelper.Log($"Тренировка с ID {id} не найдена"); UIHelper.Error("Тренировка не найдена"); Console.ReadKey(); return; }

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
				bool success = _workoutSessionService.Update(session);
				if (success) { LoggerHelper.LogSuccess($"Тренировка обновлена (ID: {id})"); UIHelper.Success("Тренировка обновлена"); }
				else LoggerHelper.LogError("Не удалось обновить тренировку");
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
			Console.Write("ID тренировки: ");
			if (!int.TryParse(Console.ReadLine(), out int id)) { LoggerHelper.LogError("Некорректный ID"); UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

			var session = _workoutSessionService.GetById(id);
			if (session == null) { LoggerHelper.Log($"Тренировка с ID {id} не найдена"); UIHelper.Error("Тренировка не найдена"); Console.ReadKey(); return; }

			Console.WriteLine("\nУдаляемая тренировка:");
			Display(session);

			if (UIHelper.Confirm("Вы уверены? Это действие необратимо!"))
			{
				bool success = _workoutSessionService.Delete(id);
				if (success) { LoggerHelper.LogSuccess($"Тренировка удалена: {session.SessionType} (ID: {id})"); UIHelper.Success("Тренировка удалена"); }
				else LoggerHelper.LogError("Не удалось удалить тренировку");
			}
			else { LoggerHelper.Log("Удаление отменено"); UIHelper.Info("Отменено"); }
		}
		catch (InvalidOperationException ex) { LoggerHelper.LogError(ex.Message); UIHelper.Error(ex.Message); }
		Console.ReadKey();
	}

	private void WorkoutExerciseMenu()
	{
		bool running = true;
		while (running)
		{
			UIHelper.PrintMenu("УПРАВЛЕНИЕ УПРАЖНЕНИЯМИ В ТРЕНИРОВКЕ",
					"1. Добавить упражнение в тренировку",
					"2. Показать упражнения тренировки",
					"3. Изменить параметры упражнения",
					"4. Удалить упражнение из тренировки",
					"5. Вернуться в меню тренировок");

			switch (Console.ReadLine())
			{
				case "1": AddExerciseToWorkout(); break;
				case "2": ShowWorkoutExercises(); break;
				case "3": UpdateWorkoutExercise(); break;
				case "4": DeleteWorkoutExercise(); break;
				case "5": running = false; break;
				default:
					UIHelper.Error("Неверный выбор");
					Console.ReadKey();
					break;
			}
		}
	}

	private void AddExerciseToWorkout()
	{
		try
		{
			Console.Clear();
			Console.WriteLine("=== ДОБАВЛЕНИЕ УПРАЖНЕНИЯ В ТРЕНИРОВКУ ===");

			// Выбор тренировки
			var sessions = _workoutSessionService.GetAll();
			if (sessions.Count == 0)
			{
				UIHelper.Error("Нет доступных тренировок. Сначала создайте тренировку.");
				Console.ReadKey();
				return;
			}

			Console.WriteLine("\nДоступные тренировки:");
			Console.WriteLine(string.Format("{0,-5} {1,-20} {2,-20}", "ID", "Дата", "Тип"));
			Console.WriteLine(new string('-', 50));
			foreach (var s in sessions)
				Console.WriteLine($"{s.Id,-5} {s.Date,-20:yyyy-MM-dd HH:mm} {s.SessionType,-20}");

			Console.Write("\nВыберите ID тренировки: ");
			if (!int.TryParse(Console.ReadLine(), out int workoutSessionId)) { UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

			var workoutSession = _workoutSessionService.GetById(workoutSessionId);
			if (workoutSession == null)
			{
				UIHelper.Error("Тренировка не найдена");
				Console.ReadKey();
				return;
			}

			// Выбор упражнения
			var exercises = _exerciseService.GetAll();
			if (exercises.Count == 0)
			{
				UIHelper.Error("Нет доступных упражнений. Сначала добавьте упражнение.");
				Console.ReadKey();
				return;
			}

			Console.WriteLine("\nДоступные упражнения:");
			Console.WriteLine(string.Format("{0,-5} {1,-30} {2,-15}", "ID", "Название", "Сложность"));
			Console.WriteLine(new string('-', 55));
			foreach (var e in exercises)
				Console.WriteLine($"{e.Id,-5} {e.Name,-30} {e.DifficultyLevel,-15}");

			Console.Write("\nВыберите ID упражнения: ");
			if (!int.TryParse(Console.ReadLine(), out int exerciseId)) { UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

			var exercise = _exerciseService.GetById(exerciseId);
			if (exercise == null)
			{
				UIHelper.Error("Упражнение не найдено");
				Console.ReadKey();
				return;
			}

			// Проверка, не добавлено ли уже это упражнение
			var existing = _workoutExerciseService.GetByWorkoutSessionId(workoutSessionId)
				.FirstOrDefault(we => we.ExerciseId == exerciseId);
			if (existing != null)
			{
				UIHelper.Error("Это упражнение уже добавлено в данную тренировку");
				Console.ReadKey();
				return;
			}

			// Ввод параметров
			Console.Write("Количество подходов: ");
			if (!int.TryParse(Console.ReadLine(), out int sets) || sets <= 0) { UIHelper.Error("Неверное количество подходов"); Console.ReadKey(); return; }

			Console.Write("Количество повторений: ");
			if (!int.TryParse(Console.ReadLine(), out int repetitions) || repetitions <= 0) { UIHelper.Error("Неверное количество повторений"); Console.ReadKey(); return; }

			Console.Write("Вес (кг, можно оставить пустым): ");
			string weightInput = Console.ReadLine() ?? "";
			decimal? weight = null;
			if (!string.IsNullOrWhiteSpace(weightInput))
			{
				if (!decimal.TryParse(weightInput, out decimal weightValue) || weightValue < 0)
				{
					UIHelper.Error("Неверный вес");
					Console.ReadKey();
					return;
				}
				weight = weightValue;
			}

			var workoutExercise = new WorkoutExercise
			{
				WorkoutSessionId = workoutSessionId,
				ExerciseId = exerciseId,
				Sets = sets,
				Repetitions = repetitions,
				Weight = weight
			};

			bool success = _workoutExerciseService.Add(workoutExercise);
			if (success)
			{
				LoggerHelper.LogSuccess($"Упражнение '{exercise.Name}' добавлено в тренировку (ID: {workoutSessionId})");
				UIHelper.Success("Упражнение добавлено в тренировку");
			}
			else
				LoggerHelper.LogError("Не удалось добавить упражнение");
		}
		catch (InvalidOperationException ex)
		{
			LoggerHelper.LogError(ex.Message);
			UIHelper.Error(ex.Message);
		}
		Console.ReadKey();
	}

	private void ShowWorkoutExercises()
	{
		Console.Clear();
		Console.WriteLine("=== УПРАЖНЕНИЯ В ТРЕНИРОВКЕ ===");

		var sessions = _workoutSessionService.GetAll();
		if (sessions.Count == 0)
		{
			UIHelper.Info("Нет доступных тренировок");
			Console.ReadKey();
			return;
		}

		Console.WriteLine("\nДоступные тренировки:");
		Console.WriteLine(string.Format("{0,-5} {1,-20} {2,-20}", "ID", "Дата", "Тип"));
		Console.WriteLine(new string('-', 50));
		foreach (var s in sessions)
			Console.WriteLine($"{s.Id,-5} {s.Date,-20:yyyy-MM-dd HH:mm} {s.SessionType,-20}");

		Console.Write("\nВыберите ID тренировки: ");
		if (!int.TryParse(Console.ReadLine(), out int workoutSessionId)) { UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

		var workoutExercises = _workoutExerciseService.GetByWorkoutSessionId(workoutSessionId);
		if (workoutExercises.Count == 0)
		{
			UIHelper.Info("В этой тренировке нет упражнений");
			Console.ReadKey();
			return;
		}

		Console.WriteLine($"\n=== Упражнения в тренировке (найдено: {workoutExercises.Count}) ===");
		Console.WriteLine(string.Format("{0,-5} {1,-30} {2,-8} {3,-12} {4,-10}", "ID", "Упражнение", "Подходы", "Повторения", "Вес (кг)"));
		Console.WriteLine(new string('-', 75));
		foreach (var we in workoutExercises)
		{
			string weightStr = we.Weight.HasValue ? we.Weight.Value.ToString("F2") : "Нет";
			Console.WriteLine($"{we.Id,-5} {we.Exercise.Name,-30} {we.Sets,-8} {we.Repetitions,-12} {weightStr,-10}");
		}
		Console.WriteLine("\nНажмите любую клавишу...");
		Console.ReadKey();
	}

	private void UpdateWorkoutExercise()
	{
		try
		{
			Console.Clear();
			Console.WriteLine("=== ИЗМЕНЕНИЕ ПАРАМЕТРОВ УПРАЖНЕНИЯ ===");
			Console.Write("ID упражнения в тренировке: ");
			if (!int.TryParse(Console.ReadLine(), out int id)) { UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

			var workoutExercise = _workoutExerciseService.GetById(id);
			if (workoutExercise == null)
			{
				UIHelper.Error("Упражнение в тренировке не найдено");
				Console.ReadKey();
				return;
			}

			Console.WriteLine("\nТекущие параметры:");
			Console.WriteLine($"Упражнение: {workoutExercise.Exercise.Name}");
			Console.WriteLine($"Тренировка: {workoutExercise.WorkoutSession.SessionType} ({workoutExercise.WorkoutSession.Date:yyyy-MM-dd})");
			Console.WriteLine($"Подходы: {workoutExercise.Sets}");
			Console.WriteLine($"Повторения: {workoutExercise.Repetitions}");
			Console.WriteLine($"Вес: {(workoutExercise.Weight.HasValue ? workoutExercise.Weight.Value.ToString("F2") + " кг" : "Не указан")}");

			Console.Write("\nНовое количество подходов: ");
			string setsInput = Console.ReadLine() ?? "";
			if (!string.IsNullOrWhiteSpace(setsInput) && int.TryParse(setsInput, out int newSets) && newSets > 0)
				workoutExercise.Sets = newSets;

			Console.Write("Новое количество повторений: ");
			string repsInput = Console.ReadLine() ?? "";
			if (!string.IsNullOrWhiteSpace(repsInput) && int.TryParse(repsInput, out int newReps) && newReps > 0)
				workoutExercise.Repetitions = newReps;

			Console.Write("Новый вес (кг, можно оставить пустым): ");
			string weightInput = Console.ReadLine() ?? "";
			if (!string.IsNullOrWhiteSpace(weightInput))
			{
				if (decimal.TryParse(weightInput, out decimal newWeight) && newWeight >= 0)
					workoutExercise.Weight = newWeight;
			}
			else if (weightInput == "")
			{
				workoutExercise.Weight = null;
			}

			if (UIHelper.Confirm("Подтвердить изменения?"))
			{
				bool success = _workoutExerciseService.Update(workoutExercise);
				if (success)
				{
					LoggerHelper.LogSuccess($"Параметры упражнения обновлены (ID: {id})");
					UIHelper.Success("Параметры упражнения обновлены");
				}
				else
					LoggerHelper.LogError("Не удалось обновить параметры");
			}
			else
			{
				LoggerHelper.Log("Обновление отменено");
				UIHelper.Info("Отменено");
			}
		}
		catch (InvalidOperationException ex)
		{
			LoggerHelper.LogError(ex.Message);
			UIHelper.Error(ex.Message);
		}
		Console.ReadKey();
	}

	private void DeleteWorkoutExercise()
	{
		try
		{
			Console.Clear();
			Console.WriteLine("=== УДАЛЕНИЕ УПРАЖНЕНИЯ ИЗ ТРЕНИРОВКИ ===");
			Console.Write("ID упражнения в тренировке: ");
			if (!int.TryParse(Console.ReadLine(), out int id)) { UIHelper.Error("Неверный ID"); Console.ReadKey(); return; }

			var workoutExercise = _workoutExerciseService.GetById(id);
			if (workoutExercise == null)
			{
				UIHelper.Error("Упражнение в тренировке не найдено");
				Console.ReadKey();
				return;
			}

			Console.WriteLine("\nУдаляемое упражнение:");
			Console.WriteLine($"Упражнение: {workoutExercise.Exercise.Name}");
			Console.WriteLine($"Тренировка: {workoutExercise.WorkoutSession.SessionType} ({workoutExercise.WorkoutSession.Date:yyyy-MM-dd})");
			Console.WriteLine($"Подходы: {workoutExercise.Sets}, Повторения: {workoutExercise.Repetitions}");

			if (UIHelper.Confirm("Вы уверены? Это действие необратимо!"))
			{
				bool success = _workoutExerciseService.Delete(id);
				if (success)
				{
					LoggerHelper.LogSuccess($"Упражнение удалено из тренировки (ID: {id})");
					UIHelper.Success("Упражнение удалено из тренировки");
				}
				else
					LoggerHelper.LogError("Не удалось удалить упражнение");
			}
			else
			{
				LoggerHelper.Log("Удаление отменено");
				UIHelper.Info("Отменено");
			}
		}
		catch (InvalidOperationException ex)
		{
			LoggerHelper.LogError(ex.Message);
			UIHelper.Error(ex.Message);
		}
		Console.ReadKey();
	}

	private void Display(WorkoutSession s)
	{
		Console.WriteLine($"ID: {s.Id}");
		Console.WriteLine($"Дата: {s.Date:yyyy-MM-dd HH:mm}");
		Console.WriteLine($"Длительность: {s.DurationMinutes} мин");
		Console.WriteLine($"Калории: {s.CaloriesBurned}");
		Console.WriteLine($"Тип: {s.SessionType}");
		Console.WriteLine($"Клиент: {(s.Client != null ? s.Client.FullName : "Не указан")}");
		Console.WriteLine($"Тренер: {(s.Trainer != null ? s.Trainer.FullName : "Не указан")}");
		if (s.WorkoutExercises != null && s.WorkoutExercises.Count > 0)
		{
			Console.WriteLine($"Упражнений в тренировке: {s.WorkoutExercises.Count}");
		}
	}
}
