namespace FitnessTracker.Models;

public class Trainer
{
	public int Id { get; set; }
	public string FullName { get; set; } = string.Empty;
	public string Specialization { get; set; } = string.Empty;
	public int ExperienceYears { get; set; }
	public string PhoneNumber { get; set; } = string.Empty;

	// Navigation property
	public virtual ICollection<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
}
