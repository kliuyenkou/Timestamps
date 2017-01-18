using System.Collections.Generic;
using Timestamps.BLL.DataContracts;

namespace Timestamps.BLL.Interfaces
{
    public interface IReportsService
    {
        IEnumerable<ProjectWithTotalHours> GetUserProjectsWithOverallTime(string userId);
    }
}