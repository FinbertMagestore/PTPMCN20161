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

        public AppUser GetUserByUsername(string userName)
        {
            try
            {
                string query = "select * from AppUsers where Username like N'" + userName + "'";
                AppUser appUser = connect.Query<AppUser>(query).FirstOrDefault();
                return appUser;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public AppUser GetUserByemail(string email)
        {
            try
            {
                string query = "select * from AppUsers where Email like N'" + email + "'";
                AppUser appUser = connect.Query<AppUser>(query).FirstOrDefault();
                return appUser;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public void Update(AppUser appUser)
        {
            try
            {
                string query = "update AppUsers set Username = @Username, Password = @Password, Email = @Email,"
                    + " DateCreated = @DateCreated, LastActivityDate = @LastActivityDate, SecurityStamp = @SecurityStamp, "
                    + " FullName = @FullName, Birthday = @Birthday, Sex = @Sex, "
                    + " ImageUrl = @ImageUrl, Description = @Description, Modified = @Modified, "
                    + " IsActive = @IsActive, Address = @Address "
                    + " where Id = @Id";
                connect.Execute(query, new
                {
                    appUser.Username,
                    appUser.Password,
                    appUser.Email,
                    appUser.DateCreated,
                    appUser.LastActivityDate,
                    appUser.SecurityStamp,
                    appUser.FullName,
                    appUser.Birthday,
                    appUser.Sex,
                    appUser.ImageUrl,
                    appUser.Description,
                    appUser.Modified,
                    appUser.IsActive,
                    appUser.Address,
                    appUser.Id
                });
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }
        public int Insert(AppUser appUser)
        {
            try
            {
                string query = "insert into AppUsers("
                        + " Username,Password,Email,DateCreated,LastActivityDate,SecurityStamp,FullName,"
                        + " Birthday,Sex,ImageUrl,Description,Modified,IsActive,Address)"
                        + " values (@Username,@Password,@Email,@DateCreated,@LastActivityDate,@SecurityStamp,@FullName,"
                        + " @Birthday,@Sex,@ImageUrl,@Description,@Modified,@IsActive,@Address)"
                        + " SELECT @@IDENTITY";
                return connect.Query<int>(query, new
                {
                    appUser.Username,
                    appUser.Password,
                    appUser.Email,
                    appUser.DateCreated,
                    appUser.LastActivityDate,
                    appUser.SecurityStamp,
                    appUser.FullName,
                    appUser.Birthday,
                    appUser.Sex,
                    appUser.ImageUrl,
                    appUser.Description,
                    appUser.Modified,
                    appUser.IsActive,
                    appUser.Address
                }).Single();
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

        public string GetRolesOfUser(AppUser user)
        {
            try
            {
                if (user != null && !string.IsNullOrEmpty(user.Username))
                {
                    String[] roleUsers = Roles.GetRolesForUser(user.Username);
                    string roles = Utilz.Util.Conver2String(roleUsers, ',');
                    return roles;
                }
                return "";
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return "";
            }
        }

    }
}