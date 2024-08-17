namespace Domain.Exceptions;

public class BookNotFoundException : EntityNotFoundException
{
    public BookNotFoundException(int bookId) : base($"Book with Id {bookId} was not found.")
    {
    }
}
