namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Phone { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public Cart? Cart { get; set; }
        public ICollection<CartDetail>? CartDetails { get; }
        public ICollection<Order>? Orders { get; }
    }
}
