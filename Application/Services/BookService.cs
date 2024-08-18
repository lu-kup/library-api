using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.Extensions.Logging;
using Application.Utilities;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.DTO;
using Domain.Models.Entities;

namespace Application.Services;

public class BookService : IBookService
{
    private const string InvalidSearchTermMessage = "Provided search term is null or whitespace.";

    private readonly IBookRepository _bookRepository;
    private readonly ILogger<BookService> _logger;

    public BookService(IBookRepository bookRepository, ILogger<BookService> logger)
    {
        _bookRepository = bookRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<BookViewDTO>> GetAllAsync()
    {
        var books = await _bookRepository.GetAllAsync();

        _logger.LogInformation($"Application successfully retrieved {books.Count()} books from the database.");

        return books.Select(x => MappingUtility.MapBookDTO(x));
    }

    public async Task<BookViewDTO> GetByIdAsync(int bookId)
    {
        var book = await _bookRepository.GetByIdAsync(bookId);

        if (book is null)
        {
            throw new BookNotFoundException(bookId);
        }

        _logger.LogInformation($"Application successfully retrieved book with Id {bookId} from the database.");

        return MappingUtility.MapBookDTO(book);
    }

    public async Task<BookViewDTO> CreateAsync(BookCreateDTO bookCreateDTO)
    {
        var createdBook = new Book(bookCreateDTO);

        await _bookRepository.Insert(createdBook);
        await _bookRepository.Save();

        _logger.LogInformation($"Application successfully added a new book with Id {createdBook.Id} to the database.");

        return MappingUtility.MapBookDTO(createdBook);
    }

    public async Task UpdateAsync(int bookId, BookUpdateDTO bookUpdateDTO)
    {
        var book = await _bookRepository.GetByIdAsync(bookId);

        if (book is null)
        {
            throw new BookNotFoundException(bookId);
        }

        book.UpdateValues(bookUpdateDTO);
        await _bookRepository.Save();

        _logger.LogInformation($"Application successfully updated a book with Id {book.Id}.");
    }

    public async Task DeleteAsync(int bookId)
    {
        var book = await _bookRepository.GetByIdAsync(bookId);

        if (book is null)
        {
            throw new BookNotFoundException(bookId);
        }

        _bookRepository.Remove(book);
        await _bookRepository.Save();
    }

    public async Task<IEnumerable<BookViewDTO>> SearchByTitleOrAuthorAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            throw new ValidationException(InvalidSearchTermMessage);
        }

        var books = await _bookRepository.FindByTitleOrAuthorAsync(searchTerm);

        _logger.LogInformation($"Application found {books.Count()} matching the search term.");

        return books.Select(x => MappingUtility.MapBookDTO(x)); 
    }
}
