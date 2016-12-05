using Autofac;
using Microsoft.Owin.Security.DataProtection;
using Timestamps.BLL.Identity;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Services;

namespace DependencyResolverHelper
{
    public class BLLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProjectNominationService>().As<IProjectNominationService>().InstancePerRequest();
            builder.RegisterType<ProjectService>().As<IProjectService>().InstancePerRequest();
            builder.RegisterType<HourageService>().As<IHourageService>().InstancePerRequest();
            builder.RegisterType<UserStore>().As<IUserStore>().InstancePerRequest();
            builder.Register(c => ApplicationUserManager.Create(c.Resolve<IUserStore>(), c.Resolve<IDataProtectionProvider>())).AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
        }
    }
}
