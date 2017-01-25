using System.Web.Mvc;
using Timestamps.BLL.Interfaces;

namespace TimestampsWeb.Controllers.Reports
{
    public class ReportsController : Controller
    {
        private readonly IReportsService _reportsService;

        public ReportsController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }

    }
}