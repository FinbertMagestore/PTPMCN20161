using System.ComponentModel;

namespace Education.Areas.Admin.Model
{
    public class Config
    {
        /// <summary>
        /// connect string to db
        /// </summary>
        public static string ConnectString = @"Data Source=DESKTOP-JGEUVHH\SUCCESS;Initial Catalog=Education;Persist Security Info=True;User ID=sa;Password=ngovanhuy;MultipleActiveResultSets=True;Application Name=EntityFramework";

        public static string UrlHost = "http://education.com/";

        public static string StoreName = "Education ";

        public enum NotifyType
        {
            Warning,
            Error,
            Success
        }

        public enum Roles
        {
            [Description("Admin")]
            Admin = 1,
            [Description("Student")]
            Student = 2,
            [Description("Teacher")]
            Teacher = 3,
            [Description("Client")]
            Client = 4,
        }
        public enum Status
        {
            [Description("Hiển thị")]
            Active = 1,
            [Description("Ẩn")]
            InActive = 0
        }
    }
}