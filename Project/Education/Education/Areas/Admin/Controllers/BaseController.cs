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
    public class AdminBaseController : Controller
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

        private static ILog logger = LogManager.GetCurrentClassLogger();
        protected virtual void WarningNotification(string message, bool persistForTheNextRequest = true)
        {
            AddNotification(NotifyType.Warning, message, persistForTheNextRequest);
        }

        protected virtual void SuccessNotification(string message, bool persistForTheNextRequest = true)
        {
            AddNotification(NotifyType.Success, message, persistForTheNextRequest);
        }
        protected virtual void ErrorNotification(string message, bool persistForTheNextRequest = true)
        {
            AddNotification(NotifyType.Error, message, persistForTheNextRequest);
        }
        protected virtual void ErrorNotification(Exception exception, bool persistForTheNextRequest = true)
        {
            logger.Error(exception.Message);
            ErrorSignal.FromCurrentContext().Raise(exception);
            AddNotification(NotifyType.Error, exception.Message, persistForTheNextRequest);
        }
        protected virtual void AddNotification(NotifyType type, string message, bool persistForTheNextRequest)
        {
            string dataKey = string.Format("education.notifications.{0}", type);
            if (persistForTheNextRequest)
            {
                if (TempData[dataKey] == null)
                    TempData[dataKey] = new List<string>();
                ((List<string>)TempData[dataKey]).Add(message);
            }
            else
            {
                if (ViewData[dataKey] == null)
                    ViewData[dataKey] = new List<string>();
                ((List<string>)ViewData[dataKey]).Add(message);
            }
        }
    }
}