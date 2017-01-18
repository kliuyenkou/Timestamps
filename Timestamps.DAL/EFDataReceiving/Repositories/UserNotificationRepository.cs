using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Timestamps.DAL.DataInterfaces.Repositories;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.EFDataReceiving.Repositories
{
    public class UserNotificationRepository : Repository<UserNotification>, IUserNotificationRepository
    {
        public UserNotificationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public UserNotification GetUserNotification(int notificationId, string userId)
        {
            return Find(un => un.NotificationId == notificationId && un.UserId == userId).Single(un => true);
        }

        public IEnumerable<Notification> GetNewNotificationsForUser(string userId)
        {
            return context.UserNotifications.Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Project.Creator)
                .ToList();
        }

        public IEnumerable<Notification> GetAllUserNotifications(string userId)
        {
            return context.UserNotifications.Where(un => un.UserId == userId)
                .Select(un => un.Notification)
                .Include(n => n.Project.Creator)
                .ToList();
        }
    }
}