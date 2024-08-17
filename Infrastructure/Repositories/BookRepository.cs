using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookContext _bookContext;

    public BookRepository(BookContext bookContext)
    {
        _bookContext = bookContext;
    }

    public async Task<IEnumerable<Book>> GetAllAsync() =>
        await _bookContext.Books.ToListAsync();

    public async Task<Book?> GetByIdAsync(int bookId) =>
        await _bookContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);


    public async Task<IEnumerable<Book>> FindByTitleOrAuthorAsync(string searchTerm)
    {
        var books = await _bookContext.Books
            .Where(x => x.Title.ToLower().Contains(searchTerm.ToLower())
                || x.Author.ToLower().Contains(searchTerm.ToLower()))
            .ToListAsync();

        return books;
    }

    public async Task Insert(Book book) => await _bookContext.Books.AddAsync(book);

    public void Remove(Book book) => _bookContext.Books.Remove(book);

    public async Task Save() => await _bookContext.SaveChangesAsync();
}
