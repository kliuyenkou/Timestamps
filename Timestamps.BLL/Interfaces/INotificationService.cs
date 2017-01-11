using System.Collections.Generic;
using Timestamps.BLL.Models;

namespace Timestamps.BLL.Interfaces
{
    public interface INotificationService
    {
        IEnumerable<Notification> GetNewNotificationsForUser(string userId);
        void MarkAllNewNotificationsAsReadByUser(string userId);
    }
}
