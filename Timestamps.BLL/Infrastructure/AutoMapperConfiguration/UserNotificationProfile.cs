using AutoMapper;

namespace Timestamps.BLL.Infrastructure.AutoMapperConfiguration
{
    public class UserNotificationProfile : Profile
    {
        public UserNotificationProfile()
        {
            CreateMap<DAL.Entities.UserNotification, Models.UserNotification>();
        }
    }
}
