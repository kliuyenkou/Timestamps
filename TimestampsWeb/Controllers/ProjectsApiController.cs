using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Interfaces;

namespace TimestampsWeb.Controllers
{
    public class ProjectsApiController : ApiController
    {
        private readonly IProjectNominationService _projectNominationService;
        private readonly IProjectService _projectService;

        public ProjectsApiController(IProjectService projectService, IProjectNominationService projectNominationService)
        {
            _projectService = projectService;
            _projectNominationService = projectNominationService;
        }

        [HttpDelete]
        public IHttpActionResult Archive(int id)
        {
            string userId = User.Identity.GetUserId();
            try {
                _projectService.ArchiveUserProjectById(userId, id);
            }
            catch (Exception) {
                return NotFound();
            }

            return Ok();
        }
    }
}
