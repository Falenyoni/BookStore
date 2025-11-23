using MediatR;

namespace BookStore.Api.Features.Orders.GetOrderById
{
    public record GetOrderByIdQuery(Guid OrderId) : IRequest<GetOrderByIdResponse>;
}