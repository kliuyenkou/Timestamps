using System.Collections.Generic;
using Timestamps.BLL.Models;

namespace Timestamps.BLL.Interfaces
{
    public interface IReportsService
    {
        IEnumerable<ProjectWithTotalHours> GetUserProjectsWithOverallTime(string userId);
    }
}