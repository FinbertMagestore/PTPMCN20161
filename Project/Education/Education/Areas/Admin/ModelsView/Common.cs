using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Models
{
    public class Common
    {/// <summary>
        /// connect string to db
        /// </summary>
        public static string ConnectString = @"Data Source=DESKTOP-JGEUVHH\SUCCESS;Initial Catalog=Education;Persist Security Info=True;User ID=sa;Password=ngovanhuy;MultipleActiveResultSets=True;Application Name=EntityFramework";

        public static string UrlHost = "http://education.com/";

        public static string StoreName = "Education ";
    }
}