using AutoMapper;
using Timestamps.BLL.DataContracts;
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