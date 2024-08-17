using System.ComponentModel.DataAnnotations;
using System.Data;
using Domain.Models.DTO;
using Domain.Models.Entities;
using Domain.Models.Validation;
using System;

namespace Domain.Models.Entities;

public class Book
{
    public int Id { get; init; }
    public string? Author { get; private set; }
    public string Title { get; private set; }
    public string ISBN { get; private set; }
    public int PublicationYear { get; private set; }

    public Book()
    {
    }

    public Book(BookCreateDTO bookCreateDTO) =>
        SetValues(bookCreateDTO);

    public void UpdateValues(BookUpdateDTO bookUpdateDTO) =>
        SetValues(bookUpdateDTO);

    private void SetValues(BookBaseDTO bookDTO)
    {
        Author = bookDTO.Author;
        SetTitle(bookDTO.Title);
        SetISBN(bookDTO.ISBN);
        SetPublicationYear(bookDTO.PublicationYear);
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
