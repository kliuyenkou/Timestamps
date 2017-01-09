using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Infrastructure;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Identity;
using Timestamps.DAL.Interfaces;
using Timestamps.DAL.Management.Interfaces;

namespace Timestamps.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager<ApplicationUser> _userManager;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userManager = unitOfWork.UserManager;
        }

        public async Task<OperationResult> CreateAsync(User user)
        {
            var appUser = await _userManager.FindByEmailAsync(user.Email);
            if (appUser == null) {
                appUser = new ApplicationUser { Email = user.Email, UserName = user.Email, Name = user.Name };
                var result = await _userManager.CreateAsync(appUser, user.Password);
                await _unitOfWork.SaveChangesAsync();
                return new OperationResult(true, "You have been successfully registered!", "");
            }
            return new OperationResult(false, "User with this email already exist!", "");
        }

        public async Task<ClaimsIdentity> SignInAsync(User user)
        {
            ClaimsIdentity claim = null;
            var appUser = await _userManager.FindAsync(user.Email, user.Password);

            if (appUser != null)
                claim = await _userManager.CreateIdentityAsync(appUser,
                    DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }
    }
}