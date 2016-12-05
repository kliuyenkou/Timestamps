using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject.Modules;
using Timestamps.BLL;
using Timestamps.BLL.Identity;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using Timestamps.BLL.Services;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;



namespace Timestamps.DependencyResolver
{
    public class BLLModuleBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IProjectService>().To<ProjectService>();
            Bind<IProjectNominationService>().To<ProjectNominationService>();
            Bind<IHourageService>().To<HourageService>();
            Bind<IUserStore<User>>().To<UserStore>();
            //Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>();
            // Bind<IUserService>().To<UserService>();
            //Bind<IAuthenticationManager>.To<AuthenticationManager>();
        }
    }
}
