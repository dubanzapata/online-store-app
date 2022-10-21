using OlineStore.Dto.Request;
using OlineStore.Dto.Response;

namespace OlineStore.Contrats.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponse>> ListCustomer();
        Task<CustomerResponse> GetCustomer(int customerId);
        Task<CustomerResponse> AddCustomer(CustomerRequest customerRequest);
        Task<CustomerResponse> UpdateCustomer(CustomerRequest customerRequest,int id);
        Task<CustomerResponse> DeleteCustomer(int customerId);  
    }
}
