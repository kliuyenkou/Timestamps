using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Timestamps.DAL.DbModels;
using Timestamps.DAL.Interfaces;

namespace Timestamps.DAL.EFDataReceiving
{
    public class HourageRepository : Repository<Hourage>, IHourageRepository
    {
        public HourageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Hourage> GetUserHourageRecordsWithProject(string userId)
        {
            return context.Hourages.Where(h => h.UserId == userId).Include(h => h.Project).Include(h => h.User).ToList();
        }
    }
}