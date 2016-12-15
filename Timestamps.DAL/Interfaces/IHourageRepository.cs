using System.Collections.Generic;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.Interfaces
{
    public interface IHourageRepository : IRepository<Hourage>
    {
        IEnumerable<Hourage> GetUserHourageRecordsWithProject(string userId);
        void RemoveById(int hourageId);
    }
}