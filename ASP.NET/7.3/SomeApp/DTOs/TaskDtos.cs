namespace SomeApp.DTOs;

public record TaskRequestDto(string Name);

public class TaskResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}
