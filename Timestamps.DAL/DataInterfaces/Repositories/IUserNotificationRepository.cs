using System.Collections.Generic;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.DataInterfaces.Repositories
{
    public interface IUserNotificationRepository : IRepository<UserNotification>
    {
        IEnumerable<Notification> GetNewNotificationsForUser(string userId);
    }
}
