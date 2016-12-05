using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Timestamps.BLL.Models;


namespace Timestamps.BLL.Identity
{
    public class ApplicationSignInManager : SignInManager<User, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return CreateUserIdentityAsync((ApplicationUserManager)UserManager, user);
        }

        public static async Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUserManager manager, User user)
        {
            var userIdentity = await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
        //public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        //{
        //    return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        //}
    }
}