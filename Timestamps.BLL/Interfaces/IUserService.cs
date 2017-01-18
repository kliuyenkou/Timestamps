using System.Security.Claims;
using System.Threading.Tasks;
using Timestamps.BLL.DataContracts;
using Timestamps.BLL.Infrastructure;

namespace Timestamps.BLL.Interfaces
{
    public interface IUserService
    {
        Task<OperationResult> CreateAsync(User user);
        Task<ClaimsIdentity> SignInAsync(User user);
    }
}