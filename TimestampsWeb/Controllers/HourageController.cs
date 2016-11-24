using Microsoft.AspNet.Identity;
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

            // This solution with bad perfomance, but it's ok for testing interfaces
            var projectsUserTakePart = db.ProjectNominations.Include(pn => pn.Project).Where(pn => pn.UserId == userId).Select(pn=>pn.Project);
            var hourages = db.Hourages.Include(h => h.Project).Include(h => h.User).Where(h => projectsUserTakePart.Contains(h.Project));
            return View(hourages.ToList());
        }

    
        // GET: Hourage/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var projectsUserTakePart = db.ProjectNominations.Include(pn => pn.Project).Where(pn => pn.UserId == userId).Select(pn => pn.Project);
            ViewBag.ProjectId = new SelectList(projectsUserTakePart, "Id", "Title");
            ViewBag.UserId = userId;
            return View();
        }

        // POST: Hourage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( HourageViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            
            if (ModelState.IsValid)
            {
                var hourage = new Hourage()
                {
                    WorkDescripton = viewModel.WorkDescripton,
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hourage hourage = db.Hourages.Find(id);
            if (hourage == null)
            {
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
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
