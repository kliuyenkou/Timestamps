using System.Collections.Generic;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.DataInterfaces.Repositories
{
    public interface IHourageRepository : IRepository<Hourage>
    {
        IEnumerable<Hourage> GetUserHourageRecordsWithProject(string userId);
        void RemoveById(int hourageId);
        Hourage Get(int hourageId);
    }
}