using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin.Security.DataProtection;
using Owin;
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
            var config = GlobalConfiguration.Configuration;

            // REGISTER MODULS
            builder.RegisterModule(new AutofacBLLModule());

            // REGISTER DEPENDENCIES
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<ProjectNominationService>().As<IProjectNominationService>().InstancePerRequest();
            builder.RegisterType<ProjectService>().As<IProjectService>().InstancePerRequest();
            builder.RegisterType<HourageService>().As<IHourageService>().InstancePerRequest();
            builder.RegisterType<ReportsService>().As<IReportsService>().InstancePerRequest();


            // REGISTER CONTROLLERS SO DEPENDENCIES ARE CONSTRUCTOR INJECTED
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // BUILD THE CONTAINER
            var container = builder.Build();


            // REPLACE THE MVC AND WEB API DEPENDENCY RESOLVER WITH AUTOFAC
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // REGISTER WITH OWIN
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
            app.UseAutofacWebApi(config);
            //app.UseWebApi(config);
        }
    }
}