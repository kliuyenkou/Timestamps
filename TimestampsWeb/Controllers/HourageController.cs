﻿using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using TimestampsWeb.ViewModels;

namespace TimestampsWeb.Controllers
{
    public class HourageController : Controller
    {
        private readonly IHourageService _hourageService;
        private readonly IProjectService _projectService;

        public HourageController(IHourageService hourageService, IProjectService projectService)
        {
            _hourageService = hourageService;
            _projectService = projectService;
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
            var projectsUserTakePart = _projectService.GetProjectsUserTakePart(userId);
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
                var hourage = new Hourage
                {
                    WorkDescription = viewModel.WorkDescription,
                    Date = viewModel.Date,
                    Hours = viewModel.Hours,
                    UserId = userId,
                    ProjectId = viewModel.ProjectId
                };

                _hourageService.AddHourageRecord(hourage);
                return RedirectToAction("Index");
            }
            var projectsUserTakePart = _projectService.GetProjectsUserTakePart(userId);
            ViewBag.ProjectId = new SelectList(projectsUserTakePart, "Id", "Title");
            return View(viewModel);
        }

        // GET: Hourage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var hourage = _hourageService.GetHourageById(id.Value);
            if (hourage == null) return HttpNotFound();
            return View(hourage);
        }

        // POST: Hourage/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _hourageService.DeleteHourageRecord(id);
            return RedirectToAction("Index");
        }
    }
}