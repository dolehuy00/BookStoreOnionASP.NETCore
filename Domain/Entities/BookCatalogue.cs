namespace Domain.Entities
{
    public class BookCatalogue
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CatalogueId { get; set; }
        public Book? Book { get; set; }
        public Catalogue? Catalogue { get; set; }
    }
}
