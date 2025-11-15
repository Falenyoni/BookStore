namespace BookStore.Api.Features.Books.CreateBook
{
    public class CreateBookResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedOn { get; set; }
    }
}