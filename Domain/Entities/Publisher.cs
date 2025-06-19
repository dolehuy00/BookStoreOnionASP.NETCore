namespace Domain.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Address { get; set; }
        public ICollection<Book>? Books { get; }
    }
}
