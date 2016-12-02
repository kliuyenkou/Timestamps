using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Timestamps.BLL;
using Timestamps.BLL.Interfaces;

namespace Timestamps.DependencyResolver
{
    public class BLLModuleBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IProjectService>().To<ProjectService>();
            Bind<IProjectNominationService>().To<ProjectNominationService>();
            Bind<IHourageService>().To<HourageService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}
