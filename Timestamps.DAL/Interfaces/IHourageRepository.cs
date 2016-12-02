using System.Collections.Generic;
using Timestamps.DAL.DbModels;

namespace Timestamps.DAL.Interfaces
{
    public interface IHourageRepository : IRepository<Hourage>
    {
        IEnumerable<Hourage> GetUserHourageRecordsWithProject(string userId);
    }
    
}
