using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Timestamps.DAL.DataInterfaces.Repositories;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;

namespace Timestamps.DAL.EFDataReceiving.Repositories
{
    public class UserNotificationRepository : Repository<UserNotification>, IUserNotificationRepository
    {
        public UserNotificationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Notification> GetNewNotificationsForUser(string userId)
        {
            return context.UserNotifications.Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Project.Creator)
                .ToList();
        }
    }
}
