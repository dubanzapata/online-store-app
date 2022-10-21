using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OlineStore.Contrats.Interfaces.Repositories;
using OlineStore.Contrats.Interfaces.Services;
using OlineStore.Dto.Models;
using OlineStore.Dto.Request;
using OlineStore.Dto.Response;

namespace OlineStore.Core.Service
{
    public class DetailInvoiceService : IDetailInvoiceService
    {

        private readonly IDetailInvoiceRepository _detailInvoiceRepository;
        private readonly IMapper _mapper;

        public DetailInvoiceService(IDetailInvoiceRepository detailInvoiceRepository, IMapper mapper)
        {
            _detailInvoiceRepository = detailInvoiceRepository;
            _mapper = mapper;
        }

        public async Task<DetailInvoiceResponse> AddDetail(DetailInvoiceRequest detailInvoiceRequest)
        {
            var customer = _mapper.Map<DetailInvoice>(detailInvoiceRequest);
            await _detailInvoiceRepository.Add(customer);
            return _mapper.Map<DetailInvoiceResponse>(customer);
        }

        public async Task<DetailInvoiceResponse> DeleteDetail(int detailId)
        {
            var detail = await _detailInvoiceRepository.FindBy(x => x.IdDetail == detailId).FirstOrDefaultAsync();
            await _detailInvoiceRepository.Delete(detail!);
            return _mapper.Map<DetailInvoiceResponse>(detail);
        }

        public async Task<DetailInvoiceResponse> GetDetail(int detailId)
        {
            var detail = await _detailInvoiceRepository.FindBy(x => x.IdDetail == detailId).FirstOrDefaultAsync();
            return _mapper.Map<DetailInvoiceResponse>(detail);
        }

        public async Task<IEnumerable<DetailInvoiceResponse>> ListDetail()
        {
            var detail = await _detailInvoiceRepository.GetAll().ToListAsync();
            return _mapper.Map<IEnumerable<DetailInvoiceResponse>>(detail);
        }
    

        public async Task<DetailInvoiceResponse> UpdateDetail(DetailInvoiceRequest detailInvoiceRequest, int detailId)
        {
            var detail = await _detailInvoiceRepository.FindBy(x => x.IdDetail == detailId).FirstOrDefaultAsync();
            _mapper.Map(detailInvoiceRequest, detail);
            await _detailInvoiceRepository.Update(detail!);
            return _mapper.Map<DetailInvoiceResponse>(detail);
        }
    }
}
