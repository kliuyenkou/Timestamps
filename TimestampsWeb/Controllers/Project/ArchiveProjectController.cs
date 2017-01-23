using System;
using System.Net;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Interfaces;

namespace TimestampsWeb.Controllers.Project
{
    public class ArchiveProjectController : ApiController
    {
        private readonly IProjectService _projectService;

        public ArchiveProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public IHttpActionResult Archive(int id)
        {
            var userId = User.Identity.GetUserId();

            try {
                _projectService.ArchiveUserProject(userId, id);
            }
            catch (NullReferenceException) {
                return StatusCode(HttpStatusCode.Forbidden);
            }
            catch (Exception) {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Restore(int id)
        {
            var userId = User.Identity.GetUserId();
            try {
                _projectService.RestoreUserProject(userId, id);
            }
            catch (Exception) {
                return InternalServerError();
            }

            return Ok();
        }
    }
}