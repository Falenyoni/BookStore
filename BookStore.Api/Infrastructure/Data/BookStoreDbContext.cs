using BookStore.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Infrastructure.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books => Set<Book>();
    }
}