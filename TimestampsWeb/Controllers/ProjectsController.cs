using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using TimestampsWeb.Models;
using TimestampsWeb.ViewModels;
using TimestampsWeb.TimestampsWeb.DAL.Interfaces;
using TimestampsWeb.TimestampsWeb.DAL.EFDataReceiving;

namespace TimestampsWeb.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProjectNominationRepository _ProjectNominationRepository;

        public ProjectsController()
        {
            _context = new ApplicationDbContext();
            _ProjectNominationRepository = new ProjectNominationRepository(_context);

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
            var myProjects = _ProjectNominationRepository.GetProjectsUserTakePart(userId);
            return View("MyProjects", myProjects);
        }

    }
}