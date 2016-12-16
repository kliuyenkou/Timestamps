using AutoMapper;

namespace Timestamps.BLL.Infrastructure.AutoMapperConfiguration
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<DAL.Entities.Project, Models.Project>();
        }
    }
}