using AutoMapper;
using Timestamps.DAL.Entities;

namespace Timestamps.BLL.Infrastructure.AutoMapperConfiguration
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, DataContracts.Project>();
        }
    }
}