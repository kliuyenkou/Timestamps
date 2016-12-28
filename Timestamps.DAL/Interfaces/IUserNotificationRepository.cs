using System.Collections.Generic;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.Interfaces
{
    public interface IUserNotificationRepository : IRepository<UserNotification>
    {
        IEnumerable<Notification> GetNewNotificationsForUser(string userId);
    }
}
