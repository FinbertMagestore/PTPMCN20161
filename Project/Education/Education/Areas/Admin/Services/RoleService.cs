using Dapper;
using Education.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Education.Areas.Admin.Services
{
    public class RoleService
    {
        private IDbConnection connect = new SqlConnection(Config.ConnectString);

        public List<AspNetRole> GetAllRole()
        {
            try
            {
                string query = string.Format("select * from AspNetRoles");
                List<AspNetRole> roles = connect.Query<AspNetRole>(query).ToList<AspNetRole>();
                return roles;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public AspNetRole GetRoleByPrimaryKey(int id)
        {
            try
            {
                string query = "select * from AspNetRoles where Id = " + id;
                AspNetRole role = connect.Query<AspNetRole>(query).FirstOrDefault();
                return role;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public bool UpdateRole(AspNetRole role)
        {
            try
            {
                string query = "update AspNetRoles set Name = @Name where Id = @Id";
                int temp = connect.Execute(query, new
                {
                    role.Name,
                    role.Id
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
        public List<AppUser> GetAllUserInRole(int roleID)
        {
            try
            {
                string query = string.Format("select * from AppUsers where Id in (select UserId from AspNetUserRoles where RoleId = {0})", roleID);
                List<AppUser> appUsers = connect.Query<AppUser>(query).ToList<AppUser>();
                return appUsers;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
    }
}