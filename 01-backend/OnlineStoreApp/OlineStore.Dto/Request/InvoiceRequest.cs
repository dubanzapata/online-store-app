namespace OlineStore.Dto.Request
{
    public class InvoiceRequest
    {
        
        public int IdCustomer { get; set; }
        public DateTime Date { get; set; }
        public decimal? Price { get; set; }
        public int? Amount { get; set; }
        public decimal? SubTotal { get; set; }
    }
}
