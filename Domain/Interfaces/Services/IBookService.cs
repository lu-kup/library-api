using Domain.Models.DTO;

namespace Domain.Interfaces.Services;

public interface IBookService
{
    Task<IEnumerable<BookViewDTO>> GetAllAsync();
    Task<BookViewDTO> GetByIdAsync(int bookId);
    Task<BookViewDTO> CreateAsync(BookCreateDTO bookCreateDTO);
    Task UpdateAsync(int bookId, BookUpdateDTO bookUpdateDTO);
    Task DeleteAsync(int bookId);
    Task<IEnumerable<BookViewDTO>> SearchByTitleOrAuthorAsync(string searchTerm);
}
