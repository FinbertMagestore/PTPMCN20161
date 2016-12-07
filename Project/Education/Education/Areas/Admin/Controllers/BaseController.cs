using Education.Areas.Admin.Model;
using System;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    public class AdminBaseController : BaseController
    {

    }

    public class BaseController : Controller
    {
        public string Title
        {
            get
            {
                return ViewBag.Title;
            }
            set
            {
                ViewBag.Title = value;
            }
        }

        public string CSS
        {
            get
            {
                return ViewBag.CSS;
            }
            set
            {
                ViewBag.CSS = value;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // only process for main action, not for Child Action
            try
            {
                if (!filterContext.IsChildAction)
                {
                    if (string.IsNullOrEmpty(Title))
                    {
                        //Set default Title for page
                        string controller = filterContext.RouteData.Values["controller"].ToString(); ;
                        string action = filterContext.RouteData.Values["action"].ToString();
                        //Set default Title for page
                        Title = controller + " | " + action ;
                    }
                }
            }
            catch
            {
                Title = Config.StoreName;
            }

            base.OnActionExecuting(filterContext);
        }

    }
}