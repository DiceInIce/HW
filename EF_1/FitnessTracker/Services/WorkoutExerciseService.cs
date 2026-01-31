using FitnessTracker.Data;
using FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Services;

public class WorkoutExerciseService
{
	private FitnessTrackerContext db;

	public WorkoutExerciseService(FitnessTrackerContext context)
	{
		db = context;
	}

	public List<WorkoutExercise> GetAll() =>
		db.WorkoutExercises
			.Include(we => we.WorkoutSession)
			.Include(we => we.Exercise)
			.ToList();

	public WorkoutExercise? GetById(int id) =>
		db.WorkoutExercises
			.Include(we => we.WorkoutSession)
			.Include(we => we.Exercise)
			.FirstOrDefault(we => we.Id == id);

	public List<WorkoutExercise> GetByWorkoutSessionId(int workoutSessionId) =>
		db.WorkoutExercises
			.Where(we => we.WorkoutSessionId == workoutSessionId)
			.Include(we => we.WorkoutSession)
			.Include(we => we.Exercise)
			.ToList();

	public List<WorkoutExercise> GetByExerciseId(int exerciseId) =>
		db.WorkoutExercises
			.Where(we => we.ExerciseId == exerciseId)
			.Include(we => we.WorkoutSession)
			.Include(we => we.Exercise)
			.ToList();

	public bool Add(WorkoutExercise workoutExercise)
	{
		try
		{
			// Проверка на уникальность пары WorkoutSessionId + ExerciseId
			var existing = db.WorkoutExercises
				.FirstOrDefault(we => we.WorkoutSessionId == workoutExercise.WorkoutSessionId 
					&& we.ExerciseId == workoutExercise.ExerciseId);
			
			if (existing != null)
				throw new InvalidOperationException("Это упражнение уже добавлено в данную тренировку");

			db.WorkoutExercises.Add(workoutExercise);
			int changes = db.SaveChanges();
			return changes > 0;
		}
		catch (DbUpdateException dbEx)
		{
			throw new InvalidOperationException($"Ошибка при добавлении упражнения в тренировку: {dbEx.Message}", dbEx);
		}
	}

	public bool Update(WorkoutExercise workoutExercise)
	{
		try
		{
			var existing = GetById(workoutExercise.Id);
			if (existing == null)
				throw new InvalidOperationException("Упражнение в тренировке не найдено");

			// Если изменились WorkoutSessionId или ExerciseId, проверяем уникальность
			if (existing.WorkoutSessionId != workoutExercise.WorkoutSessionId 
				|| existing.ExerciseId != workoutExercise.ExerciseId)
			{
				var duplicate = db.WorkoutExercises
					.FirstOrDefault(we => we.WorkoutSessionId == workoutExercise.WorkoutSessionId 
						&& we.ExerciseId == workoutExercise.ExerciseId
						&& we.Id != workoutExercise.Id);
				
				if (duplicate != null)
					throw new InvalidOperationException("Это упражнение уже добавлено в данную тренировку");
			}

			db.WorkoutExercises.Update(workoutExercise);
			int changes = db.SaveChanges();
			return changes > 0;
		}
		catch (DbUpdateException dbEx)
		{
			throw new InvalidOperationException($"Ошибка при обновлении упражнения в тренировке: {dbEx.Message}", dbEx);
		}
	}

	public bool Delete(int id)
	{
		try
		{
			var workoutExercise = GetById(id);
			if (workoutExercise == null)
				throw new InvalidOperationException("Упражнение в тренировке не найдено");

			db.WorkoutExercises.Remove(workoutExercise);
			int changes = db.SaveChanges();
			return changes > 0;
		}
		catch (DbUpdateException dbEx)
		{
			throw new InvalidOperationException($"Ошибка при удалении упражнения из тренировки: {dbEx.Message}", dbEx);
		}
	}
}
