namespace FitnessTracker.Models;

public class Client
{
	public int Id { get; set; }
	public string FullName { get; set; } = string.Empty;
	public DateTime BirthDate { get; set; }
	public string MembershipType { get; set; } = string.Empty;
	public DateTime RegistrationDate { get; set; }
	public string? Email { get; set; }
}
