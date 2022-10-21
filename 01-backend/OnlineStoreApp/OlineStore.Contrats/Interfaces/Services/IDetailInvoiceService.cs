using OlineStore.Dto.Request;
using OlineStore.Dto.Response;

namespace OlineStore.Contrats.Interfaces.Services
{
    public interface IDetailInvoiceService
    {
         Task<IEnumerable<DetailInvoiceResponse>> ListDetail();
        Task<DetailInvoiceResponse> GetDetail(int detailId);
        Task<DetailInvoiceResponse> AddDetail(DetailInvoiceRequest detailInvoiceRequest);
        Task<DetailInvoiceResponse> UpdateDetail(DetailInvoiceRequest detailInvoiceRequest, int detailId);
        Task<DetailInvoiceResponse> DeleteDetail(int detailId);
    }
}
