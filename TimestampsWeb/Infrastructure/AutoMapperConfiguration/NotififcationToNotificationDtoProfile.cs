using AutoMapper;
using Timestamps.BLL.DataContracts;
using TimestampsWeb.Dto;

namespace TimestampsWeb.Infrastructure.AutoMapperConfiguration
{
    public class NotififcationToNotificationDtoProfile : Profile
    {
        public NotififcationToNotificationDtoProfile()
        {
            CreateMap<Notification, NotificationDto>();
        }
    }
}