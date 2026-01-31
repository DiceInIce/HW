using FitnessTracker.Data;
using FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Services;

public class ClientService
{
	private FitnessTrackerContext db;

	public ClientService(FitnessTrackerContext context)
	{
		db = context;
	}

	public List<Client> GetAll() => db.Clients.ToList();

	public Client? GetById(int id) => db.Clients.FirstOrDefault(c => c.Id == id);

	public List<Client> GetByMembershipType(string membershipType) =>
			db.Clients.Where(c => c.MembershipType == membershipType).ToList();

	public bool Add(Client c)
	{
		try
		{
			db.Clients.Add(c);
			int changes = db.SaveChanges();
			return changes > 0;
		}
		catch (DbUpdateException dbEx)
		{
			var inner = dbEx.InnerException?.Message ?? dbEx.Message;
			throw new InvalidOperationException($"Ошибка при добавлении клиента: {inner}", dbEx);
		}
	}

	public bool Update(Client c)
	{
		try
		{
			var existing = GetById(c.Id);
			if (existing == null)
				throw new InvalidOperationException("Клиент не найден");

			db.Clients.Update(c);
			int changes = db.SaveChanges();
			return changes > 0;
		}
		catch (DbUpdateException dbEx)
		{
			var inner = dbEx.InnerException?.Message ?? dbEx.Message;
			throw new InvalidOperationException($"Ошибка при обновлении клиента: {inner}", dbEx);
		}
	}

	public bool Delete(int id)
	{
		try
		{
			var c = GetById(id);
			if (c == null)
				throw new InvalidOperationException("Клиент не найден");

			db.Clients.Remove(c);
			int changes = db.SaveChanges();
			return changes > 0;
		}
		catch (DbUpdateException dbEx)
		{
			var inner = dbEx.InnerException?.Message ?? dbEx.Message;
			throw new InvalidOperationException($"Ошибка при удалении клиента: {inner}", dbEx);
		}
	}
}
