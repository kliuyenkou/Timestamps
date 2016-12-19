using System.Collections.Generic;
using System.Linq;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using Timestamps.DAL.Interfaces;

namespace Timestamps.BLL.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IHourageRepository _hourageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReportsService(IUnitOfWork unitOfWork)
        {
            _hourageRepository = unitOfWork.Hourages;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProjectWithTotalHours> GetUserProjectsWithOverallTime(string userId)
        {
            var hourages = _hourageRepository.GetUserHourageRecordsWithProject(userId);
            var houragesGroupedByProject = hourages.GroupBy(h => h.Project)
                .Select(hg =>
                    new
                    {
                        Project = hg.Key,
                        TotalHours = hg.Sum(r => r.Hours)
                    });
            var projectsWithTotalHours = houragesGroupedByProject.Select(h => new ProjectWithTotalHours
            {
                ProjectId = h.Project.Id,
                ProjectTitle = h.Project.Title,
                Hours = h.TotalHours
            });
            return projectsWithTotalHours;
        }
    }
}