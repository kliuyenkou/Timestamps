using System.Collections.Generic;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.DataInterfaces.Repositories
{
    public interface IUserNotificationRepository : IRepository<UserNotification>
    {
        UserNotification GetUserNotification(int notificationId, string userId);
        IEnumerable<Notification> GetNewNotificationsForUser(string userId);
        IEnumerable<Notification> GetAllUserNotifications(string userId);
    }
}
