using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using Timestamps.DAL.Interfaces;

namespace Timestamps.BLL.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IHourageRepository _hourageRepository;
        private readonly IProjectNominationRepository _projectNominationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReportsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _hourageRepository = unitOfWork.Hourages;
            _projectNominationRepository = unitOfWork.ProjectNominations;
        }

        public IEnumerable<ProjectWithTotalHours> GetUserProjectsWithOverallTime(string userId)
        {
            var projectsUserTakePart = _projectNominationRepository.GetProjectsUserTakePart(userId);
            var houragesGroupedByProject = _hourageRepository.GetUserHourageRecordsWithProject(userId)
                .GroupBy(h => h.Project)
                .Select(hg =>
                    new
                    {
                        Project = hg.Key,
                        TotalHours = hg.Sum(r => r.Hours)
                    });
            var result = from pu in projectsUserTakePart
                         join hourageRecord in houragesGroupedByProject on pu equals hourageRecord.Project into allProjects
                         from p in allProjects.DefaultIfEmpty()
                         select new { Project = pu, TotalHours = p?.TotalHours ?? 0 };

            var projectsWithTotalHours = result.Select(h => new ProjectWithTotalHours()
            {
                Project = Mapper.Map<Project>(h.Project),
                Hours = h.TotalHours
            });
            return projectsWithTotalHours;
        }
    }
}