using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using TimestampsWeb.ViewModels;

namespace TimestampsWeb.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IProjectNominationService _projectNominationService;

        public ProjectsController(IProjectService projectService, IProjectNominationService projectNominationService)
        {
            _projectService = projectService;
            _projectNominationService = projectNominationService;

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

            _projectService.Add(project);

            var projectNomination = new ProjectNomination
            {
                ProjectId = project.Id,
                UserId = project.CreatorId
            };

            _projectNominationService.Add(projectNomination);

            return RedirectToAction("MyProjects", "Projects");
        }

        [Authorize]
        [HttpGet]
        public ActionResult MyProjects()
        {
            var userId = User.Identity.GetUserId();
            var myProjects = _projectNominationService.GetProjectsUserTakePart(userId);
            return View("MyProjects", myProjects);
        }

    }
}