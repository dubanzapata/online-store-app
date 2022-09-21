using AutoMapper;
using OnlineStoreApp.WebApi.Models;
using OnlineStoreApp.WebApi.DTO;

namespace OnlineStoreApp.WebApi.Utils
{
    public class AutoMapperProlife : Profile
    {
        public AutoMapperProlife()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(x=>x.provider_name,p=>p.MapFrom(src=>src.IdProviderNavigation.ProviderName))
                .ReverseMap();
            CreateMap<Provider, ProviderDto>();
        }

    }
}


