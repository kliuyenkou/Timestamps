using Autofac;
using Timestamps.DAL.EFDataReceiving;
using Timestamps.DAL.Identity;
using Timestamps.DAL.Interfaces;

namespace Timestamps.BLL.Infrastructure
{
    public class AutofacBLLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ProjectRepository>().As<IProjectRepository>().InstancePerRequest();
            builder.RegisterType<ProjectNominationRepository>().As<IProjectNominationRepository>().InstancePerRequest();
            builder.RegisterType<HourageRepository>().As<IHourageRepository>().InstancePerRequest();
            builder.RegisterType<NotificationRepository>().As<INotificationRepository>().InstancePerRequest();
            builder.RegisterType<UserNotificationRepository>().As<IUserNotificationRepository>().InstancePerRequest();
            builder.RegisterType<ProjectManagementRepository>().As<IProjectManagementRepository>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        }
    }
}