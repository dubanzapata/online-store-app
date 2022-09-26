namespace OnlineStoreApp.WebApi.DTOs
{
    public class ProductDto
    {
        public int idProduct { get; set; }

        public int idProvider { get; set; }

        public string? productName { get; set; }

        public string? description { get; set; }

        public decimal price { get; set; }

        public int amount { get; set; }

        public string? providerName { get; set; }
    }
}

