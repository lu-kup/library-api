namespace Domain.Models.DTO;

public record BookCreateDTO
{
    public required string Title { get; init; }
    public required string Author { get; init; }
    public string? ISBN { get; init; }
    public int PublicationYear { get; init; }
}
