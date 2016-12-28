using System;
using Timestamps.BLL.Models;
using TimestampsWeb.Controllers;

namespace TimestampsWeb.Dto
{
    public class NotificationDto
    {
        public DateTime DateTime { get; set; }
        public int ProjectId { get; set; }
        public NotificationType Type { get; set; }

        public ProjectDto Project { get; set; }

    }
}