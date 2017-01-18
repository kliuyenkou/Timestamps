using AutoMapper;
using Timestamps.DAL.Entities;

namespace Timestamps.BLL.Infrastructure.AutoMapperConfiguration
{
    public class HourageProfile : Profile
    {
        public HourageProfile()
        {
            CreateMap<Hourage, DataContracts.Hourage>();
        }
    }
}