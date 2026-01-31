using FitnessTracker.Data;
using FitnessTracker.Models;

namespace FitnessTracker.Services;

public class TrainerService
{
    private readonly FitnessTrackerContext _context;

    public TrainerService(FitnessTrackerContext context)
    {
        _context = context;
    }

    public List<Trainer> GetAll() => _context.Trainers.ToList();

    public Trainer? GetById(int id) => _context.Trainers.FirstOrDefault(t => t.Id == id);

    public List<Trainer> GetBySpecialization(string specialization) =>
        _context.Trainers.Where(t => t.Specialization.Contains(specialization)).ToList();

    public List<Trainer> GetByMinimumExperience(int years) =>
        _context.Trainers.Where(t => t.ExperienceYears >= years).ToList();

    public void Add(Trainer trainer)
    {
        _context.Trainers.Add(trainer);
        _context.SaveChanges();
    }

    public void Update(Trainer trainer)
    {
        _context.Trainers.Update(trainer);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var trainer = GetById(id);
        if (trainer != null)
        {
            _context.Trainers.Remove(trainer);
            _context.SaveChanges();
        }
    }
}
