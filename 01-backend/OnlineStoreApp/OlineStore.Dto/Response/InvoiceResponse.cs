using OlineStore.Dto.Models;

namespace OlineStore.Dto.Response
{
    public class InvoiceResponse
    {
        public int IdInvoice { get; set; }
        public int IdCustomer { get; set; }
        public DateTime Date { get; set; }
        public decimal? Price { get; set; }
        public int? Amount { get; set; }
        public decimal? SubTotal { get; set; }
        public string? NameCustomer { get; set; }

        public  List<DetailInvoiceResponse>? DetailInvoices { get; set; }

    }
}
