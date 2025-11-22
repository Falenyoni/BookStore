using MediatR;

namespace BookStore.Api.Features.Books._Events
{
    public class BookCreatedEvent : INotification
    {
        public Guid BookId { get; }
        public string Title { get; }
        public string Author { get; }

        public BookCreatedEvent(Guid bookId, string title, string author)
        {
            BookId = bookId;
            Title = title;
            Author = author;
        }
    }
}