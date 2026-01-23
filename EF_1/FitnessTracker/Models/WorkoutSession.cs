namespace FitnessTracker.Models;

public class WorkoutSession
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int DurationMinutes { get; set; }
    public int CaloriesBurned { get; set; }
    public string SessionType { get; set; } = string.Empty;
}
