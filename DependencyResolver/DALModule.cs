using Autofac;
using Timestamps.DAL;
using Timestamps.DAL.EFDataReceiving;
using Timestamps.DAL.Interfaces;

namespace DependencyResolverHelper
{
    public class DALModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<ProjectNominationRepository>().As<IProjectNominationRepository>().InstancePerRequest();
            builder.RegisterType<HourageRepository>().As<IHourageRepository>().InstancePerRequest();
            builder.RegisterType<ApplicationUserRepository>().As<IApplicationUserRepository>().InstancePerRequest();
        }
    }
}
