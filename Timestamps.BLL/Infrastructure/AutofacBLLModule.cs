using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

        }
    }
}
