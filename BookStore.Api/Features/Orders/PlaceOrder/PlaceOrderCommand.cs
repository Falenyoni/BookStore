using MediatR;

namespace BookStore.Api.Features.Orders.PlaceOrder
{
    public record PlaceOrderCommand(
        Guid CustomerId,
        List<Guid> BookIds) : IRequest<PlaceOrderResponse>;
}