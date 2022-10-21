using OlineStore.Dto.Request;
using OlineStore.Dto.Response;

namespace OlineStore.Contrats.Interfaces.Services
{
    public interface IProviderService
    {
        Task<IEnumerable<ProviderResponse>> ListProvider();
        Task<ProviderResponse> GetProvider(int ProviderId);
        Task<ProviderResponse> AddProvider(ProviderRequest providerRequest);
        Task<ProviderResponse> UpdateProvider(ProviderRequest providerRequest, int ProviderId);
        Task<ProviderResponse> DeleteProvider(int ProviderId);
    }
}
