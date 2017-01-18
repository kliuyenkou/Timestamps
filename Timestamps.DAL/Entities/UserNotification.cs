using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timestamps.DAL.Entities
{
    public class UserNotification
    {
        public UserNotification(Notification notification, ApplicationUser user)
        {
            Notification = notification;
            User = user;
        }

        public UserNotification()
        {
        }

        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; set; }

        public ApplicationUser User { get; set; }

        public Notification Notification { get; set; }

        public bool IsRead { get; set; }
    }
}