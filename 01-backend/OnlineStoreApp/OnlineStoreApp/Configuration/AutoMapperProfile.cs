using AutoMapper;
using OlineStore.Dto.Models;
using OlineStore.Dto.Request;
using OlineStore.Dto.Response;

namespace OnlineStoreApp.Configuration
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerRequest>().ReverseMap();
            CreateMap<Customer,CustomerResponse>().ReverseMap();
            CreateMap<CustomerRequest, CustomerResponse>().ReverseMap();

            CreateMap<DetailInvoice, DetailInvoiceRequest>().ReverseMap();
            CreateMap<DetailInvoice, DetailInvoiceResponse>().ReverseMap();
            CreateMap<DetailInvoiceRequest, DetailInvoiceResponse>().ReverseMap();

            CreateMap<Invoice, InvoiceRequest>().ReverseMap();
            CreateMap<Invoice,InvoiceResponse>().ReverseMap();
            CreateMap<InvoiceRequest, InvoiceResponse>().ReverseMap();

            CreateMap<Product, ProductRequest>().ReverseMap();
            CreateMap<Product,ProductResponse>().ReverseMap();
            CreateMap<ProductRequest, ProductResponse>().ReverseMap();

            CreateMap<Provider, ProviderRequest>().ReverseMap();
            CreateMap<Provider,ProviderResponse>().ReverseMap();
            CreateMap<ProductRequest,ProductResponse>().ReverseMap();


        }
    }
}
