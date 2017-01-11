using System.Security.Claims;
using System.Threading.Tasks;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;
using Timestamps.DAL.Management.Interfaces;

namespace Timestamps.DAL.Management
{
    public class AccountManagement : IAccountManagement
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountManagement(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateUser(ApplicationUser user, string userPassword)
        {
            var result = await _unitOfWork.UserManager.CreateAsync(user, userPassword);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return _unitOfWork.UserManager.FindByEmailAsync(email);
        }

        public Task<ApplicationUser> FindUserAsync(string userEmail, string userPassword)
        {
            return _unitOfWork.UserManager.FindAsync(userEmail, userPassword);
        }

        public Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser appUser, string applicationCookie)
        {
            return _unitOfWork.UserManager.CreateIdentityAsync(appUser, applicationCookie);
        }

    }
}
