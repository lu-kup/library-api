namespace Domain.Models.DTO;

public record BookUpdateDTO
{
    public required string Title { get; init; }
    public required string Author { get; init; }
    public string? ISBN { get; init; }
    public int PublicationYear { get; init; }
}
