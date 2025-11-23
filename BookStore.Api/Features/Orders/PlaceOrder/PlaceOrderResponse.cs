namespace BookStore.Api.Features.Orders.PlaceOrder
{
    public record PlaceOrderResponse(
        Guid OrderId,
        DateTime OrderDate,
        decimal TotalAmount);
}