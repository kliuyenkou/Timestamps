using System.Collections.Generic;
using Timestamps.BLL.Dto;

namespace Timestamps.BLL.Interfaces
{
    public interface IReportsService
    {
        IEnumerable<ProjectsReportDto> GetUserProjectsWithOverallTime(string userId);
    }
}