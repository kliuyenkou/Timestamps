using AutoMapper;
using Timestamps.BLL.DataContracts;
using Timestamps.DAL.Entities;

namespace Timestamps.BLL.Infrastructure.AutoMapperConfiguration
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, User>();
        }
    }
}