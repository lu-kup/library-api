using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions options) : base(options)
    {
    }
}
