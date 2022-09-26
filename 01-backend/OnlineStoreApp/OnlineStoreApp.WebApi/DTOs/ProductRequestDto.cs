namespace OnlineStoreApp.WebApi.DTOs
{
    public class ProductRequestDto
    {
        public int IdProduct { get; set; }
        public int IdProvider { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string? ProviderName { get; set; }
        

    }
}
