using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timestamps.BLL.Dto;
using Timestamps.BLL.Interfaces;
using Timestamps.DAL.Interfaces;

namespace Timestamps.BLL.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHourageRepository _hourageRepository;
        public ReportsService(IUnitOfWork unitOfWork)
        {
            _hourageRepository = unitOfWork.Hourages;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<ProjectsReportDto> GetUserProjectsWithOverallTime(string userId)
        {
            var hourages = _hourageRepository.GetUserHourageRecordsWithProject(userId);
            var houragesGroupedByProject = hourages.GroupBy(h => h.Project)
                .Select(hg =>
                        new
                        {
                            Project = hg.Key,
                            TotalHours = hg.Sum(r=>r.Hours)
                        });
            IEnumerable<ProjectsReportDto> projectsReportDtos;
            projectsReportDtos = houragesGroupedByProject.Select(h => new ProjectsReportDto()
            {
                ProjectId = h.Project.Id,
                ProjectTitle = h.Project.Title,
                Hours = h.TotalHours
            });
            return projectsReportDtos;

        }
    }
}
