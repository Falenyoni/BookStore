using MediatR;

namespace BookStore.Api.Features.Orders.PlaceOrder
{
    public static class PlaceOrderEndpoints
    {
        public static void MapPlaceOrderEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("api/orders").WithTags("Orders");

            group.MapPost("/", async (PlaceOrderCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
                .WithName("PlaceOrder");
        }
    }
}