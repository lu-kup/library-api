using Domain.Models.DTO;
using Domain.Models.Entities;

namespace Application.Utilities;

public static class MappingUtility
{
    public static BookDTO MapBookDTO(Book book) =>
        new()
        {
            Id = book.Id,
            Author = book.Author,
            Title = book.Title,
            ISBN = book.ISBN,
            PublicationYear = book.PublicationYear
        };
}