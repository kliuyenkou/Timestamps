using AutoMapper;
using Timestamps.BLL.DataContracts;
using TimestampsWeb.ViewModels;

namespace TimestampsWeb.Infrastructure.AutoMapperConfiguration
{
    public class ProjectToProjectViewModelProfile : Profile
    {
        public ProjectToProjectViewModelProfile()
        {
            CreateMap<Project, ProjectViewModel>();
        }
    }
}