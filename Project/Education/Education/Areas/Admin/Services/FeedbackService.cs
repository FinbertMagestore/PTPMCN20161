using Dapper;
using Education.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Education.Areas.Admin.Services
{
    public class FeedbackService
    {
        private IDbConnection connect = new SqlConnection(Config.ConnectString);
        public List<Feedback> GetAll()
        {
            try
            {
                string query = "select * from Feedback order by Created desc";
                List<Feedback> feedbacks = connect.Query<Feedback>(query).ToList<Feedback>();
                return feedbacks;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public List<Feedback> GetByWhere(string where)
        {
            try
            {
                string query = "";
                if (!string.IsNullOrEmpty(where))
                {
                    query = string.Format("select * from Feedback where " + where + " order by Created desc");
                }
                else
                {
                    query = string.Format("select * from Feedback order by Created desc");
                }
                return connect.Query<Feedback>(query).ToList();
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public Feedback GetByPrimaryKey(int id)
        {
            try
            {
                string query = "select * from Feedback where ID = " + id;
                Feedback feedback = connect.Query<Feedback>(query).FirstOrDefault();
                return feedback;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public int Insert(Feedback feedback)
        {
            try
            {
                string query = "insert into Feedback(" +
                        " Created,Content,Name,Email,State,ImageUrl)" +
                        " values (@Created,@Content,@Name,@Email,@Modified,@State,@ImageUrl)" +
                        " SELECT @@IDENTITY";
                int id = connect.Query<int>(query, new
                {
                    feedback.Created,
                    feedback.Content,
                    feedback.Name,
                    feedback.Email,
                    feedback.State,
                    feedback.ImageUrl
                }).Single();
                return id;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return 0;
            }
        }
        public bool Update(Feedback feedback)
        {
            try
            {
                string query = "update Feedback set Created = @Created, Content = @Content, Name = @Name, " +
                    " Email=@Email,Email=@Email, " +
                    " State=@State,ImageUrl=@ImageUrl " +
                        " where ID = @ID ";
                return 0 < connect.Execute(query, new
                {
                    feedback.Created,
                    feedback.Content,
                    feedback.Name,
                    feedback.Email,
                    feedback.State,
                    feedback.ImageUrl,
                    feedback.ID
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
                string query = "delete from Feedback where ID = " + id;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }
    }
}