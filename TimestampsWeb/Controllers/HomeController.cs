using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Linq;
using Timestamps.BLL.Interfaces;
using TimestampsWeb.ViewModels;

namespace TimestampsWeb.Controllers
{
    [Authorize]
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
            HourageViewModel viewModel = new HourageViewModel();
            return View("Index", viewModel);
        }

    }
}