using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimestampsWeb.Startup))]
namespace TimestampsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
