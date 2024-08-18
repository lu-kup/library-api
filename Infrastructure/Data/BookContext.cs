using Microsoft.EntityFrameworkCore;
using Domain.Models.Entities;

namespace Infrastructure.Data;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.Entity<Book>().HasKey(x => x.Id);
}
