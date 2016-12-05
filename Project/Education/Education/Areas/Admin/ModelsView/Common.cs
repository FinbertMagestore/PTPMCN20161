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
    }
}