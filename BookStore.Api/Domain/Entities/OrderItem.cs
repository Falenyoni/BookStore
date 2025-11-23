namespace BookStore.Api.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OrderId { get; set; }
        public Guid BookId { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; }

        // Navigation Properties
        public Order? Order { get; set; }
        public Book? Book { get; set; }
    }
}
