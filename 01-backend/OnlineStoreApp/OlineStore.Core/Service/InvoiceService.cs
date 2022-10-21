using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OlineStore.Contrats.Interfaces.Repositories;
using OlineStore.Contrats.Interfaces.Services;
using OlineStore.Dto.Models;
using OlineStore.Dto.Request;
using OlineStore.Dto.Response;

namespace OlineStore.Core.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<InvoiceResponse> AddInvoice(InvoiceRequest invoiceRequest)
        {
            var invoice = _mapper.Map<Invoice>(invoiceRequest);
            await _invoiceRepository.Add(invoice);
            return _mapper.Map<InvoiceResponse>(invoice);

        }

        public async Task<InvoiceResponse> DeleteInvoice(int invoiceId)
        {
            var invoice = await _invoiceRepository.FindBy(x => x.IdInvoice == invoiceId).FirstOrDefaultAsync();
            await _invoiceRepository.Delete(invoice!);
            return _mapper.Map<InvoiceResponse>(invoice);
        }

        public async Task<InvoiceResponse> GetInvoice(int invoiceId)
        {
            var invoice = await _invoiceRepository.FindBy(x => x.IdInvoice== invoiceId).FirstOrDefaultAsync();
            return _mapper.Map<InvoiceResponse>(invoice);
        }

        public async Task<IEnumerable<InvoiceResponse>> ListInvoice()
        {
            var invoice = await _invoiceRepository.GetAll().ToListAsync();
            return _mapper.Map<IEnumerable<InvoiceResponse>>(invoice);

        }

        public async Task<InvoiceResponse> UpdateInvoice(InvoiceRequest invoiceRequest, int invoiceId)
        {
            var invoice = await _invoiceRepository.FindBy(x => x.IdInvoice== invoiceId).FirstOrDefaultAsync();
            _mapper.Map(invoiceRequest, invoice);
            await _invoiceRepository.Update(invoice!);
            return _mapper.Map<InvoiceResponse>(invoice);


        }
    }
}
