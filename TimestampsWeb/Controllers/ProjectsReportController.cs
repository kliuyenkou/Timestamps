using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Dto;
using Timestamps.BLL.Interfaces;

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
        public IEnumerable<ProjectsReportDto> GetUserProjectsWithOverallTime()
        {
            var userId = User.Identity.GetUserId();
            var userProjectsWithOverallTime = _reportsService.GetUserProjectsWithOverallTime(userId);
            return userProjectsWithOverallTime;
        }
    }
}