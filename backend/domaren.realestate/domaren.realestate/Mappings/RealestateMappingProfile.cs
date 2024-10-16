using AutoMapper;
using domaren.realstate.Domain.Models;
using domaren.realstate.Domain.Repositories.Models;

namespace domaren.realestate.API.Mappings
{
    public class RealestateMappingProfile : Profile
    {
        public RealestateMappingProfile() 
        {
            CreateMap<User, UserRecord>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.LastName))
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(x => x.Password))
            .ForMember(dest => dest.EMail, opt => opt.MapFrom(x => x.EMail))
            .ForMember(dest => dest.Login, opt => opt.MapFrom(x => x.Login))
            .ReverseMap();
        }
    }
}
