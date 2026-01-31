using FitnessTracker.Data;
using FitnessTracker.Models;

namespace FitnessTracker.Services;

public class ExerciseService
{
    private readonly FitnessTrackerContext _context;

    public ExerciseService(FitnessTrackerContext context)
    {
        _context = context;
    }

    public List<Exercise> GetAll() => _context.Exercises.ToList();

    public Exercise? GetById(int id) => _context.Exercises.FirstOrDefault(e => e.Id == id);

    public List<Exercise> GetByDifficulty(string difficulty) =>
        _context.Exercises.Where(e => e.DifficultyLevel == difficulty).ToList();

    public List<Exercise> GetByMuscleGroup(string muscleGroup) =>
        _context.Exercises.Where(e => e.TargetMuscleGroup.Contains(muscleGroup)).ToList();

    public void Add(Exercise exercise)
    {
        _context.Exercises.Add(exercise);
        _context.SaveChanges();
    }

    public void Update(Exercise exercise)
    {
        _context.Exercises.Update(exercise);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var exercise = GetById(id);
        if (exercise != null)
        {
            _context.Exercises.Remove(exercise);
            _context.SaveChanges();
        }
    }
}
