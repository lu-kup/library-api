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

    [ProducesResponseType(200)]
    [HttpGet]
    public async Task<ActionResult> GetBooks()
    {
        var books = await _bookService.GetAllAsync();

        return Ok(books);
    }

    [ProducesResponseType(200)]
    [HttpGet("{id}")]
    public async Task<ActionResult> GetBookById([FromRoute] int id)
    {
        var bookViewDTO = await _bookService.GetByIdAsync(id);

        return Ok(bookViewDTO);
    }

    [ProducesResponseType(201)]
    [HttpPost]
    public async Task<ActionResult<BookViewDTO>> CreateBook([FromBody] BookCreateDTO bookCreateDTO)
    {
        var bookViewDTO = await _bookService.CreateAsync(bookCreateDTO);

        return StatusCode(201, bookViewDTO);
    }

    [ProducesResponseType(200)]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBook(
        [FromRoute] int id,
        [FromBody] BookUpdateDTO bookUpdateDTO)
    {
        await _bookService.UpdateAsync(id, bookUpdateDTO);

        return Ok();
    }

    [ProducesResponseType(200)]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBook(int id)
    {
        await _bookService.DeleteAsync(id);

        return Ok();
    }
}
