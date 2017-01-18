using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Interfaces;
using TimestampsWeb.Dto;

namespace TimestampsWeb.Controllers.Notification
{
    [RoutePrefix("api/notifications")]
    public class NotificationsController : ApiController
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        [Route("new")]
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _notificationService.GetNewNotificationsForUser(userId);
            var notificationsDto = Mapper.Map<IEnumerable<NotificationDto>>(notifications);
            return notificationsDto;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<NotificationDto> GetAllNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _notificationService.GetAllNotificationsForUser(userId);
            var notificationsDto = Mapper.Map<IEnumerable<NotificationDto>>(notifications);
            return notificationsDto;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult MarkNotificationAsRead(IEnumerable<NotificationDto> notificationsDto)
        {
            var userId = User.Identity.GetUserId();
            _notificationService.MarkAllNewNotificationsAsReadByUser(userId);

            return Ok();
        }
    }
}