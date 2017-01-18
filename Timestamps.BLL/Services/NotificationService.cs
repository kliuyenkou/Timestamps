using System.Collections.Generic;
using AutoMapper;
using Timestamps.BLL.DataContracts;
using Timestamps.BLL.Interfaces;
using Timestamps.DAL.Management.Interfaces;

namespace Timestamps.BLL.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationManagement _notificationManagement;

        public NotificationService(INotificationManagement notificationManagement)
        {
            _notificationManagement = notificationManagement;
        }

        public IEnumerable<Notification> GetNewNotificationsForUser(string userId)
        {
            var notificationsEntity = _notificationManagement.GetUnreadUserNotifications(userId);
            var notifications =
                Mapper.Map<IEnumerable<DAL.Entities.Notification>, IEnumerable<Notification>>(notificationsEntity);
            return notifications;
        }

        public void MarkAllNewNotificationsAsReadByUser(string userId)
        {
            var notifications = _notificationManagement.GetUnreadUserNotifications(userId);
            _notificationManagement.MarkUserNotifications(notifications, userId, true);
        }

        public IEnumerable<Notification> GetAllNotificationsForUser(string userId)
        {
            var notificationsEntity = _notificationManagement.GetAllUserNotifications(userId);
            var notifications =
                Mapper.Map<IEnumerable<DAL.Entities.Notification>, IEnumerable<Notification>>(notificationsEntity);
            return notifications;
        }
    }
}