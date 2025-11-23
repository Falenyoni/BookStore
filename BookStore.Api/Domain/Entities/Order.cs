namespace BookStore.Api.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }

        // Optional: navigation property for books in the order
        public List<OrderItem> OrdeItems { get; set; } = new List<OrderItem>();
    }
}