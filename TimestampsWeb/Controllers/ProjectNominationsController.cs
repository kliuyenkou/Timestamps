using System.Web.Http;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;

namespace TimestampsWeb.Controllers
{
    [Authorize]
    public class ProjectNominationsController : ApiController
    {
        private readonly IProjectNominationService _projectNominationService;

        public ProjectNominationsController(IProjectNominationService projectNominationService)
        {
            _projectNominationService = projectNominationService;
        }


        [HttpPost]
        public IHttpActionResult TakePartInProject([FromBody] int projectId)
        {
            var userId = User.Identity.GetUserId();
            var IsExist = _projectNominationService.IsUserTakePartInProject(userId, projectId);
            if (IsExist) return BadRequest("This user has already nominated on this project.");

            var projectNomination = new ProjectNomination
            {
                ProjectId = projectId,
                UserId = userId
            };

            _projectNominationService.Add(projectNomination);

            return Json(projectNomination);
            //return Ok();
        }
    }
}