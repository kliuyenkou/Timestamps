using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Interfaces;
using TimestampsWeb.Dto;

namespace TimestampsWeb.Controllers
{
    public class ProjectsReportController : ApiController
    {
        private readonly IReportsService _reportsService;

        public ProjectsReportController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        // GET: api/ProjectsReport
        public IEnumerable<ProjectWithTotalHoursDto> GetUserProjectsWithOverallTime()
        {
            var userId = User.Identity.GetUserId();
            var userProjectsWithOverallTime = _reportsService.GetUserProjectsWithOverallTime(userId);
            var userProjectsWithOverallTimeDto = userProjectsWithOverallTime.Select(p => new ProjectWithTotalHoursDto()
            {
                Hours = p.Hours,
                ProjectId = p.Project.Id,
                ProjectTitle = p.Project.Title

            });
            return userProjectsWithOverallTimeDto;
        }
    }
}