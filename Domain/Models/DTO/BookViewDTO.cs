namespace Domain.Models.DTO;

public record BookViewDTO : BookBaseDTO
{
    public required int Id { get; init; }
}
