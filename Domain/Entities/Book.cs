namespace Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double CurrentPrice { get; set; }
        public DateTime CreateOn { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        // FK
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public ICollection<CartDetail>? CartDetails { get; }
        public ICollection<BookCatalogue>? BookCatalogues { get; }
        public ICollection<OrderItem>? OrderItems { get; }
    }
}
