namespace OnlineStoreApp.WebApi.DTO
{
    public class ProductDto
    {
        public int idProduct { get; set; }

        public int idProvider { get; set; }

        public string? product_ame { get; set; }

        public string? description { get; set; }

        public decimal price { get; set; }

        public int amount { get; set; }

        public string? providerName { get; set; }
    }
}

