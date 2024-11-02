namespace Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public int Quantity { get; set; }
        public required string Publisher { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public DateTime CreateOn { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<CartDetail>? CartDetails { get; }
        public ICollection<BookCatalogue>? BookCatalogues { get; }
        public ICollection<OrderItem>? OrderItems { get; }
    }
}
