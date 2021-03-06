﻿using Dapper;
using Education.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Education.Areas.Admin.Services
{
    public class PostService
    {
        private IDbConnection connect = new SqlConnection(Config.ConnectString);
        public List<Post> GetAll()
        {
            try
            {
                string query = string.Format("select * from Post order by Created desc");
                List<Post> posts = connect.Query<Post>(query).ToList<Post>();
                return posts;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public List<Post> GetAllActive()
        {
            try
            {
                string query = string.Format("select * from Post where Status = {0} order by Created desc", (int)Config.Status.Active);
                List<Post> posts = connect.Query<Post>(query).ToList<Post>();
                return posts;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }



        public List<Post> GetPostsInSameCategory(int id, int numberPost)
        {
            try
            {
                Post post = GetByPrimaryKey(id);
                if (post != null)
                {
                    string query = string.Format("select * from Post where CategoryID = {0} and ID <> {1} order by Created desc", post.CategoryID, post.ID);
                    List<Post> posts = connect.Query<Post>(query).ToList<Post>();
                    if (posts != null && posts.Count > numberPost)
                    {
                        List<Post> result = new List<Post>();
                        for (int i = 0; i < numberPost; i++)
                        {
                            result.Add(posts[i]);
                        }
                        return result;
                    }
                    return posts;
                }
                return null;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public List<Post> GetByCategoryID(int categoryID)
        {
            try
            {
                string query = string.Format("select * from Post where CategoryID = {0} and Status = {1} order by Created desc", categoryID, (int)Config.Status.Active);
                List<Post> posts = connect.Query<Post>(query).ToList<Post>();
                return posts;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public List<Post> GetByWhere(string where)
        {
            try
            {
                string query = "";
                if (!string.IsNullOrEmpty(where))
                {
                    query = string.Format("select * from Post where " + where + " order by Created desc");
                }
                else
                {
                    query = string.Format("select * from Post order by Created desc");
                }
                return connect.Query<Post>(query).ToList();
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public Post GetByPrimaryKey(int id)
        {
            try
            {
                string query = "select * from Post where ID = " + id;
                Post post = connect.Query<Post>(query).FirstOrDefault<Post>();
                return post;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public Post GetByAlias(string alias, int categoryID)
        {
            try
            {
                string query = string.Format("select * from Post where Alias like N'{0}' and CategoryID = {1} ", alias, categoryID);
                Post post = connect.Query<Post>(query).FirstOrDefault();
                return post;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public List<Post> GetByUserID(int userID)
        {
            try
            {
                string query = string.Format("select * from Post where UserID = {0} ", userID);
                List<Post> posts = connect.Query<Post>(query).ToList();
                return posts;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public int Insert(Post post)
        {
            try
            {
                string query = "insert into Post(" +
                        " Name,Alias,CategoryID,Created,Modified,Status,Description,ImageUrl,UserID,Content)" +
                        " values (@Name,@Alias,@CategoryID,@Created,@Modified,@Status,@Description,@ImageUrl,@UserID,@Content)" +
                        " SELECT @@IDENTITY";
                int id = connect.Query<int>(query, new
                {
                    post.Name,
                    post.Alias,
                    post.CategoryID,
                    post.Created,
                    post.Modified,
                    post.Status,
                    post.Description,
                    post.ImageUrl,
                    post.UserID,
                    post.Content
                }).Single();
                return id;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return 0;
            }
        }
        public bool Update(Post post)
        {
            try
            {
                string query = "update Post set Name = @Name, Alias = @Alias, CategoryID = @CategoryID, " +
                    " Created=@Created,Modified=@Modified, " +
                    " Status=@Status,Description=@Description, " +
                    " ImageUrl=@ImageUrl,UserID=@UserID,Content=@Content " +
                        " where ID = @ID ";
                return 0 < connect.Execute(query, new
                {
                    post.Name,
                    post.Alias,
                    post.CategoryID,
                    post.Created,
                    post.Modified,
                    post.Status,
                    post.Description,
                    post.ImageUrl,
                    post.UserID,
                    post.Content,
                    post.ID
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
                string query = "delete from Post where ID = " + id;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }

        public void DeleteByCategoryID(int categoryID)
        {
            try
            {
                string query = "delete from Post where CategoryID = " + categoryID;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }
    }
}