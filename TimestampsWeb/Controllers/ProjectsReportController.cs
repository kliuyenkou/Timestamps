﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Dto;
using Timestamps.BLL.Interfaces;

namespace TimestampsWeb.Controllers
{
    [Authorize]
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