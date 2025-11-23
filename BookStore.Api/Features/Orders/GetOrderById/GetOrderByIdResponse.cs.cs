using BookStore.Api.Infrastructure.Data;
using MediatR;

namespace BookStore.Api.Features.Orders.GetOrderById
{
    public record GetOrderByIdResponse(
        Guid OrderId,
        DateTime OrderDate,
        decimal TotalAmount
        );
}