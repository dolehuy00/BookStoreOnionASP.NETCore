namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public double TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public required string ShippingAddress { get; set; }
        public required string Phone { get; set; }
        public required string PaymentMethod { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<OrderItem>? OrderItems { get; }
    }
}
