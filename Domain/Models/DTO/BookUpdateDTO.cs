namespace Domain.Models.DTO;

public record BookUpdateDTO
{
    public string? Title { get; init; }
    public string? Author { get; init; }
    public string? ISBN { get; init; }
    public int? PublicationYear { get; init; }
}
