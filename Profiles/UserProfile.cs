using AutoMapper;

namespace LaundroMat.Profiles
{
    public class UserProfile : Profile
    {
       public UserProfile() {

            CreateMap<Models.UserForCreationDTO, Entities.User>(); // source to destination
            CreateMap<Entities.User, Models.UserDto>();
       }
    }
}
