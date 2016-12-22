using AutoMapper.Configuration;

namespace TimestampsWeb.Infrastructure.AutoMapperConfiguration
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure(MapperConfigurationExpression cfg)
        {
            cfg.AddProfile(new ProjectToProjectViewModelProfile());
            cfg.AddProfile(new ProjectToProjectWithCreatorViewModelProfile());
        }
    }
}