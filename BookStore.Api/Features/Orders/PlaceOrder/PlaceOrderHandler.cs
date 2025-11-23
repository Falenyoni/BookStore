using BookStore.Api.Domain.Entities;
using BookStore.Api.Features.Orders._Events;
using BookStore.Api.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Features.Orders.PlaceOrder
{
    public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand, PlaceOrderResponse>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMediator _mediator;

        public PlaceOrderHandler(BookStoreDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<PlaceOrderResponse> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            // Fetch Books
            var books = await _context.Books
                .Where(b => request.BookIds.Contains(b.Id))
                .ToListAsync(cancellationToken);

            if (books.Count == 0)
                throw new Exception("No valid books found for the order");

            var totalAmount = books.Sum(b => b.Price);

            var order = new Order
            {
                CustomerId = request.CustomerId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = totalAmount
            };

            // Create order items for each book
            foreach (var book in books)
            {
                var orderItem = new OrderItem
                {
                    BookId = book.Id,
                    Price = book.Price,
                };

                order.OrdeItems.Add(orderItem);
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);

            // Raise domain event asynchronously
            await _mediator.Publish(new OrderPlacedEvent(order.Id, request.CustomerId),
                cancellationToken);

            return new PlaceOrderResponse(order.Id, order.OrderDate, order.TotalAmount);
        }
    }
}