using FitnessTracker.Models;
using FitnessTracker.Services;

namespace FitnessTracker.Presentation;

public class ClientMenu
{
	private readonly ClientService _service;

	public ClientMenu(ClientService service) => _service = service;

	public void Run()
	{
		bool running = true;
		while (running)
		{
			UIHelper.PrintMenu("УПРАВЛЕНИЕ КЛИЕНТАМИ",
					"1. Добавить нового клиента",
					"2. Показать всех клиентов",
					"3. Найти клиента по ID",
					"4. Найти клиентов по типу абонемента",
					"5. Изменить клиента",
					"6. Удалить клиента",
					"7. Вернуться в главное меню");

			switch (Console.ReadLine())
			{
				case "1": Add(); break;
				case "2": ShowAll(); break;
				case "3": FindById(); break;
				case "4": FindByMembershipType(); break;
				case "5": Update(); break;
				case "6": Delete(); break;
				case "7": running = false; break;
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
			Console.WriteLine("=== ДОБАВЛЕНИЕ КЛИЕНТА ===");
			Console.Write("Полное имя: ");
			string fullName = Console.ReadLine() ?? "";
			if (string.IsNullOrWhiteSpace(fullName)) { UIHelper.Error("Имя не может быть пустым"); Console.ReadKey(); return; }

			Console.Write("Дата рождения (yyyy-MM-dd): ");
			if (!DateTime.TryParse(Console.ReadLine(), out DateTime birthDate)) { UIHelper.Error("Неверный формат даты"); Console.ReadKey(); return; }
			birthDate = DateTime.SpecifyKind(birthDate, DateTimeKind.Utc);

			Console.Write("Тип абонемента: ");
			string membershipType = Console.ReadLine() ?? "";
			if (string.IsNullOrWhiteSpace(membershipType)) { UIHelper.Error("Тип абонемента не может быть пустым"); Console.ReadKey(); return; }

			var client = new Client { FullName = fullName, BirthDate = birthDate, MembershipType = membershipType, RegistrationDate = DateTime.UtcNow };
			bool success = _service.Add(client);
			if (success)
			{
				LoggerHelper.LogSuccess($"Клиент добавлен: {fullName} (ID: {client.Id})");
				UIHelper.Success($"Клиент добавлен с ID: {client.Id}");
			}
			else
				LoggerHelper.LogError("Не удалось добавить клиента");
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
		var clients = _service.GetAll();
		if (clients.Count == 0)
		{
			LoggerHelper.Log("Попытка просмотра клиентов - список пуст");
			UIHelper.Info("Клиенты не найдены");
			Console.ReadKey();
			return;
		}

		LoggerHelper.Log($"Показаны все клиенты. Записей: {clients.Count}");
		Console.WriteLine("=== СПИСОК КЛИЕНТОВ ===");
		Console.WriteLine(string.Format("{0,-5} {1,-20} {2,-15} {3,-20} {4,-20}", "ID", "Имя", "Дата рождения", "Абонемент", "Дата регистрации"));
		Console.WriteLine(new string('-', 85));
		foreach (var c in clients)
			Console.WriteLine($"{c.Id,-5} {c.FullName,-20} {c.BirthDate,-15:yyyy-MM-dd} {c.MembershipType,-20} {c.RegistrationDate,-20:yyyy-MM-dd}");
		Console.WriteLine($"\nВсего записей: {clients.Count}");
		Console.WriteLine("Нажмите любую клавишу...");
		Console.ReadKey();
	}

	private void FindById()
	{
		Console.Clear();
		Console.Write("ID клиента: ");
		if (!int.TryParse(Console.ReadLine(), out int id))
		{
			LoggerHelper.LogError("Некорректный ID при поиске клиента");
			UIHelper.Error("Неверный ID");
			Console.ReadKey();
			return;
		}

		var client = _service.GetById(id);
		if (client == null)
		{
			LoggerHelper.Log($"Клиент с ID {id} не найден");
			UIHelper.Error("Клиент не найден");
			Console.ReadKey();
			return;
		}

		LoggerHelper.Log($"Найден клиент: {client.FullName} (ID: {id})");
		Display(client);
		Console.ReadKey();
	}

	private void FindByMembershipType()
	{
		Console.Clear();
		Console.Write("Тип абонемента: ");
		string membershipType = Console.ReadLine() ?? "";
		var clients = _service.GetByMembershipType(membershipType);

		if (clients.Count == 0)
		{
			LoggerHelper.Log($"Поиск клиентов по абонементу \"{membershipType}\" - ничего не найдено");
			UIHelper.Info("Клиенты не найдены");
			Console.ReadKey();
			return;
		}

		LoggerHelper.Log($"Найдены клиенты с абонементом \"{membershipType}\". Записей: {clients.Count}");
		Console.WriteLine($"\nНайдено: {clients.Count} записей");
		Console.WriteLine(new string('-', 85));
		foreach (var c in clients) { Display(c); Console.WriteLine(new string('-', 85)); }
		Console.ReadKey();
	}

	private void Update()
	{
		try
		{
			Console.Clear();
			Console.Write("ID клиента: ");
			if (!int.TryParse(Console.ReadLine(), out int id))
			{
				LoggerHelper.LogError("Некорректный ID при обновлении клиента");
				UIHelper.Error("Неверный ID");
				Console.ReadKey();
				return;
			}

			var client = _service.GetById(id);
			if (client == null)
			{
				LoggerHelper.Log($"Попытка обновить клиента с ID {id} - не найден");
				UIHelper.Error("Клиент не найден");
				Console.ReadKey();
				return;
			}

			Console.WriteLine("\nТекущие данные:");
			Display(client);

			Console.Write("\nНовое имя: ");
			string newName = Console.ReadLine() ?? "";
			if (!string.IsNullOrWhiteSpace(newName)) client.FullName = newName;

			Console.Write("Новый тип абонемента: ");
			string newMembership = Console.ReadLine() ?? "";
			if (!string.IsNullOrWhiteSpace(newMembership)) client.MembershipType = newMembership;

			if (UIHelper.Confirm("Подтвердить изменения?"))
			{
				bool success = _service.Update(client);
				if (success)
				{
					LoggerHelper.LogSuccess($"Клиент обновлен (ID: {id})");
					UIHelper.Success("Клиент обновлен");
				}
				else
					LoggerHelper.LogError("Не удалось обновить клиента");
			}
			else
			{
				LoggerHelper.Log("Обновление клиента отменено пользователем");
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

	private void Delete()
	{
		try
		{
			Console.Clear();
			Console.Write("ID клиента: ");
			if (!int.TryParse(Console.ReadLine(), out int id))
			{
				LoggerHelper.LogError("Некорректный ID при удалении клиента");
				UIHelper.Error("Неверный ID");
				Console.ReadKey();
				return;
			}

			var client = _service.GetById(id);
			if (client == null)
			{
				LoggerHelper.Log($"Попытка удалить клиента с ID {id} - не найден");
				UIHelper.Error("Клиент не найден");
				Console.ReadKey();
				return;
			}

			Console.WriteLine("\nУдаляемый клиент:");
			Display(client);

			if (UIHelper.Confirm("Вы уверены? Это действие необратимо!"))
			{
				bool success = _service.Delete(id);
				if (success)
				{
					LoggerHelper.LogSuccess($"Клиент удален: {client.FullName} (ID: {id})");
					UIHelper.Success("Клиент удален");
				}
				else
					LoggerHelper.LogError("Не удалось удалить клиента");
			}
			else
			{
				LoggerHelper.Log("Удаление клиента отменено пользователем");
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

	private void Display(Client c)
	{
		Console.WriteLine($"ID: {c.Id}");
		Console.WriteLine($"Имя: {c.FullName}");
		Console.WriteLine($"Дата рождения: {c.BirthDate:yyyy-MM-dd}");
		Console.WriteLine($"Абонемент: {c.MembershipType}");
		Console.WriteLine($"Дата регистрации: {c.RegistrationDate:yyyy-MM-dd}");
	}
}
