using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Interfaces;
using TimestampsWeb.ViewModels;

namespace TimestampsWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectService _projectService;

        public HomeController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var projectsUserTakePart = _projectService.GetProjectsUserTakePart(userId);
            ViewBag.ProjectId = new SelectList(projectsUserTakePart, "Id", "Title");
            ViewBag.UserId = userId;
            var viewModel = new HourageViewModel();
            return View("Index", viewModel);
        }
    }
}