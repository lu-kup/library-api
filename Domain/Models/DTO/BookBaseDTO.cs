namespace Domain.Models.DTO;

public record BookBaseDTO
{
    public string? Author { get; init; }
    public string Title { get; init; }
    public string ISBN { get; init; }
    public int PublicationYear { get; init; }
}