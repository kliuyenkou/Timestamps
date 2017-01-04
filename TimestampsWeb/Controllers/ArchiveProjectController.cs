using System;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Interfaces;

namespace TimestampsWeb.Controllers
{
    public class ArchiveProjectController : ApiController
    {
        private readonly IProjectNominationService _projectNominationService;
        private readonly IProjectService _projectService;

        public ArchiveProjectController(IProjectService projectService, IProjectNominationService projectNominationService)
        {
            _projectService = projectService;
            _projectNominationService = projectNominationService;
        }

        [HttpPost]
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

        [HttpDelete]
        public IHttpActionResult Restore(int id)
        {
            string userId = User.Identity.GetUserId();
            try {
                _projectService.RestoreUserProjectById(userId, id);
            }
            catch (Exception) {
                return NotFound();
            }

            return Ok();
        }


    }
}
