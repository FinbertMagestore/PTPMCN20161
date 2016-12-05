using Dapper;
using Education.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Education.Areas.Admin.Services
{
    public class ReportService
    {
        private IDbConnection connect = new SqlConnection(Config.ConnectString);
        public List<Report> GetAll()
        {
            try
            {
                string query = string.Format("select * from Report order by Created desc");
                List<Report> reports = connect.Query<Report>(query).ToList<Report>();
                return reports;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public List<Report> GetByWhere(string where)
        {
            try
            {
                string query = "";
                if (!string.IsNullOrEmpty(where))
                {
                    query = string.Format("select * from Report where " + where + " order by Created desc");
                }
                else
                {
                    query = string.Format("select * from Report order by Created desc");
                }
                return connect.Query<Report>(query).ToList();
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public Report GetByPrimaryKey(int id)
        {
            try
            {
                string query = "select * from Report where ID = " + id;
                Report report = connect.Query<Report>(query).FirstOrDefault<Report>();
                return report;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public int Insert(Report report)
        {
            try
            {
                string query = "insert into Report("+
                        " UserID,Content,Created,ReportTypeID,State,ImageUrl)" +
                        " values (@UserID,@Content,@Created,@ReportTypeID,@State,@ImageUrl)" +
                        " SELECT @@IDENTITY";
                int productID = connect.Query<int>(query, new
                {
                    report.UserID,
                    report.Content,
                    report.Created,
                    report.ReportTypeID,
                    report.State,
                    report.ImageUrl
                }).Single();
                return productID;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return 0;
            }
        }
        public bool Update(Report report)
        {
            try
            {
                string query = "update Report set UserID = @UserID, Content = @Content, Created = @Created, " +
                    " ReportTypeID=@ReportTypeID,State=@State,ImageUrl=@ImageUrl " +
                        " where ID = @ID ";
                return 0 < connect.Execute(query, new
                {

                    report.UserID,
                    report.Content,
                    report.Created,
                    report.ReportTypeID,
                    report.State,
                    report.ImageUrl,
                    report.ID
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
                string query = "delete from Report where ID = " + id;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }

        public string GetReportType(int id)
        {
            Report report = GetByPrimaryKey(id);
            string query = "select Name from ReportType where ID = " +report.ReportTypeID;
            return connect.Query<string>(query).Single();
        }
    }
}