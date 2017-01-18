using System;
using System.Collections.Generic;
using Timestamps.BLL.DataContracts;

namespace Timestamps.BLL.Interfaces
{
    public interface IHourageService
    {
        IEnumerable<Hourage> GetUserHourageRecordsWithProject(string userId);
        void AddHourageRecord(Hourage hourage);
        Hourage GetHourageById(int hourageId);
        void DeleteHourageRecord(int hourageId);
        Hourage CreateHourageRecord(string workDescription, int projectId, DateTime date, double hours, string userId);
    }
}