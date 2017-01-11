using System;
using System.Collections.Generic;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;
using Timestamps.DAL.Management.Interfaces;

namespace Timestamps.DAL.Management
{
    public class NotificationManagement : INotificationManagement
    {
        private readonly IUnitOfWork _unitOfWork;
        public NotificationManagement(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Notification CreateNotification(DateTime dateTime, NotificationType type, int projectId)
        {
            var notification = new Notification()
            {
                DateTime = dateTime,
                Type = type,
                ProjectId = projectId
            };
            _unitOfWork.Notifications.Add(notification);
            _unitOfWork.SaveChanges();
            return notification;
        }

        public void NotifyUsers(Notification notification, IEnumerable<ApplicationUser> users)
        {
            foreach (var applicationUser in users) {
                var userNotificationEntity = new UserNotification(notification, applicationUser);
                _unitOfWork.UserNotifications.Add(userNotificationEntity);
            }
            _unitOfWork.SaveChanges();
        }

        public void NotifyUser(Notification notification, ApplicationUser user)
        {
            var userNotificationEntity = new UserNotification(notification, user);
            _unitOfWork.UserNotifications.Add(userNotificationEntity);
            _unitOfWork.SaveChanges();
        }

        public void MarkUserNotification(Notification notification, string userId, bool isRead)
        {
            var userNotification =
                    _unitOfWork.UserNotifications.GetUserNotification(notification.Id, userId);
            userNotification.IsRead = isRead;

            _unitOfWork.SaveChanges();
        }

        public IEnumerable<Notification> GetAllUserNotifications(string userId)
        {
            return _unitOfWork.UserNotifications.GetAllUserNotifications(userId);
        }

        public IEnumerable<Notification> GetUnreadUserNotifications(string userId)
        {
            return _unitOfWork.UserNotifications.GetNewNotificationsForUser(userId);
        }

        public void MarkUserNotifications(IEnumerable<Notification> notifications, string userId, bool isRead)
        {
            foreach (var notification in notifications) {
                var userNotification =
                    _unitOfWork.UserNotifications.GetUserNotification(notification.Id, userId);
                userNotification.IsRead = isRead;
            }
            _unitOfWork.SaveChanges();
        }
    }
}
