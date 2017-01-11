using System.Collections.Generic;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.Management.Interfaces
{
    public interface IHourageManagement
    {
        void Create(Hourage hourage);
        void Delete(int hourageId);
        IEnumerable<Hourage> GetUserHourageRecords(string userId);
        Hourage Get(int hourageId);
    }
}
