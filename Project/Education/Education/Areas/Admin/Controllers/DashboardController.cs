using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : AdminBaseController
    {
        //
        // GET: /Admin/Dashboard/
        public ActionResult Index()
        {
            ViewData["CurrentMenu"] = "dashboard";
            return View();
        }
    }
}