using System;
using System.ComponentModel.DataAnnotations;

namespace Timestamps.DAL.Entities
{
    public class Notification
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public NotificationType Type { get; set; }

        [Required]
        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
