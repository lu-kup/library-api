using Domain.Models.DTO;
using Domain.Models.Entities;

namespace Domain.Models.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int PublicationYear { get; set; }

    public Book(BookCreateDTO bookCreateDTO)
    {
        Id = id;
        Title = bookCreateDTO.Title;
        Author = bookCreateDTO.Author;
        ISBN = bookCreateDTO.ISBN;
        PublicationYear = bookCreateDTO.PublicationYear;
    }
}