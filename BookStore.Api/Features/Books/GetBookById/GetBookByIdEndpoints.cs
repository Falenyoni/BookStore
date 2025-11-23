using MediatR;

namespace BookStore.Api.Features.Books.GetBookById
{
    public static class GetBookByIdEndpoints
    {
        public static void MapGetBookByIdEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("api/books").WithTags("Books");

            group.MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetBookByIdQuery(id));
                return result is null ? Results.NotFound() : Results.Ok(result);
            })
                .WithName("GetBookById");
        }
    }
}