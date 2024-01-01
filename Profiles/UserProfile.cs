using AutoMapper;

namespace LaundroMat.Profiles
{
    public class UserProfile : Profile
    {
       public UserProfile() { 
        
            CreateMap<Models.UserForCreationDTO, Entities.User>()
                .ForMember(dest => dest.RegistrationDate, opt => 
                opt.MapFrom(src => src.RegistrationDate.Date.ToString()));
        
       }
    }
}
