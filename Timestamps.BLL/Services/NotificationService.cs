using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using Timestamps.DAL.Interfaces;

namespace Timestamps.BLL.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IProjectNominationRepository _projectNominationRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IUserNotificationRepository _userNotificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _projectRepository = unitOfWork.Projects;
            _projectNominationRepository = unitOfWork.ProjectNominations;
            _notificationRepository = unitOfWork.Notifications;
            _userNotificationRepository = unitOfWork.UserNotifications;

        }

        public IEnumerable<Notification> GetNewNotificationsForUser(string userId)
        {
            var notificationsEntity = _userNotificationRepository.GetNewNotificationsForUser(userId);
            var notifications = Mapper.Map<IEnumerable<DAL.Entities.Notification>, IEnumerable<Notification>>(notificationsEntity);
            return notifications;
        }

        public void MarkNotificationAsReadByUser(Notification notification, string userId)
        {
            var userNotificationEntity = _userNotificationRepository.Find(un => un.NotificationId == notification.Id && un.UserId == userId).Single(un => true);
            userNotificationEntity.IsRead = true;
            _unitOfWork.SaveChanges();
        }

        public void MarkAllNewNotificationsAsReadByUser(string userId)
        {
            var userNotifications = _userNotificationRepository.Find(un => un.UserId == userId && !un.IsRead);
            foreach (var notification in userNotifications) {
                notification.IsRead = true;
            }
            _unitOfWork.SaveChanges();
        }
    }
}
