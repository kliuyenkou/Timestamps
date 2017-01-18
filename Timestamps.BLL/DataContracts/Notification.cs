using System;

namespace Timestamps.BLL.DataContracts
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}