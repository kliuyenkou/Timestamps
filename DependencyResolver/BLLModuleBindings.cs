//using Microsoft.AspNet.Identity;
//using Ninject.Modules;
//using Timestamps.BLL.Identity;
//using Timestamps.BLL.Interfaces;
//using Timestamps.BLL.Models;
//using Timestamps.BLL.Services;

//namespace DependencyResolverHelper
//{
//    public class BLLModuleBindings : NinjectModule
//    {
//        public override void Load()
//        {
//            Bind<IProjectService>().To<ProjectService>();
//            Bind<IProjectNominationService>().To<ProjectNominationService>();
//            Bind<IHourageService>().To<HourageService>();
//            Bind<IUserStore<User>>().To<UserStore>();
//            //Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>();
//            // Bind<IUserService>().To<UserService>();
//            //Bind<IAuthenticationManager>.To<AuthenticationManager>();
//        }
//    }
//}
