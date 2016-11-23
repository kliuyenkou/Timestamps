using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using TimestampsWeb.Models;
namespace TimestampsWeb.Controllers
{
    [Authorize]
    public class ProjectNominationsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public ProjectNominationsController()
        {
            _context = new ApplicationDbContext();
        }

        
        [HttpPost]
        public IHttpActionResult TakePartInProject([FromBody] int projectId)
        {
            var userId = User.Identity.GetUserId();
            var IsExist = _context.ProjectNominations.Any(pn => pn.ProjectId == projectId && pn.UserId == userId);
            if (IsExist) {
                return BadRequest("This user has already nominated on this project.");
            }

            var projectNomination = new ProjectNomination
            {
                ProjectId = projectId,
                UserId = userId
            };

            _context.ProjectNominations.Add(projectNomination);
            _context.SaveChanges();
            return Json(projectNomination);
            //return Ok();
        }


    }
}
