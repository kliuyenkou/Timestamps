using System;

namespace Timestamps.BLL.DataContracts
{
    public class UserNotification
    {
        public UserNotification(User user, Notification notification)
        {
            if (user == null) throw new ArgumentNullException("user");
            if (user == null) throw new ArgumentNullException("notification");

            User = user;
            Notification = notification;
        }

        public User User { get; set; }

        public Notification Notification { get; set; }

        public bool IsRead { get; set; }
    }
}