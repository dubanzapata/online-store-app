using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OlineStore.Contrats.Interfaces.Repositories;
using OlineStore.Contrats.Interfaces.Services;
using OlineStore.Dto.Models;
using OlineStore.Dto.Request;
using OlineStore.Dto.Response;

namespace OlineStore.Core.Service
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;

        public ProviderService(IProviderRepository providerRepository, IMapper mapper)
        {
            _providerRepository = providerRepository;
            _mapper = mapper;
        }

        public async Task<ProviderResponse> AddProvider(ProviderRequest providerRequest)
        {
            var provider = _mapper.Map<Provider>(providerRequest);
            await _providerRepository.Add(provider);
            return _mapper.Map<ProviderResponse>(provider);

        }

        public async Task<ProviderResponse> DeleteProvider(int ProviderId)
        {
            var provider = await _providerRepository.FindBy(x => x.IdProvider == ProviderId).FirstOrDefaultAsync();
            await _providerRepository.Delete(provider!);
            return _mapper.Map<ProviderResponse>(provider);

        }

        public async Task<ProviderResponse> GetProvider(int ProviderId)
        {
            var provider = await _providerRepository.FindBy(x => x.IdProvider == ProviderId).FirstOrDefaultAsync();
            return _mapper.Map<ProviderResponse>(provider);
        }

        public async Task<IEnumerable<ProviderResponse>> ListProvider()
        {
            var provider = await _providerRepository.GetAll().ToListAsync();
            return _mapper.Map<IEnumerable<ProviderResponse>>(provider);

        }

        public async Task<ProviderResponse> UpdateProvider(ProviderRequest providerRequest, int ProviderId)
        {
            var provider = await _providerRepository.FindBy(x => x.IdProvider == ProviderId).FirstOrDefaultAsync();
            _mapper.Map(providerRequest, provider);
            await _providerRepository.Update(provider!);
            return _mapper.Map<ProviderResponse>(provider);
        }
    }
}
