using MediatR;

namespace BookStore.Api.Features.Orders._Events
{
    public class OrderPlacedEvent : INotification
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }

        public OrderPlacedEvent(Guid orderId, Guid customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
        }
    }
}