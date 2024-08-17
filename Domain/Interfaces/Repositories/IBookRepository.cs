using Domain.Models.Entities;

namespace Domain.Interfaces.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int bookId);
    Task<IEnumerable<Book>> FindByTitleOrAuthorAsync(string searchTerm);
    Task Insert(Book book);
    void Remove(Book book);
    Task Save();
}