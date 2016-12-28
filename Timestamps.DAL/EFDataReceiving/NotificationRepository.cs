using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;

namespace Timestamps.DAL.EFDataReceiving
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
