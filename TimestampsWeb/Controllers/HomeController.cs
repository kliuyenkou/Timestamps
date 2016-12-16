using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Interfaces;
using TimestampsWeb.ViewModels;

namespace TimestampsWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectNominationService _projectNominationService;

        public HomeController(IProjectNominationService projectNominationService)
        {
            _projectNominationService = projectNominationService;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var projectsUserTakePart = _projectNominationService.GetProjectsUserTakePart(userId);
            ViewBag.ProjectId = new SelectList(projectsUserTakePart, "Id", "Title");
            ViewBag.UserId = userId;
            var viewModel = new HourageViewModel();
            return View("Index", viewModel);
        }
    }
}