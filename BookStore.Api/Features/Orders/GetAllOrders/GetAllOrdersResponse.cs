using BookStore.Api.Domain.Entities;

namespace BookStore.Api.Features.Orders.GetAllOrders
{
    public record GetAllOrdersResponse(
        Guid OrderId,
        DateTime OrderDate,
        decimal TotalAmount
        );
}