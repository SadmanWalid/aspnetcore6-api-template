using AutoMapper;
using PROJECT.DTO.Security;
using PROJECT.Model.Security;

namespace PROJECT.API.AutoMapper
{
    public class ModelDTOMapper: Profile
    {
        public ModelDTOMapper()
        {

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

        }
    }
}
