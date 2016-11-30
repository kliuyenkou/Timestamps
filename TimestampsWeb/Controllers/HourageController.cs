using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TimestampsWeb.Models;
using TimestampsWeb.TimestampsWeb.DAL.EFDataReceiving;
using TimestampsWeb.TimestampsWeb.DAL.Interfaces;
using TimestampsWeb.ViewModels;

namespace TimestampsWeb.Controllers
{
    [Authorize]
    public class HourageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HourageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Hourage
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();


            var hourages = _unitOfWork.Hourages.GetUserHourageRecordsWithProject(userId);
            return View(hourages);
        }


        // GET: Hourage/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var projectsUserTakePart = _unitOfWork.ProjectNominations.GetProjectsUserTakePart(userId);
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
                    WorkDescription = viewModel.WorkDescripton,
                    Date = viewModel.Date,
                    Hours = viewModel.Hours,
                    UserId = userId,
                    ProjectId = viewModel.ProjectId,
                };

                _unitOfWork.Hourages.Add(hourage);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            var projectsUserTakePart = _unitOfWork.ProjectNominations.GetProjectsUserTakePart(userId);
            ViewBag.ProjectId = new SelectList(projectsUserTakePart, "Id", "Title");
            return View(viewModel);
        }


        // POST: Hourage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var hourage = _unitOfWork.Hourages.Find(h => h.Id == id);
            _unitOfWork.Hourages.RemoveRange(hourage);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
