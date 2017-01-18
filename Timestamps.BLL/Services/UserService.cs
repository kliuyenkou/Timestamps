using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.DataContracts;
using Timestamps.BLL.Infrastructure;
using Timestamps.BLL.Interfaces;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Management.Interfaces;

namespace Timestamps.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountManagement _accountManagement;

        public UserService(IAccountManagement accountManagement)
        {
            _accountManagement = accountManagement;
        }

        public async Task<OperationResult> CreateAsync(User user)
        {
            var appUser = await _accountManagement.GetUserByEmailAsync(user.Email);
            if (appUser == null)
            {
                appUser = new ApplicationUser {Email = user.Email, UserName = user.Email, Name = user.Name};
                await _accountManagement.CreateUser(appUser, user.Password);
                return new OperationResult(true, "You have been successfully registered!", "");
            }
            return new OperationResult(false, "User with this email already exist!", "");
        }

        public async Task<ClaimsIdentity> SignInAsync(User user)
        {
            ClaimsIdentity claim = null;
            var appUser = await _accountManagement.FindUserAsync(user.Email, user.Password);

            if (appUser != null)
                claim = await _accountManagement.CreateIdentityAsync(appUser,
                    DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }
    }
}