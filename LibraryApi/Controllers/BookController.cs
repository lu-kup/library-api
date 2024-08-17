using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Services;
using Domain.Models.DTO;

namespace LibraryApi.Controllers;

[Produces("application/json")]
[Route("api/books")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _bookService.GetAllAsync();

        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById([FromRoute] int bookId)
    {
        var bookViewDTO = await _bookService.GetByIdAsync(bookId);

        return Ok(bookViewDTO);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] BookCreateDTO bookCreateDTO)
    {
        await _bookService.CreateAsync(bookCreateDTO);

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(
        [FromRoute] int bookId,
        [FromBody] BookUpdateDTO bookUpdateDTO)
    {
        await _bookService.UpdateAsync(bookId, bookUpdateDTO);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int bookId)
    {
        await _bookService.DeleteAsync(bookId);

        return NoContent();
    }
}
