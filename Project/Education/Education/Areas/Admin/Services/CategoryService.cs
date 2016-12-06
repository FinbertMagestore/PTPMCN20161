using Dapper;
using Education.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Education.Areas.Admin.Services
{
    public class CategoryService
    {
        private IDbConnection connect = new SqlConnection(Config.ConnectString);
        public List<Category> GetAll()
        {
            try
            {
                string query = string.Format("select * from Category order by Created desc");
                List<Category> categories = connect.Query<Category>(query).ToList<Category>();
                return categories;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public List<Category> GetAllActive()
        {
            try
            {
                string query = string.Format("select * from Category where Status = {0} order by Created desc", (int)Config.Status.Active);
                List<Category> categories = connect.Query<Category>(query).ToList<Category>();
                return categories;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public List<Category> GetByWhere(string where)
        {
            try
            {
                string query = "";
                if (!string.IsNullOrEmpty(where))
                {
                    query = string.Format("select * from Category where " + where + " order by Created desc");
                }
                else
                {
                    query = string.Format("select * from Category order by Created desc");
                }
                return connect.Query<Category>(query).ToList();
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public Category GetByPrimaryKey(int id)
        {
            try
            {
                string query = "select * from Category where ID = " + id;
                Category category = connect.Query<Category>(query).FirstOrDefault<Category>();
                return category;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public int Insert(Category category)
        {
            try
            {
                string query = "insert into Category(" +
                        " Name,Description,CategoryTypeID,Alias,Created,Modified,Status,ImageUrl,ForAdminPost,IsHighLight)" +
                        " values (@Name,@Description,@CategoryTypeID,@Alias,@Created,@Modified,@Status,@ImageUrl,@ForAdminPost,@IsHighLight)" +
                        " SELECT @@IDENTITY";
                int id = connect.Query<int>(query, new
                {
                    category.Name,
                    category.Description,
                    category.CategoryTypeID,
                    category.Alias,
                    category.Created,
                    category.Modified,
                    category.Status,
                    category.ImageUrl,
                    category.ForAdminPost,
                    category.IsHighLight
                }).Single();
                return id;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return 0;
            }
        }
        public bool Update(Category category)
        {
            try
            {
                string query = "update Category set Name = @Name, Description = @Description, CategoryTypeID = @CategoryTypeID, " +
                    " Alias=@Alias,Created=@Created, " +
                    " Modified=@Modified,Status=@Status, " +
                    " ImageUrl=@ImageUrl,ForAdminPost=@ForAdminPost, " +
                    " IsHighLight=@IsHighLight " +
                        " where ID = @ID ";
                return 0 < connect.Execute(query, new
                {
                    category.Name,
                    category.Description,
                    category.CategoryTypeID,
                    category.Alias,
                    category.Created,
                    category.Modified,
                    category.Status,
                    category.ImageUrl,
                    category.ForAdminPost,
                    category.IsHighLight,
                    category.ID
                });

            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return false;
            }
        }

        public void DeleteByPrimaryKey(int id)
        {
            try
            {
                string query = "delete from Category where ID = " + id;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }

        public Category GetByAlias(string alias)
        {
            try
            {
                string query = string.Format("select * from Category where Alias like N'{0}'", alias);
                Category category = connect.Query<Category>(query).FirstOrDefault<Category>();
                return category;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public List<Post> GetAllPostInCategory(int categoryID)
        {
            try
            {
                string query = string.Format("select * from Post where CategoryID = {0}", categoryID);
                List<Post> posts = connect.Query<Post>(query).ToList();
                return posts;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
    }
}