using System.Web.Mvc;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Services;
using TimestampsWeb.ViewModels;

namespace TimestampsWeb.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReportsService _reportsService;
        public ReportsController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }
        // GET: Reports/projects
        [HttpGet]
        public ActionResult Projects()
        {
            var model = new ReportsProjectsViewModel();
            return View("ReportMyProjects", model);
        }

        // POST: Reports/projects
        [HttpPost]
        public ActionResult Projects(ReportsProjectsViewModel reportFilters)
        {

            return View("ReportMyProjects");
        }

    }
}