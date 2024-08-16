using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
}
