using AutoMapper;
using OnlineStoreApp.WebApi.DTOs;
using OnlineStoreApp.WebApi.Models;



namespace OnlineStoreApp.WebApi.Utils
{
    public class AutoMapperProlife : Profile
    {
        public AutoMapperProlife()
        {
            CreateMap<Product, ProductDto>().ForMember(x=> x.providerName, p=> p.MapFrom(src => src.IdProviderNavigation.ProviderName));
            CreateMap<ProductDto, Product>();

            


            CreateMap<Product,ProductRequestDto>();
            CreateMap<ProductRequestDto, Product>();

            CreateMap<Provider, ProviderRequestDto>();
        }

    }
}


