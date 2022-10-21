using OlineStore.Dto.Request;
using OlineStore.Dto.Response;

namespace OlineStore.Contrats.Interfaces.Services
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceResponse>> ListInvoice();
        Task<InvoiceResponse> GetInvoice(int invoiceId);
        Task<InvoiceResponse> AddInvoice(InvoiceRequest invoiceRequest);
        Task<InvoiceResponse> UpdateInvoice(InvoiceRequest invoiceRequest, int invoiceId);
        Task<InvoiceResponse> DeleteInvoice(int invoiceId);
    }
}
