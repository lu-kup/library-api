using Domain.Models.DTO;
using Domain.Models.Validation;

namespace Domain.Models.Entities;

#nullable disable warnings
public class Book
{
    public int Id { get; init; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public int PublicationYear { get; private set; }

    public Book()
    {
    }

    public Book(BookCreateDTO bookCreateDTO)
    {
        SetTitle(bookCreateDTO.Title);
        Author = bookCreateDTO.Author;
        SetISBN(bookCreateDTO.ISBN);
        SetPublicationYear(bookCreateDTO.PublicationYear);
    }

    public void UpdateValues(BookUpdateDTO bookUpdateDTO)
    {
        if (bookUpdateDTO.Title is not null)
        {
            SetTitle(bookUpdateDTO.Title);
        }
        if (bookUpdateDTO.Author is not null)
        {
            Author = bookUpdateDTO.Author;
        }
        if (bookUpdateDTO.ISBN is not null)
        {
            SetISBN(bookUpdateDTO.ISBN);
        }
        if (bookUpdateDTO.PublicationYear is not null)
        {
            SetPublicationYear(bookUpdateDTO.PublicationYear.Value);
        }
    }

    private void SetTitle(string title)
    {
        BookValidation.ValidateIsNullOrWhiteSpace(title);
        Title = title;
    }

    private void SetISBN(string isbn)
    {
        BookValidation.ValidateISBN(isbn);
        ISBN = isbn;
    }

    private void SetPublicationYear(int publicationYear)
    {
        BookValidation.ValidatePublicationYear(publicationYear);
        PublicationYear = publicationYear;
    }
}
