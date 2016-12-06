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

        public AspNetRole GetRoleOfUser(int userID)
        {
            try
            {
                string query = string.Format("select * from AspNetUserRoles where UserId = {0} ", userID);
                List<AspNetUserRole> roles = connect.Query<AspNetUserRole>(query).ToList();
                if (roles != null)
                {
                    if (roles.Count > 1)
                    {
                        foreach (var item in roles)
                        {
                            if (item.RoleId != (int)Config.Roles.Client)
                            {
                                return GetRoleByPrimaryKey(item.RoleId);
                            }
                        }
                    }
                    else
                    {
                        return GetRoleByPrimaryKey(roles[0].RoleId);
                    }
                }
                return null;
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
        public int InsertRole(AspNetRole role)
        {
            try
            {
                string query = "insert into AspNetRoles(" +
                        " Id,Name)" +
                        " values (@Id,@Name)" +
                        " SELECT @@IDENTITY";
                int id = connect.Query<int>(query, new
                {
                    role.Id,
                    role.Name
                }).Single();
                return id;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return 0;
            }
        }

        public int InsertUserRole(AspNetUserRole userRole)
        {
            try
            {
                string query = "insert into AspNetUserRoles(" +
                        " UserId,RoleId)" +
                        " values (@UserId,@RoleId)" +
                        " SELECT @@IDENTITY";
                int id = connect.Query<int>(query, new
                {
                    userRole.UserId,
                    userRole.RoleId
                }).Single();
                return id;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return 0;
            }
        }

        public void DeleteUserRole(int userID, int roleID)
        {
            try
            {
                string query = string.Format("delete from AspNetUserRoles where UserId = {0} and RoleId = {1}", userID, roleID);
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }

        public void DeleteRole(int roleID)
        {
            try
            {
                string query = "delete from AspNetRoles where Id = " + roleID;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }

        public void DeleteAllRoleOfUser(int userID)
        {
            try
            {
                string query = "delete from AspNetUserRoles where UserId = " + userID;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }

        public void DeleteAllUserInRole(int roleID)
        {
            try
            {
                string query = string.Format("delete from AspNetUserRoles where RoleId = {1}", roleID);
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }
    }
}