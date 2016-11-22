using System.Web.Mvc;
using TimestampsWeb.Models;

namespace TimestampsWeb.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Projects
        public ActionResult Create()
        {
            return View("");
        }
    }
}