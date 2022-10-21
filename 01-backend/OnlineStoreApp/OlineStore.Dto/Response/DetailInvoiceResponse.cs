namespace OlineStore.Dto.Response
{
    public class DetailInvoiceResponse
    {
        public int IdDetail { get; set; }
        public int IdProduct { get; set; }
        public int IdInvoice { get; set; }
        public decimal? Total { get; set; }
    }
}
