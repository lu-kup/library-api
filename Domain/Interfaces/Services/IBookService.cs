using Domain.Models.DTO;

namespace Domain.Interfaces.Services;

public interface IBookService
{
    Task<IEnumerable<BookViewDTO>> GetAllAsync();
    Task<BookViewDTO> GetByIdAsync(int bookId);
    Task CreateAsync(BookCreateDTO bookCreateDTO);
    Task UpdateAsync(int bookId, BookUpdateDTO bookUpdateDTO);
    Task DeleteAsync(int bookId);
}
