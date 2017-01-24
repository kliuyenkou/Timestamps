using System.Web.Mvc;

namespace TimestampsWeb.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View("NotFound");
        }
    }
}