using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using TimestampsWeb.Models;
using TimestampsWeb.ViewModels;

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
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectViewModel viewModel)
        {
            if (!ModelState.IsValid) {
                return View("Create", viewModel);
            }
            var project = new Project()
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                CreatorId = User.Identity.GetUserId()
            };

            _context.Projects.Add(project);
            _context.SaveChanges();


            var projectNomination = new ProjectNomination
            {
                ProjectId = project.Id,
                UserId = project.CreatorId
            };

            _context.ProjectNominations.Add(projectNomination);
            _context.SaveChanges();

            return RedirectToAction("MyProjects", "Projects");
        }

        [Authorize]
        [HttpGet]
        public ActionResult MyProjects()
        {
            var userId = User.Identity.GetUserId();
            //IEnumerable<Project> myProjects = _context.Projects.Include(p => p.Creator).Where(p => p.CreatorId == userId).ToList();
            var myProjects = from pn in _context.ProjectNominations
                             where pn.UserId == userId
                             select pn.Project;
            //var myProjects1 = from pn in _context.ProjectNominations
            //                 where pn.UserId == userId
            //                 group pn by new { Project = pn.ProjectId, User = pn.User} into g
            //                 select g.Key.Project;

            return View("MyProjects", myProjects.ToList());
        }

        [NonAction]
        public void AddProjectNominationsRecord(int projectId)
        {
            
        }

    }
}