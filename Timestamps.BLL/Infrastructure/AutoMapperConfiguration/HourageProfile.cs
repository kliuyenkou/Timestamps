using AutoMapper;

namespace Timestamps.BLL.Infrastructure.AutoMapperConfiguration
{
    public class HourageProfile : Profile
    {
        public HourageProfile()
        {
            CreateMap<DAL.Entities.Hourage, Models.Hourage>();
        }
    }
}
