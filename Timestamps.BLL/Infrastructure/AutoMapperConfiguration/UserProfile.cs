using AutoMapper;

namespace Timestamps.BLL.Infrastructure.AutoMapperConfiguration
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<DAL.Entities.ApplicationUser, Models.User>();
        }
    }
}