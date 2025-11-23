using MediatR;

namespace BookStore.Api.Features.Books.CreateBook
{
    public static class CreateBookEndpoints
    {
        public static void MapCreateBookEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("api/books").WithTags("Books");

            group.MapPost("/", async (CreateBookCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
                .WithName("CreateBook");
        }
    }
}