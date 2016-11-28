using System.Web.Mvc;

namespace TimestampsWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

    }
}