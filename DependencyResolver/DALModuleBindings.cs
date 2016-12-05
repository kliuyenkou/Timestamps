using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Timestamps.DAL.EFDataReceiving;
using Timestamps.DAL.Interfaces;


namespace Timestamps.DependencyResolver
{
    public class DALModuleBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IProjectNominationRepository>().To<ProjectNominationRepository>();
            Bind<IProjectRepository>().To<ProjectRepository>();
            Bind<IHourageRepository>().To<HourageRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}

