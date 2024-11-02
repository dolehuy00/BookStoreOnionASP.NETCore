namespace Domain.Entities
{
    public class Catalogue
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public ICollection<BookCatalogue>? BookCatalogues { get; }
    }
}
