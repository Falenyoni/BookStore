using MediatR;

namespace BookStore.Api.Features.Orders.GetOrderById
{
    public static class GetOrderByIdEndpoints
    {
        public static void MapGetOrderByIdEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("api/orders").WithTags("Orders");

            group.MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetOrderByIdQuery(id));
                return result is null ? Results.NotFound() : Results.Ok(result);
            })
            .WithName("GetOrderById");
        }
    }
}