using Owin;
using Timestamps.BLL.Identity;
using Timestamps.DAL;

namespace Timestamps.BLL.Services
{
    public static class ConfigureAppBuilder
    {
        public static void ConfigureOwinContext(IAppBuilder app)
        {
            //app.CreatePerOwinContext(ApplicationDbContext.Create);
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            //app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
        }
    }
}
