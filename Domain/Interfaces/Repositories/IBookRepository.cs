using Domain.Models.Entities;

namespace Domain.Interfaces.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int bookId);
    Task Insert(Book book);
    void Remove(Book book);
    Task Save();
}