using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using TimestampsWeb.Models;
using TimestampsWeb.TimestampsWeb.DAL.EFDataReceiving;
using TimestampsWeb.TimestampsWeb.DAL.Interfaces;

namespace TimestampsWeb.Controllers
{
    [Authorize]
    public class ProjectNominationsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectNominationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public IHttpActionResult TakePartInProject([FromBody] int projectId)
        {
            var userId = User.Identity.GetUserId();
            var IsExist = _unitOfWork.ProjectNominations.IsUserTakePartInProject(userId, projectId);
            if (IsExist) {
                return BadRequest("This user has already nominated on this project.");
            }

            var projectNomination = new ProjectNomination
            {
                ProjectId = projectId,
                UserId = userId
            };

            _unitOfWork.ProjectNominations.Add(projectNomination);
            _unitOfWork.SaveChanges();

            return Json(projectNomination);
            //return Ok();
        }


    }
}
