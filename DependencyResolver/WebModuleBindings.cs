using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Activation;
using Ninject.Modules;
using Timestamps.BLL.Identity;
using Timestamps.DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.DataProtection;
using Ninject;
using Timestamps.BLL.Interfaces;

namespace DependencyResolver
{
    public class WebModuleBindings : NinjectModule
    {
        public override void Load()
        {

            Bind<ApplicationUserManager>().ToMethod<ApplicationUserManager>(context => ApplicationUserManager.Create(Kernel.Get<IUserStore>(), Kernel.Get<IDataProtectionProvider>()));
            //Bind<ApplicationUserManager>().ToSelf();
        }
    }


}
