using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Models;

namespace Timestamps.BLL.Interfaces
{
    public interface IUserStore : IUserStore<User>, IUserLoginStore<User>, IUserPasswordStore<User>,
        IUserLockoutStore<User, string>, IUserTwoFactorStore<User, string>, IUserEmailStore<User>
    {

    }
}
