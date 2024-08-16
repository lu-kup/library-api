using Domain.Models.DTO;

namespace Domain.Interfaces.Services;

public interface IBookService
{
    Task<IEnumerable<BookDTO>> GetAllAsync();
    Task<BookDTO> GetByIdAsync(int bookId);
    Task CreateAsync(BookCreateDTO bookCreateDTO);
    Task UpdateAsync(int bookId, BookUpdateDTO bookUpdateDTO);
    Task DeleteAsync(int bookId);
}
