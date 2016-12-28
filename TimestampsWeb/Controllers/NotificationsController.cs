using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Interfaces;
using TimestampsWeb.Dto;

namespace TimestampsWeb.Controllers
{
    public class NotificationsController : ApiController
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _notificationService.GetNewNotificationsForUser(userId);
            var notificationsDto = Mapper.Map<IEnumerable<NotificationDto>>(notifications);
            return notificationsDto;
        }
    }
}
