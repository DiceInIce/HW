namespace FitnessTracker.Models;

public class Exercise
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string DifficultyLevel { get; set; } = string.Empty;
	public string EquipmentRequired { get; set; } = string.Empty;
	public string TargetMuscleGroup { get; set; } = string.Empty;

	// Navigation property
	public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
}
