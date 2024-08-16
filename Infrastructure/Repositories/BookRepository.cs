using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookContext _context;

    public BookRepository(BookContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllAsync() =>
        await _context.Books.ToListAsync();

    public async Task<Book?> GetByIdAsync(int bookId) =>
        await _context.Books.FirstOrDefaultAsync(x => x.Id == bookId);

    public async Task Insert(Book book) => await _context.Books.AddAsync(book);

    public void Remove(Book book) => _context.Books.Remove(book);

    public async Task Save() => await _context.SaveChangesAsync();
}
