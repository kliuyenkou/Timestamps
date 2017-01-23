using System.Collections.Generic;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.Management.Interfaces
{
    public interface IHourageManagement
    {
        Hourage Create(Hourage hourage);
        void Delete(string userId, int hourageId);
        IEnumerable<Hourage> GetUserHourageRecordsWithProject(string userId);
        Hourage Get(int hourageId);
    }
}