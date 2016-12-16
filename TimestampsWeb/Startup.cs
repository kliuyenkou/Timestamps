using Microsoft.Owin;
using Owin;
using TimestampsWeb;

[assembly: OwinStartup(typeof(Startup))]

namespace TimestampsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureAutofac(app);
            InitAutoMapper();
        }
    }
}