using BookStore.Api.Domain.Entities;
using MediatR;

namespace BookStore.Api.Features.Orders.GetAllOrders
{
    public static class GetAllOrdersEndpoints
    {
        public static void MapGetAllOrdersEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("api/orders").WithTags("Orders");

            group.MapGet("", async (IMediator mediator) =>
            {
                var orders = await mediator.Send(new GetAllOrdersQuery());
                return Results.Ok(orders);
            })
                .WithName("GetAllOrders");
        }
    }
}