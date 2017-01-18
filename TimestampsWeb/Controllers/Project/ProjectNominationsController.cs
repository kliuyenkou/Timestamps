using System.Web.Http;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Interfaces;
using TimestampsWeb.Dto;

namespace TimestampsWeb.Controllers.Project
{
    public class ProjectNominationsController : ApiController
    {
        private readonly IProjectService _projectService;

        public ProjectNominationsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public IHttpActionResult TakePartInProject(ProjectNominationDto projectNominationDto)
        {
            var userId = User.Identity.GetUserId();
            if (_projectService.IsUserTakePartInProject(userId, projectNominationDto.ProjectId))
                return BadRequest("This user has laready took part in this project.");

            _projectService.AddUserToProject(projectNominationDto.ProjectId, userId);

            return Ok();
        }
    }
}