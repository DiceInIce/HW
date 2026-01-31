using FitnessTracker.Data;
using FitnessTracker.Models;

namespace FitnessTracker.Services;

public class WorkoutSessionService
{
    private readonly FitnessTrackerContext _context;

    public WorkoutSessionService(FitnessTrackerContext context)
    {
        _context = context;
    }

    public List<WorkoutSession> GetAll() => _context.WorkoutSessions.ToList();

    public WorkoutSession? GetById(int id) => _context.WorkoutSessions.FirstOrDefault(s => s.Id == id);

    public List<WorkoutSession> GetBySessionType(string sessionType) =>
        _context.WorkoutSessions.Where(s => s.SessionType == sessionType).ToList();

    public List<WorkoutSession> GetByDateRange(DateTime startDate, DateTime endDate) =>
        _context.WorkoutSessions.Where(s => s.Date >= startDate && s.Date <= endDate).ToList();

    public void Add(WorkoutSession session)
    {
        _context.WorkoutSessions.Add(session);
        _context.SaveChanges();
    }

    public void Update(WorkoutSession session)
    {
        _context.WorkoutSessions.Update(session);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var session = GetById(id);
        if (session != null)
        {
            _context.WorkoutSessions.Remove(session);
            _context.SaveChanges();
        }
    }
}
