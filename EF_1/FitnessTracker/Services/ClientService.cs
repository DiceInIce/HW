using FitnessTracker.Data;
using FitnessTracker.Models;

namespace FitnessTracker.Services;

public class ClientService
{
    private readonly FitnessTrackerContext _context;

    public ClientService(FitnessTrackerContext context)
    {
        _context = context;
    }

    public List<Client> GetAll() => _context.Clients.ToList();

    public Client? GetById(int id) => _context.Clients.FirstOrDefault(c => c.Id == id);

    public List<Client> GetByMembershipType(string membershipType) =>
        _context.Clients.Where(c => c.MembershipType == membershipType).ToList();

    public void Add(Client client)
    {
        _context.Clients.Add(client);
        _context.SaveChanges();
    }

    public void Update(Client client)
    {
        _context.Clients.Update(client);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var client = GetById(id);
        if (client != null)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }
    }
}
