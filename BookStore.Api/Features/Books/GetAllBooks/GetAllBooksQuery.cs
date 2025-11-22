using BookStore.Api.Features.Books.GetBookById;
using MediatR;

namespace BookStore.Api.Features.Books.GetAllBooks
{
    public record GetAllBooksQuery() : IRequest<GetAllBooksResponse?>;
}