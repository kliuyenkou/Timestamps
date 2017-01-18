using AutoMapper;
using Timestamps.DAL.Entities;

namespace Timestamps.BLL.Infrastructure.AutoMapperConfiguration
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, DataContracts.Notification>();
        }
    }
}