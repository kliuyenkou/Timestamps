using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;

namespace Timestamps.DAL.EFDataReceiving
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ApplicationUser> FindByNameAsync(string name)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.UserName.ToUpper() == name.ToUpper());
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email.ToUpper() == email.ToUpper());
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public void SetPasswordHash(string userId, string passwordHash)
        {
            var applicationUser = context.Users.FirstOrDefault(u => u.Id == userId); ;
            if (applicationUser != null)
                applicationUser.PasswordHash = passwordHash;
        }

        public void SetEmail(string userId, string email)
        {
            var applicationUser = context.Users.FirstOrDefault(u => u.Id == userId); ;
            if (applicationUser != null)
                applicationUser.Email = email;
        }
    }
}
