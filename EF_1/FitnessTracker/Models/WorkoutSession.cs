namespace FitnessTracker.Models;

public class WorkoutSession
{
	public int Id { get; set; }
	public DateTime Date { get; set; }
	public int DurationMinutes { get; set; }
	public int CaloriesBurned { get; set; }
	public string SessionType { get; set; } = string.Empty;

	// Foreign keys
	public int? ClientId { get; set; }
	public int? TrainerId { get; set; }

	// Navigation properties
	public virtual Client? Client { get; set; }
	public virtual Trainer? Trainer { get; set; }
	public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
}
