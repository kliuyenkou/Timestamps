using AutoMapper;

namespace Timestamps.BLL.Infrastructure.AutoMapperConfiguration
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<DAL.Entities.Notification, Models.Notification>();
        }
    }
}
