using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timestamps.BLL.Dto;

namespace Timestamps.BLL.Interfaces
{
    public interface IReportsService
    {
        IEnumerable<ProjectsReportDto> GetUserProjectsWithOverallTime(string userId);
    }
}
