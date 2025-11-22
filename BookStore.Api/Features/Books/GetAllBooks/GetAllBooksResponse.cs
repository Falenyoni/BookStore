using BookStore.Api.Domain.Entities;

namespace BookStore.Api.Features.Books.GetAllBooks
{
    public class GetAllBooksResponse
    {
        public List<Book> Books { get; set; }
    }
}