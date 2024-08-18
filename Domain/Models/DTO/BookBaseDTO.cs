namespace Domain.Models.DTO;

public record BookBaseDTO
{
    public required string Author { get; init; }
    public required string Title { get; init; }
    public required string ISBN { get; init; }
    public required int PublicationYear { get; init; }
}
