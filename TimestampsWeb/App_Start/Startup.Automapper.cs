using AutoMapper;
using AutoMapper.Configuration;
using Timestamps.BLL.Infrastructure.AutoMapperConfiguration;

namespace TimestampsWeb
{
    public partial class Startup
    {
        public static void InitAutoMapper()
        {
            var cfg = new MapperConfigurationExpression();
            AutoMapperBLLConfiguration.Configure(cfg);
            Mapper.Initialize(cfg);
        }
    }
}