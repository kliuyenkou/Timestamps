using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using TimestampsWeb.Models;
using System.Data.Entity;
using System.Linq;
using TimestampsWeb.TimestampsWeb.DAL.Interfaces;
using TimestampsWeb.TimestampsWeb.DAL.EFDataReceiving;

namespace TimestampsWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var projectsUserTakePart = _unitOfWork.ProjectNominations.GetProjectsUserTakePart(userId);
            ViewBag.ProjectId = new SelectList(projectsUserTakePart, "Id", "Title");
            ViewBag.UserId = userId;

            return View("Index");
        }

    }
}