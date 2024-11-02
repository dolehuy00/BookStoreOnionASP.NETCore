namespace Shared
{
    public class BookDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public int Quantity { get; set; }
        public required string Publisher { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public DateTime? CreateOn { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
