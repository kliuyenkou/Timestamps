using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TimestampsWeb.Models;

namespace TimestampsWeb.Controllers
{
    public class HourageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hourage
        public ActionResult Index()
        {
            var hourages = db.Hourages.Include(h => h.Project).Include(h => h.User);
            return View(hourages.ToList());
        }

        // GET: Hourage/Details/5
        public ActionResult Details(int? id)
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

        // GET: Hourage/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: Hourage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProjectId,UserId,WorkDescripton,Date,Hours")] Hourage hourage)
        {
            if (ModelState.IsValid)
            {
                db.Hourages.Add(hourage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title", hourage.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", hourage.UserId);
            return View(hourage);
        }

        // GET: Hourage/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title", hourage.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", hourage.UserId);
            return View(hourage);
        }

        // POST: Hourage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProjectId,UserId,WorkDescripton,Date,Hours")] Hourage hourage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hourage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title", hourage.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", hourage.UserId);
            return View(hourage);
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
