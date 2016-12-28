using System.Data.Entity.Validation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Identity;
using Timestamps.DAL.Interfaces;

namespace Timestamps.DAL.EFDataReceiving
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Projects = new ProjectRepository(_context);
            ProjectNominations = new ProjectNominationRepository(_context);
            Hourages = new HourageRepository(_context);
            Notifications = new NotificationRepository(_context);
            UserNotifications = new UserNotificationRepository(_context);
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_context));
        }

        public IProjectRepository Projects { get; }
        public IProjectNominationRepository ProjectNominations { get; }
        public IHourageRepository Hourages { get; }
        public INotificationRepository Notifications { get; }
        public IUserNotificationRepository UserNotifications { get; }
        public IUserManager<ApplicationUser> UserManager { get; }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// Wrapper for SaveChanges adding the Validation Messages to the generated exception
        public int SaveChangesWithErrors()
        {
            try {
                return _context.SaveChanges();
            }
            catch (DbEntityValidationException ex) {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors) {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors) {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb, ex
                );
            }
        }
    }
}