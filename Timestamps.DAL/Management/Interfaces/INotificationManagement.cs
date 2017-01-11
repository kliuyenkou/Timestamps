using System;
using System.Collections.Generic;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.Management.Interfaces
{
    public interface INotificationManagement
    {
        Notification CreateNotification(DateTime dateTime, NotificationType type, int projectId);
        void NotifyUsers(Notification notification, IEnumerable<ApplicationUser> users);
        void NotifyUser(Notification notification, ApplicationUser user);
        void MarkUserNotification(Notification notification, string userId, bool isRead);
        void MarkUserNotifications(IEnumerable<Notification> notifications, string userId, bool isRead);
        IEnumerable<Notification> GetAllUserNotifications(string userId);
        IEnumerable<Notification> GetUnreadUserNotifications(string userId);

    }
}
