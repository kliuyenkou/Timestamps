using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using TimestampsWeb.ViewModels;

namespace TimestampsWeb.Controllers
{
    [Authorize]
    public class HourageController : Controller
    {
        private readonly IHourageService _hourageService;
        private readonly IProjectNominationService _projectNominationService;

        public HourageController(IHourageService hourageService, IProjectNominationService projectNominationService)
        {
            _hourageService = hourageService;
            _projectNominationService = projectNominationService;
        }

        // GET: Hourage
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var hourages = _hourageService.GetUserHourageRecordsWithProject(userId);
            return View(hourages);
        }


        // GET: Hourage/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var projectsUserTakePart = _projectNominationService.GetProjectsUserTakePart(userId);
            ViewBag.ProjectId = new SelectList(projectsUserTakePart, "Id", "Title");
            ViewBag.UserId = userId;
            return View();
        }


        // POST: Hourage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HourageViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();

            if (ModelState.IsValid) {
                var hourage = new Hourage()
                {
                    WorkDescription = viewModel.WorkDescription,
                    Date = viewModel.Date,
                    Hours = viewModel.Hours,
                    UserId = userId,
                    ProjectId = viewModel.ProjectId,
                };

                _hourageService.Add(hourage);
                return RedirectToAction("Index");
            }
            var projectsUserTakePart = _projectNominationService.GetProjectsUserTakePart(userId);
            ViewBag.ProjectId = new SelectList(projectsUserTakePart, "Id", "Title");
            return View(viewModel);
        }

        // GET: Hourage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hourage hourage = _hourageService.GetHourageById(id.Value);
            if (hourage == null) {
                return HttpNotFound();
            }
            return View(hourage);
        }

        // POST: Hourage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _hourageService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                _hourageService.Dispose();
                _projectNominationService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
