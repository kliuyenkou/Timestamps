using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timestamps.DAL.Interfaces;
using Timestamps.DAL.Management.Interfaces;

namespace Timestamps.DAL.Management
{
    public class AccountManager : IAccountManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
