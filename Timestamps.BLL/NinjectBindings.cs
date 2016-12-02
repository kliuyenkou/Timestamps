using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Timestamps.DAL.EFDataReceiving;
using Timestamps.DAL.Interfaces;

namespace Timestamps.BLL
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            if (Kernel != null)
            {
                Kernel.Bind<IProjectNominationRepository>().To<ProjectNominationRepository>();
                Kernel.Bind<IProjectRepository>().To<ProjectRepository>();
                Kernel.Bind<IHourageRepository>().To<HourageRepository>();
            }
        }
    }
}
