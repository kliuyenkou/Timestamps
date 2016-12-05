using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Omu.ValueInjecter;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;

namespace Timestamps.BLL.Identity
{
    public class UserStore : IUserStore
    {
        private IUnitOfWork _unitOfWork;
        private IApplicationUserRepository _userRepository;
        private bool _disposed;

        public UserStore(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.ApplicationUsers;
        }
        public Task CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
        }

        public async Task<User> FindByIdAsync(string userId)
        {
            ApplicationUser applicationUser = await _userRepository.GetByIdAsync(userId);
            User user = new User();
            if (applicationUser != null) {
                user.InjectFrom(applicationUser);
            }
            return user;
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");

            ApplicationUser applicationUser = await _userRepository.FindByNameAsync(userName);
            User user = new User();
            if (applicationUser != null) {
                user.InjectFrom(applicationUser);
            }

            return user;
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task SetPasswordHashAsync(User user, string passwordHash)
        {
            _userRepository.SetPasswordHash(user.Id, passwordHash);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            var applicationUser = _userRepository.GetByIdAsync(user.Id);
            return Task.FromResult(applicationUser.Result.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task AddLoginAsync(User user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(User user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            var applicationUser = _userRepository.GetByIdAsync(user.Id);
            return Task.FromResult(applicationUser.Result.LockoutEndDateUtc.HasValue ? new DateTimeOffset(DateTime.SpecifyKind(applicationUser.Result.LockoutEndDateUtc.Value, DateTimeKind.Utc)) : new DateTimeOffset());
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            var applicationUser = _userRepository.GetByIdAsync(user.Id);
            return Task.FromResult(applicationUser.Result.AccessFailedCount);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            var applicationUser = _userRepository.GetByIdAsync(user.Id);
            return Task.FromResult(applicationUser.Result.LockoutEnabled);
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            var applicationUser = _userRepository.GetByIdAsync(user.Id);
            return Task.FromResult(applicationUser.Result.TwoFactorEnabled);
        }

        public async Task SetEmailAsync(User user, string email)
        {
            _userRepository.SetEmail(user.Id, email);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task<string> GetEmailAsync(User user)
        {
            var applicationUser = _userRepository.GetByIdAsync(user.Id);
            return Task.FromResult(applicationUser.Result.Email);

        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            var applicationUser = _userRepository.GetByIdAsync(user.Id);
            return Task.FromResult(applicationUser.Result.EmailConfirmed);

        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
