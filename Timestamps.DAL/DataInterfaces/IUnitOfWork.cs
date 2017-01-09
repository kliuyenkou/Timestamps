using System.Threading.Tasks;
using Timestamps.DAL.DataInterfaces.Repositories;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Identity;
using Timestamps.DAL.Management.Interfaces;

namespace Timestamps.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IProjectRepository Projects { get; }
        IProjectNominationRepository ProjectNominations { get; }
        IHourageRepository Hourages { get; }
        INotificationRepository Notifications { get; }
        IUserNotificationRepository UserNotifications { get; }
        IUserManager<ApplicationUser> UserManager { get; }
        void SaveChanges();
        Task SaveChangesAsync();
        int SaveChangesWithErrors();
    }
}