using MediatR;

namespace BookStore.Api.Features.Books.GetBookById
{
    public record GetBookByIdQuery(Guid Id) : IRequest<GetBookByIdResponse?>;
}