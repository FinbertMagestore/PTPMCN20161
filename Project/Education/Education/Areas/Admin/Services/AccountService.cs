using Dapper;
using Education.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Security;

namespace Education.Areas.Admin.Services
{
    public class AccountService
    {
        private IDbConnection connect = new SqlConnection(Config.ConnectString);
        public AppUser GetByPrimaryKey(int id)
        {
            try
            {
                string query = "select * from AppUsers where Id = " + id;
                AppUser appUser = connect.Query<AppUser>(query).FirstOrDefault();
                return appUser;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public void DeleteByPrimaryKey(int id)
        {
            try
            {
                string query = "delete from AppUsers where Id = " + id;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }

        public List<AppUser> GetByWhere(string where)
        {
            try
            {
                string query = "";
                if (!string.IsNullOrEmpty(where))
                {
                    query = string.Format("select * from AppUsers where " + where);
                }
                else
                {
                    query = string.Format("select * from AppUsers");
                }
                return connect.Query<AppUser>(query).ToList();
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public static string GetUsername(int id)
        {
            IDbConnection connectDB = new SqlConnection(Config.ConnectString);
            try
            {
                string query = "select Username from AppUsers where Id = " + id;
                string username = connectDB.Query<string>(query).FirstOrDefault();
                return username;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return "";
            }
        }

        public int GetUserId(string userName)
        {
            try
            {
                string query = "select Id from AppUsers where Username like N'" + userName + "'";
                int userID = connect.Query<int>(query).FirstOrDefault<int>();
                return userID;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return 0;
            }
        }

        public bool Update(AppUser appUser)
        {
            try
            {
                string query = "update AppUsers set Username = @Username, Email = @Email, UserPhone = @UserPhone, MainPage = @MainPage, UserDescription = @UserDescription, Password = @Password where Id = @Id";
                int temp = connect.Execute(query, new
                {
                    appUser.Username,
                    appUser.Email,
                    appUser.Password,
                    appUser.Id
                });
                if (temp > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
            return false;
        }
        public int Insert(AppUser appUser)
        {
            try
            {
                string query = "insert into Lession(" +
                        " Name,Description,Created,Modified,Alias,Status,ImageUrl,TeacherID,RateAverage,SubjectID,DownloadCount)" +
                        " values (@Name,@Description,@Created,@Modified,@Alias,@Status,@ImageUrl,@TeacherID,@RateAverage,@SubjectID,@DownloadCount)" +
                        " SELECT @@IDENTITY";
                int id = connect.Query<int>(query, new
                {
                    appUser.Username,
                    appUser.Email,
                    appUser.Password,
                    appUser.Id
                }).Single();
                return id;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return 0;
            }
        }

        public List<AppUser> GetAll()
        {
            try
            {
                string query = "select * from AppUsers";
                List<AppUser> appUsers = connect.Query<AppUser>(query).ToList<AppUser>();
                return appUsers;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public static string GetRolesOfUser(AppUser user)
        {
            String[] roleUsers = Roles.GetRolesForUser(user.Username);
            string roles = Utilz.Util.Conver2String(roleUsers, ',');
            return roles;
        }

    }
}