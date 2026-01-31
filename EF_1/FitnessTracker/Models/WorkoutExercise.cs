namespace FitnessTracker.Models;

public class WorkoutExercise
{
	public int Id { get; set; }
	public int WorkoutSessionId { get; set; }
	public int ExerciseId { get; set; }
	public int Sets { get; set; }
	public int Repetitions { get; set; }
	public decimal? Weight { get; set; }

	// Navigation properties
	public virtual WorkoutSession WorkoutSession { get; set; } = null!;
	public virtual Exercise Exercise { get; set; } = null!;
}
