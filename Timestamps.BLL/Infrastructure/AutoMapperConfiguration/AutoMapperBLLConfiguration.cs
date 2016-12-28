using AutoMapper.Configuration;

namespace Timestamps.BLL.Infrastructure.AutoMapperConfiguration
{
    public static class AutoMapperBLLConfiguration
    {
        public static void Configure(MapperConfigurationExpression cfg)
        {
            cfg.AddProfile(new UserProfile());
            cfg.AddProfile(new ProjectProfile());
            cfg.AddProfile(new HourageProfile());
            cfg.AddProfile(new NotificationProfile());
            cfg.AddProfile(new UserNotificationProfile());
        }
    }
}