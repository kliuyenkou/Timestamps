using System.Web.Mvc;
using Timestamps.BLL.Interfaces;
using TimestampsWeb.ViewModels;

namespace TimestampsWeb.Controllers.Reports
{
    public class ReportsController : Controller
    {
        private readonly IReportsService _reportsService;

        public ReportsController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        [HttpGet]
        public ActionResult Projects()
        {
            var model = new ReportsProjectsViewModel();
            return View("ReportMyProjects", model);
        }

        [HttpPost]
        public ActionResult Projects(ReportsProjectsViewModel reportFilters)
        {
            return View("ReportMyProjects");
        }
    }
}