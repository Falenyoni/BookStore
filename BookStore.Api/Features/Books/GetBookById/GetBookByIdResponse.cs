namespace BookStore.Api.Features.Books.GetBookById
{
    public class GetBookByIdResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime PublishedOn { get; set; }
    }
}