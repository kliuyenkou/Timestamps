using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TimestampsWeb.Models;
using TimestampsWeb.ViewModels;

namespace TimestampsWeb.Controllers
{
    [Authorize]
    public class HourageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hourage
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();


            var hourages = GetUsersHourageRecords(userId);
            return View(hourages);
        }

        private IEnumerable<Hourage> GetUsersHourageRecords(string userId)
        {
            // This solution with bad perfomance, but it's ok for testing interfaces
            var projectsUserTakePart = db.ProjectNominations.Include(pn => pn.Project).Where(pn => pn.UserId == userId).Select(pn => pn.Project);
            var hourages = db.Hourages.Where(h => projectsUserTakePart.Contains(h.Project)).Include(h => h.Project).Include(h => h.User).ToList();
            return hourages;
        }


        // GET: Hourage/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var projectsUserTakePart = GetProjectsUserTakePart(userId);
            ViewBag.ProjectId = new SelectList(projectsUserTakePart, "Id", "Title");
            ViewBag.UserId = userId;
            return View();
        }

        private IEnumerable<Project> GetProjectsUserTakePart(string userId)
        {
            return db.ProjectNominations.Where(pn => pn.UserId == userId).Include(pn => pn.Project).Select(pn => pn.Project);
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

                db.Hourages.Add(hourage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var projectsUserTakePart = db.ProjectNominations.Include(pn => pn.Project).Where(pn => pn.UserId == userId).Select(pn => pn.Project);
            ViewBag.ProjectId = new SelectList(projectsUserTakePart, "Id", "Title");
            return View(viewModel);
        }


        // GET: Hourage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hourage hourage = db.Hourages.Find(id);
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
            Hourage hourage = db.Hourages.Find(id);
            db.Hourages.Remove(hourage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
