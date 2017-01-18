using AutoMapper;
using Timestamps.BLL.DataContracts;
using TimestampsWeb.Dto;

namespace TimestampsWeb.Infrastructure.AutoMapperConfiguration
{
    public class ProjectToProjectDto : Profile
    {
        public ProjectToProjectDto()
        {
            CreateMap<Project, ProjectDto>()
                .ForMember(dest => dest.CreatorName, opt => opt.MapFrom(src => src.Creator.UserName))
                .ForMember(dest => dest.CreatorEmail, opt => opt.MapFrom(src => src.Creator.Email));
        }
    }
}