using FitnessTracker.Data;
using FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Services;

public class TrainerService
{
	private FitnessTrackerContext db;

	public TrainerService(FitnessTrackerContext context)
	{
		db = context;
	}

	public List<Trainer> GetAll() => db.Trainers.ToList();

	public Trainer? GetById(int id) => db.Trainers.FirstOrDefault(t => t.Id == id);

	public List<Trainer> GetBySpecialization(string specialization) =>
			db.Trainers.Where(t => t.Specialization.Contains(specialization)).ToList();

	public List<Trainer> GetByMinimumExperience(int years) =>
			db.Trainers.Where(t => t.ExperienceYears >= years).ToList();

	public bool Add(Trainer t)
	{
		try
		{
			db.Trainers.Add(t);
			int changes = db.SaveChanges();
			return changes > 0;
		}
		catch (DbUpdateException dbEx)
		{
			throw new InvalidOperationException($"Ошибка при добавлении тренера: {dbEx.Message}", dbEx);
		}
	}

	public bool Update(Trainer t)
	{
		try
		{
			var existing = GetById(t.Id);
			if (existing == null)
				throw new InvalidOperationException("Тренер не найден");

			db.Trainers.Update(t);
			int changes = db.SaveChanges();
			return changes > 0;
		}
		catch (DbUpdateException dbEx)
		{
			throw new InvalidOperationException($"Ошибка при обновлении тренера: {dbEx.Message}", dbEx);
		}
	}

	public bool Delete(int id)
	{
		try
		{
			var t = GetById(id);
			if (t == null)
				throw new InvalidOperationException("Тренер не найден");

			db.Trainers.Remove(t);
			int changes = db.SaveChanges();
			return changes > 0;
		}
		catch (DbUpdateException dbEx)
		{
			throw new InvalidOperationException($"Ошибка при удалении тренера: {dbEx.Message}", dbEx);
		}
	}
}
