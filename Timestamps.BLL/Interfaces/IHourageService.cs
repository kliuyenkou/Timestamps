using System.Collections.Generic;
using Timestamps.BLL.Models;

namespace Timestamps.BLL.Interfaces
{
    public interface IHourageService
    {
        IEnumerable<Hourage> GetUserHourageRecordsWithProject(string userId);
        void AddHourageRecord(Hourage hourage);
        Hourage GetHourageById(int hourageId);
        void DeleteHourageRecord(int hourageId);
    }
}