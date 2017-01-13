using AutoMapper;
using Timestamps.BLL.Models;
using TimestampsWeb.Dto;

namespace TimestampsWeb.Infrastructure.AutoMapperConfiguration
{
    public class HourageToHourageDto : Profile
    {
        public HourageToHourageDto()
        {
            CreateMap<Hourage, HourageDto>();
        }
    }
}