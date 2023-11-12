namespace MeliClon.Models.Request
{
    public class ProductRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public string Category { get; set; }
        public string UrlImage { get; set; }
        public decimal Cost { get; set; }
        public int Count { get; set; }

    }
}
