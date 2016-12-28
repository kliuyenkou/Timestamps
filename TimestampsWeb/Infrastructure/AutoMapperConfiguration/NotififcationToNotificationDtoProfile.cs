using AutoMapper;
using Timestamps.BLL.Models;
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