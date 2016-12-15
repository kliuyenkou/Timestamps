﻿using System.Threading.Tasks;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IProjectRepository Projects { get; }
        IProjectNominationRepository ProjectNominations { get; }
        IHourageRepository Hourages { get; }
        IUserManager<ApplicationUser> UserManager { get; }
        void SaveChanges();
        Task SaveChangesAsync();
        int SaveChangesWithErrors();
    }
}