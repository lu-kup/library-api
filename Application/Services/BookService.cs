using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.DTO;
using Application.Utilities;
using System.Data;
using Domain.Exceptions;
using Microsoft.Extensions.Logging;
using Domain.Models.Entities;

namespace Application.Services;

public class BookService : IBookService
{
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

        _logger.LogInformation($"Successfully retrieved {books.Count()} books from the database.");

        return books.Select(x => MappingUtility.MapBookDTO(x));
    }

    public async Task<BookViewDTO> GetByIdAsync(int bookId)
    {
        var book = await _bookRepository.GetByIdAsync(bookId);

        if (book is null)
        {
            throw new BookNotFoundException(bookId);
        }

        _logger.LogInformation($"Successfully retrieved book with Id {bookId} from the database.");

        return MappingUtility.MapBookDTO(book);
    }

    public async Task<BookViewDTO> CreateAsync(BookCreateDTO bookCreateDTO)
    {
        var createdBook = new Book(bookCreateDTO);

        await _bookRepository.Insert(createdBook);
        await _bookRepository.Save();

        _logger.LogInformation($"Successfully added a new book with Id {createdBook.Id} to the database.");

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

        _logger.LogInformation($"Successfully updated a book with Id {book.Id}.");
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
}
