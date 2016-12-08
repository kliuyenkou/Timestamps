using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Timestamps.BLL.Infrastructure;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Services;

namespace TimestampsWeb
{
    public partial class Startup
    {
        public void ConfigureAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // REGISTER MODULS
            builder.RegisterModule(new AutofacBLLModule());

            // REGISTER DEPENDENCIES
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<ProjectNominationService>().As<IProjectNominationService>().InstancePerRequest();
            builder.RegisterType<ProjectService>().As<IProjectService>().InstancePerRequest();
            builder.RegisterType<HourageService>().As<IHourageService>().InstancePerRequest();


            // REGISTER CONTROLLERS SO DEPENDENCIES ARE CONSTRUCTOR INJECTED
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // BUILD THE CONTAINER
            var container = builder.Build();

            // REPLACE THE MVC DEPENDENCY RESOLVER WITH AUTOFAC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // REGISTER WITH OWIN
            app.UseAutofacMiddleware(container);
            //app.UseAutofacMvc();
        }
    }
}