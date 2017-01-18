using Timestamps.DAL.DataInterfaces.Repositories;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.EFDataReceiving.Repositories
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}