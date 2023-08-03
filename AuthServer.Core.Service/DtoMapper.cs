using AuthServer.Core.Core.Dtos;
using AuthServer.Core.Core.Model;
using AutoMapper;

namespace AuthServer.Core.Service
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<UserAppDto, UserApp>().ReverseMap();
        }
    }
}