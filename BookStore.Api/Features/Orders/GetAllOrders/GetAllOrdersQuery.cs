using MediatR;

namespace BookStore.Api.Features.Orders.GetAllOrders
{
    public record GetAllOrdersQuery() : IRequest<List<GetAllOrdersResponse>>;
}