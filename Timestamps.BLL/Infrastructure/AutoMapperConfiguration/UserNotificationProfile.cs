using AutoMapper;
using Timestamps.DAL.Entities;

namespace Timestamps.BLL.Infrastructure.AutoMapperConfiguration
{
    public class UserNotificationProfile : Profile
    {
        public UserNotificationProfile()
        {
            CreateMap<UserNotification, DataContracts.UserNotification>();
        }
    }
}