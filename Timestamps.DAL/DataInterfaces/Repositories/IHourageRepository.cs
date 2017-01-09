using System.Collections.Generic;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;

namespace Timestamps.DAL.DataInterfaces.Repositories
{
    public interface IHourageRepository : IRepository<Hourage>
    {
        IEnumerable<Hourage> GetUserHourageRecordsWithProject(string userId);
        void RemoveById(int hourageId);
    }
}