using System.Collections.Generic;
using Timestamps.BLL.DataContracts;

namespace Timestamps.BLL.Interfaces
{
    public interface INotificationService
    {
        IEnumerable<Notification> GetNewNotificationsForUser(string userId);
        IEnumerable<Notification> GetAllNotificationsForUser(string userId);
        void MarkAllNewNotificationsAsReadByUser(string userId);
    }
}