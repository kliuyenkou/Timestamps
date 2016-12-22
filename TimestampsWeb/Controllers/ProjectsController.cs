using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using TimestampsWeb.ViewModels;

namespace TimestampsWeb.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectNominationService _projectNominationService;
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService, IProjectNominationService projectNominationService)
        {
            _projectService = projectService;
            _projectNominationService = projectNominationService;
        }

        // GET: Projects
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProjectViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("Create", viewModel);
            var project = new Project
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                CreatorId = User.Identity.GetUserId()
            };
            await _projectService.CreateProjectAsync(project);

            return RedirectToAction("MyProjects", "Projects");
        }

        [HttpGet]
        public ActionResult MyProjects()
        {
            var userId = User.Identity.GetUserId();
            var myProjects = _projectNominationService.GetProjectsUserTakePart(userId);
            var projects = Mapper.Map<IEnumerable<ProjectViewModel>>(myProjects);
            return View("MyProjects", projects);
        }

        [HttpGet]
        public ActionResult FindProject()
        {
            var userId = User.Identity.GetUserId();
            var allProjects = _projectService.GetAllProjects();
            var projects = Mapper.Map<IEnumerable<ProjectWithCreatorViewModel>>(allProjects);

            return View("FindProject", projects);

        }
    }
}