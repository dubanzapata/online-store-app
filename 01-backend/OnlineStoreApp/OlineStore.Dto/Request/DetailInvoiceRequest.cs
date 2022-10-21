namespace OlineStore.Dto.Request
{
    public class DetailInvoiceRequest
    {
        
        public int IdProduct { get; set; }
        public int IdInvoice { get; set; }
        public decimal? Total { get; set; }
    }
}
