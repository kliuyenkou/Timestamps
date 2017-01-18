using AutoMapper;
using Timestamps.BLL.DataContracts;
using TimestampsWeb.ViewModels;

namespace TimestampsWeb.Infrastructure.AutoMapperConfiguration
{
    public class ProjectToProjectWithCreatorViewModelProfile : Profile
    {
        public ProjectToProjectWithCreatorViewModelProfile()
        {
            CreateMap<Project, ProjectWithCreatorViewModel>()
                .ForMember(dest => dest.CreatorName, opt => opt.MapFrom(src => src.Creator.UserName));
        }
    }
}