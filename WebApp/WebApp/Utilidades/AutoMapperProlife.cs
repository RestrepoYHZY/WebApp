using AutoMapper;
using WebApp.Models;
using WebApp.DTO;

namespace WebApp.Utils
{
    public class AutoMapperProlife : Profile
    {
        public AutoMapperProlife()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Provider, ProviderDto>();
        }

    }
}


