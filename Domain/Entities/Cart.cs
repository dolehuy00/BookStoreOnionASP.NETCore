namespace Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<CartDetail>? CartDetails { get; }
    }
}
