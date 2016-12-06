using Common.Logging;
using Education.Areas.Admin.Model;
using Elmah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Education.Areas.Admin.Model.Config;

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
                        Title = action + " | " + controller;
                    }
                }
            }
            catch (Exception ex)
            {
                Title = Config.StoreName;
            }

            base.OnActionExecuting(filterContext);
        }

    }
}