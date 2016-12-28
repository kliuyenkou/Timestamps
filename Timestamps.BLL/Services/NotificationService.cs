using System.Collections.Generic;
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
    }
}
