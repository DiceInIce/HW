using FitnessTracker.Data;
using FitnessTracker.Services;

namespace FitnessTracker.Presentation;

public class Application
{
	private readonly ExerciseMenu _exerciseMenu;
	private readonly ClientMenu _clientMenu;
	private readonly TrainerMenu _trainerMenu;
	private readonly WorkoutSessionMenu _workoutSessionMenu;

	public Application(FitnessTrackerContext context)
	{
		var exerciseService = new ExerciseService(context);
		var clientService = new ClientService(context);
		var trainerService = new TrainerService(context);
		var workoutSessionService = new WorkoutSessionService(context);
		var workoutExerciseService = new WorkoutExerciseService(context);

		_exerciseMenu = new ExerciseMenu(exerciseService);
		_clientMenu = new ClientMenu(clientService);
		_trainerMenu = new TrainerMenu(trainerService);
		_workoutSessionMenu = new WorkoutSessionMenu(
			workoutSessionService,
			workoutExerciseService,
			clientService,
			trainerService,
			exerciseService);
	}

	public void Run()
	{
		bool isRunning = true;
		while (isRunning)
		{
			UIHelper.PrintMenu("ФИТНЕС-ТРЕКЕР",
					"1. Управление упражнениями",
					"2. Управление клиентами",
					"3. Управление тренерами",
					"4. Управление тренировками",
					"5. Выход");

			switch (Console.ReadLine())
			{
				case "1": _exerciseMenu.Run(); break;
				case "2": _clientMenu.Run(); break;
				case "3": _trainerMenu.Run(); break;
				case "4": _workoutSessionMenu.Run(); break;
				case "5": isRunning = false; break;
				default:
					UIHelper.Error("Неверный выбор");
					Console.ReadKey();
					break;
			}
		}
		Console.WriteLine("До свидания!");
		Console.WriteLine("\nНажмите любую клавишу для завершения...");
		Console.ReadKey();
	}
}
