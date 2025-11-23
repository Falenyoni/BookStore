using BookStore.Api.Infrastructure.Data;
using MediatR;

namespace BookStore.Api.Features.Orders.GetOrderById
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdResponse>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMediator _mediator;

        public GetOrderByIdHandler(BookStoreDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<GetOrderByIdResponse?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .FindAsync(new object?[] { request.OrderId }, cancellationToken);

            if (order is null)
                return null;

            return new GetOrderByIdResponse(order.Id, order.OrderDate, order.TotalAmount);
        }
    }
}