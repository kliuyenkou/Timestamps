using System.Web.Http;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using TimestampsWeb.Dto;

namespace TimestampsWeb.Controllers
{
    public class ProjectNominationsController : ApiController
    {
        private readonly IProjectNominationService _projectNominationService;

        public ProjectNominationsController(IProjectNominationService projectNominationService)
        {
            _projectNominationService = projectNominationService;
        }


        [HttpPost]
        public IHttpActionResult TakePartInProject(ProjectNominationDto projectNominationDto)
        {
            var userId = User.Identity.GetUserId();
            if (_projectNominationService.IsUserTakePartInProject(userId, projectNominationDto.ProjectId))
                return BadRequest("This user has already nominated on this project.");

            var projectNomination = new ProjectNomination
            {
                ProjectId = projectNominationDto.ProjectId,
                UserId = userId
            };

            _projectNominationService.Add(projectNomination);

            return Ok();
        }
    }
}