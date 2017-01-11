using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using Timestamps.DAL.Management.Interfaces;

namespace Timestamps.BLL.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IProjectManagement _projectManagement;
        private readonly IHourageManagement _hourageManagement;

        public ReportsService(IProjectManagement projectManagement, IHourageManagement hourageManagement)
        {
            _projectManagement = projectManagement;
            _hourageManagement = hourageManagement;
        }

        public IEnumerable<ProjectWithTotalHours> GetUserProjectsWithOverallTime(string userId)
        {
            var projectsUserTakePart = _projectManagement.GetProjectsUserTakePart(userId);
            var houragesGroupedByProject = _hourageManagement.GetUserHourageRecords(userId)
                .GroupBy(h => h.Project)
                .Select(hg =>
                    new
                    {
                        Project = hg.Key,
                        TotalHours = hg.Sum(r => r.Hours)
                    });
            var projectsWithTotalHours = from pu in projectsUserTakePart
                                         join hourageRecord in houragesGroupedByProject on pu equals hourageRecord.Project into allProjects
                                         from p in allProjects.DefaultIfEmpty()
                                         select new { Project = pu, TotalHours = p?.TotalHours ?? 0 };

            var result = projectsWithTotalHours.Select(h => new ProjectWithTotalHours()
            {
                Project = Mapper.Map<Project>(h.Project),
                Hours = h.TotalHours
            });
            return result;
        }
    }
}