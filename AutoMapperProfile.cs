using AutoMapper;
using TaksiDuragi.API.Dtos;
using TaksiDuragi.API.Models;

namespace TaksiDuragi.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserForLoginDto>();
            CreateMap<User, UserForRegisterDto>();
            CreateMap<User, User>();
            CreateMap<Caller, Caller>();
            CreateMap<Caller, CallerInfo>()
                .ForMember(dest => dest.CallerNameSurname, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.NameSurname : string.Empty))
                .ForMember(dest => dest.CallerAddress, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.Address : string.Empty));
        }
    }
}
