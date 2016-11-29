using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using TimestampsWeb.Models;
using System.Data.Entity;
using System.Linq;

namespace TimestampsWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var projectsUserTakePart = db.ProjectNominations.Include(pn => pn.Project).Where(pn => pn.UserId == userId).Select(pn => pn.Project);
            ViewBag.ProjectId = new SelectList(projectsUserTakePart, "Id", "Title");
            ViewBag.UserId = userId;

            return View("Index");
        }

    }
}