using System.Security.Claims;
using System.Threading.Tasks;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.Management.Interfaces
{
    public interface IAccountManagement
    {
        Task CreateUser(ApplicationUser user, string userPassword);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<ApplicationUser> FindUserAsync(string userEmail, string userPassword);
        Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser appUser, string applicationCookie);
    }
}