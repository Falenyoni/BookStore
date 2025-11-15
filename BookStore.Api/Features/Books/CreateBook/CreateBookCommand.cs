using MediatR;

namespace BookStore.Api.Features.Books.CreateBook
{
    public record CreateBookCommand(
        string Title,
        string Author,
        decimal Price,
        DateTime PublishedOn) : IRequest<CreateBookResponse>;
}