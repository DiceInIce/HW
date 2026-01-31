using FitnessTracker.Data;
using FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Services;

public class ExerciseService
{
	private FitnessTrackerContext db;

	public ExerciseService(FitnessTrackerContext context)
	{
		db = context;
	}

	public List<Exercise> GetAll() => db.Exercises.ToList();

	public Exercise? GetById(int id) => db.Exercises.FirstOrDefault(e => e.Id == id);

	public List<Exercise> GetByDifficulty(string difficulty) =>
			db.Exercises.Where(e => e.DifficultyLevel == difficulty).ToList();

	public List<Exercise> GetByMuscleGroup(string muscleGroup) =>
			db.Exercises.Where(e => e.TargetMuscleGroup.Contains(muscleGroup)).ToList();

	public bool Add(Exercise ex)
	{
		try
		{
			db.Exercises.Add(ex);
			int changes = db.SaveChanges();
			return changes > 0;
		}
		catch (DbUpdateException dbEx)
		{
			throw new InvalidOperationException($"Ошибка при добавлении упражнения: {dbEx.Message}", dbEx);
		}
	}

	public bool Update(Exercise ex)
	{
		try
		{
			var existing = GetById(ex.Id);
			if (existing == null)
				throw new InvalidOperationException("Упражнение не найдено");

			db.Exercises.Update(ex);
			int changes = db.SaveChanges();
			return changes > 0;
		}
		catch (DbUpdateException dbEx)
		{
			throw new InvalidOperationException($"Ошибка при обновлении упражнения: {dbEx.Message}", dbEx);
		}
	}

	public bool Delete(int id)
	{
		try
		{
			var ex = GetById(id);
			if (ex == null)
				throw new InvalidOperationException("Упражнение не найдено");

			db.Exercises.Remove(ex);
			int changes = db.SaveChanges();
			return changes > 0;
		}
		catch (DbUpdateException dbEx)
		{
			throw new InvalidOperationException($"Ошибка при удалении упражнения: {dbEx.Message}", dbEx);
		}
	}
}

