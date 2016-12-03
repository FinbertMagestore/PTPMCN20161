using Education.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Education.Areas.Admin.Services
{
    public class LogService
    {
        private AccountService appUserService = new AccountService();

        private IDbConnection connect = new SqlConnection(Common.ConnectString);

        /// <summary>
        /// path to directory of project web
        /// </summary>
        private static string PathBase = HttpRuntime.AppDomainAppPath;
        /// <summary>
        /// name of file log
        /// </summary>
        private static string FileName = "LogFile.txt";

        public LogService()
        {
        }

        /// <summary>
        /// write information exception to file log.
        /// </summary>
        /// <param name="ex">exception will be wrote</param>
        public static void WriteException(Exception ex)
        {
            try
            {
                string urlFileLog = PathBase + "/" + FileName;

                string strError = "";
                strError += Environment.NewLine;
                strError += "----------Exception when: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                strError += "\n" + ex.ToString();
                strError += Environment.NewLine;

                File.AppendAllText(urlFileLog, strError);
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// write information exception to file log.
        /// </summary>
        /// <param name="ex">exception will be wrote</param>
        public static void WriteError(string error)
        {
            try
            {
                string urlFileLog = PathBase + "/" + FileName;

                string strError = "";
                strError += Environment.NewLine;
                strError += "----------Error when: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                strError += "\n" + error;
                strError += Environment.NewLine;

                File.AppendAllText(urlFileLog, strError);
            }
            catch
            {
                return;
            }
        }
    }
}