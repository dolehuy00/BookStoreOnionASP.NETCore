namespace Web.ViewModels
{
    public class ListProductPartialViewModel
    {
        public required string Title { get; set; }
        public required ICollection<ProductPartialItem> Items { get; set; }
        public class ProductPartialItem
        {
            public required string Image { get; set; }
            public required string Title { get; set; }
            public required string Note { get; set; }
            public required string Price { get; set; }
        }
    }
}
