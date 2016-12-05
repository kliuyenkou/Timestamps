using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.Interfaces
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        Task<ApplicationUser> FindByNameAsync(string name);
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<ApplicationUser> GetByIdAsync(string id);
        void SetPasswordHash(string userId, string passwordHash);

        void SetEmail(string userId, string email);
    }
}
