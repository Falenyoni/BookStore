using MediatR;

namespace BookStore.Api.Features.Books.GetAllBooks
{
    public static class GetAllBooksEndpoints
    {
        public static void MapGetAllBooksEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("api/books").WithTags("Books");

            group.MapGet("", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAllBooksQuery());
                return Results.Ok(result);
            })
                .WithName("GetAllBooks");
        }
    }
}