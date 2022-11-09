using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OlineStore.Contrats.Interfaces.Repositories;
using OlineStore.Contrats.Interfaces.Services;
using OlineStore.Dto.Models;
using OlineStore.Dto.Request;
using OlineStore.Dto.Response;
using OnlineStore.Infraestructura;

namespace OlineStore.Core.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        private readonly GestoresDbContext _context;
        private readonly IDetailInvoiceRepository _detailInvoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper, GestoresDbContext context,IDetailInvoiceRepository detailInvoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _context = context;
            _detailInvoiceRepository = detailInvoiceRepository;
        }

 
        public async Task<InvoiceResponse> AddInvoice(InvoiceRequest invoiceRequest)
        {
            
            var invoiceResult = new InvoiceResponse();
            using(var transaction= _context.Database.BeginTransaction())
            {
                try
                {
                    var invoice = _mapper.Map<Invoice>(invoiceRequest);
                    await _invoiceRepository.Add(invoice);
                    
                    foreach (var item in invoiceRequest.InvoiceDetail)
                    {

                        var detail = _mapper.Map<DetailInvoice>(item);
                        detail.IdInvoice = invoice.IdInvoice;
                        await _detailInvoiceRepository.Add(detail);

                    }
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    
                }
            }
            return invoiceResult;
        }

       /* public async Task<InvoiceResponse> AddInvoice(InvoiceRequest invoiceRequest)
        {
            var invoice = _mapper.Map<Invoice>(invoiceRequest);
            await _invoiceRepository.Add(invoice);
            return _mapper.Map<InvoiceResponse>(invoice);

        }
       */
        
        
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
            var invoice = await _invoiceRepository.GetAll().Include(x=>x.DetailInvoices).Include(x=>x.IdCustomerNavigation).ToListAsync();
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
