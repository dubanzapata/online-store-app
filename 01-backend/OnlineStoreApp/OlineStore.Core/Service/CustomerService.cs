using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OlineStore.Contrats.Interfaces.Repositories;
using OlineStore.Contrats.Interfaces.Services;
using OlineStore.Dto.Models;
using OlineStore.Dto.Request;
using OlineStore.Dto.Response;

namespace OlineStore.Core.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerResitory;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerResitory, IMapper mapper)
        {
            _customerResitory = customerResitory;
            _mapper = mapper;
        }
    
        public async Task<CustomerResponse> AddCustomer(CustomerRequest customerRequest)
        {
            var customer = _mapper.Map<Customer>(customerRequest);
            await _customerResitory.Add(customer);
            return _mapper.Map<CustomerResponse>(customer);
            
        }

        public async Task<CustomerResponse> DeleteCustomer(int customerId)
        {
                var customer = await _customerResitory.FindBy(x => x.IdCustomer == customerId).FirstOrDefaultAsync();
                await _customerResitory.Delete(customer!);
                return _mapper.Map<CustomerResponse>(customer);
        }

        public async Task<CustomerResponse> GetCustomer(int customerId)
        {
            var customer = await _customerResitory.FindBy(x => x.IdCustomer == customerId).FirstOrDefaultAsync();
            return _mapper.Map<CustomerResponse>(customer); 
        }

        public async Task<IEnumerable<CustomerResponse>> ListCustomer()
        {
            var customer = await _customerResitory.GetAll().ToListAsync();
            return _mapper.Map<IEnumerable<CustomerResponse>>(customer);
        }

        public async Task<CustomerResponse> UpdateCustomer(CustomerRequest customerRequest,int id)
        {
            var customer = await _customerResitory.FindBy(x => x.IdCustomer == id).FirstOrDefaultAsync();
            _mapper.Map(customerRequest,customer);
            await _customerResitory.Update(customer!);   
            return _mapper.Map<CustomerResponse>(customer); 
            
        }
    }
}
