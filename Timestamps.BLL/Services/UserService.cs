using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Timestamps.BLL.Identity;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using dbApplicationUser = Timestamps.DAL.Entities.ApplicationUser;

namespace Timestamps.BLL.Services
{
    public class UserService : IUserService
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public UserService(ApplicationSignInManager applicationSignInManager, ApplicationUserManager applicationUserManager)
        {
            _signInManager = applicationSignInManager;
            _userManager = applicationUserManager;
        }

        public void DisposeUserManager(bool disposing)
        {
            if (disposing) {
                if (_userManager != null) {
                    _userManager.Dispose();
                    _userManager = null;
                }
            }

        }
        public void DisposeSignInManager(bool disposing)
        {
            if (disposing) {
                if (_signInManager != null) {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

        }

        public Task<SignInStatus> PasswordSignInAsync(string email, string password, bool rememberMe, bool shouldLockout)
        {
            return _signInManager.PasswordSignInAsync(email, password, rememberMe, shouldLockout);
        }

        public Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUser, dbApplicationUser>();
            });

            var mapper = config.CreateMapper();
            var dbuser = mapper.Map<ApplicationUser, dbApplicationUser>(user);

            return _userManager.CreateAsync(dbuser, password);
        }

        public Task SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUser, dbApplicationUser>();
            });

            var mapper = config.CreateMapper();
            var dbuser = mapper.Map<ApplicationUser, dbApplicationUser>(user);
            return _signInManager.SignInAsync(dbuser, isPersistent, rememberBrowser);
        }

        public Task<string> GetVerifiedUserIdAsync()
        {
            return _signInManager.GetVerifiedUserIdAsync();
        }

        public Task<IList<string>> GetValidTwoFactorProvidersAsync(string userId)
        {
            return _userManager.GetValidTwoFactorProvidersAsync(userId);
        }

        public Task<bool> SendTwoFactorCodeAsync(string selectedProvider)
        {
            return _signInManager.SendTwoFactorCodeAsync(selectedProvider);
        }
    }
}
