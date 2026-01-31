using FitnessTracker.Data;
using FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Services;

public class WorkoutSessionService
{
	private FitnessTrackerContext db;

	public WorkoutSessionService(FitnessTrackerContext context)
	{
		db = context;
	}

	public List<WorkoutSession> GetAll() => db.WorkoutSessions.ToList();

	public WorkoutSession? GetById(int id) => db.WorkoutSessions.FirstOrDefault(s => s.Id == id);

	public List<WorkoutSession> GetBySessionType(string sessionType) =>
			db.WorkoutSessions.Where(s => s.SessionType == sessionType).ToList();

	public List<WorkoutSession> GetByDateRange(DateTime startDate, DateTime endDate) =>
			db.WorkoutSessions.Where(s => s.Date >= startDate && s.Date <= endDate).ToList();

	public bool Add(WorkoutSession session)
	{
		try
		{
			db.WorkoutSessions.Add(session);
			int changes = db.SaveChanges();
			return changes > 0;
		}
		catch (DbUpdateException dbEx)
		{
			throw new InvalidOperationException($"Ошибка при добавлении тренировки: {dbEx.Message}", dbEx);
		}
	}

	public bool Update(WorkoutSession session)
	{
		try
		{
			var existing = GetById(session.Id);
			if (existing == null)
				throw new InvalidOperationException("Тренировка не найдена");

			db.WorkoutSessions.Update(session);
			int changes = db.SaveChanges();
			return changes > 0;
		}
		catch (DbUpdateException dbEx)
		{
			throw new InvalidOperationException($"Ошибка при обновлении тренировки: {dbEx.Message}", dbEx);
		}
	}

	public bool Delete(int id)
	{
		try
		{
			var session = GetById(id);
			if (session == null)
				throw new InvalidOperationException("Тренировка не найдена");

			db.WorkoutSessions.Remove(session);
			int changes = db.SaveChanges();
			return changes > 0;
		}
		catch (DbUpdateException dbEx)
		{
			throw new InvalidOperationException($"Ошибка при удалении тренировки: {dbEx.Message}", dbEx);
		}
	}
}
