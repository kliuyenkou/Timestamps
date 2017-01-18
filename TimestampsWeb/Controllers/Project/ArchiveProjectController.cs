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
            string userId = User.Identity.GetUserId();
            _projectService.ArchiveUserProjectAsync(userId, id);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Restore(int id)
        {
            string userId = User.Identity.GetUserId();
            _projectService.RestoreUserProject(userId, id);

            return Ok();
        }


    }
}
