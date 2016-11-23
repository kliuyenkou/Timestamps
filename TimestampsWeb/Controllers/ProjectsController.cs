using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
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

            return RedirectToAction("MyProjects", "Projects");
        }

        [Authorize]
        [HttpGet]
        public ActionResult MyProjects()
        {
            var userId = User.Identity.GetUserId();
            IEnumerable<Project> myProjects = _context.Projects.Include(p => p.Creator).Where(p => p.CreatorId == userId).ToList();
            return View("MyProjects", myProjects);
        }


    }
}