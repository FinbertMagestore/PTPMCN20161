using Dapper;
using Education.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Education.Areas.Admin.Services
{

    public class SubjectService
    {
        private IDbConnection connect = new SqlConnection(Config.ConnectString);
        public List<Subject> GetAll()
        {
            try
            {
                string query = string.Format("select * from Subject");
                List<Subject> subjects = connect.Query<Subject>(query).ToList<Subject>();
                return subjects;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public List<Subject> GetByWhere(string where)
        {
            try
            {
                string query = string.Format("select * from Subject");
                if (!string.IsNullOrEmpty(where))
                {
                    query = string.Format("select * from Subject where " + where);
                }
                return connect.Query<Subject>(query).ToList();
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public Subject GetByPrimaryKey(int id)
        {
            try
            {
                string query = "select * from Subject where ID = " + id;
                Subject subject = connect.Query<Subject>(query).FirstOrDefault<Subject>();
                return subject;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public int Insert(Subject subject)
        {
            try
            {
                string query = "insert into Subject(" +
                        " SubjectName)" +
                        " values (@SubjectName)" +
                        " SELECT @@IDENTITY";
                int id = connect.Query<int>(query, new
                {
                    subject.SubjectName
                }).Single();
                return id;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return 0;
            }
        }
        public bool Update(Subject subject)
        {
            try
            {
                string query = "update Subject set SubjectName = @SubjectName " +
                        " where ID = @ID ";
                return 0 < connect.Execute(query, new
                {
                    subject.SubjectName,
                    subject.ID
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
                string query = "delete from Subject where ID = " + id;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }
    }

    public class ClassInfoService
    {
        private IDbConnection connect = new SqlConnection(Config.ConnectString);
        public List<ClassInfo> GetAll()
        {
            try
            {
                string query = string.Format("select * from ClassInfo");
                List<ClassInfo> subjects = connect.Query<ClassInfo>(query).ToList<ClassInfo>();
                return subjects;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public List<ClassInfo> GetByWhere(string where)
        {
            try
            {
                string query = string.Format("select * from ClassInfo");
                if (!string.IsNullOrEmpty(where))
                {
                    query = string.Format("select * from ClassInfo where " + where);
                }
                return connect.Query<ClassInfo>(query).ToList();
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public ClassInfo GetByPrimaryKey(int id)
        {
            try
            {
                string query = "select * from ClassInfo where ID = " + id;
                ClassInfo subject = connect.Query<ClassInfo>(query).FirstOrDefault<ClassInfo>();
                return subject;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public int Insert(ClassInfo subject)
        {
            try
            {
                string query = "insert into ClassInfo(" +
                        " ClassName,LevelID,Status)" +
                        " values (@ClassName,@LevelID,@Status)" +
                        " SELECT @@IDENTITY";
                int id = connect.Query<int>(query, new
                {
                    subject.ClassName,
                    subject.LevelID,
                    subject.Status
                }).Single();
                return id;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return 0;
            }
        }
        public bool Update(ClassInfo subject)
        {
            try
            {
                string query = "update ClassInfo set ClassName = @ClassName,LevelID = @LevelID,Status = @Status, " +
                        " where ID = @ID ";
                return 0 < connect.Execute(query, new
                {
                    subject.ClassName,
                    subject.LevelID,
                    subject.Status,
                    subject.ID
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
                string query = "delete from ClassInfo where ID = " + id;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }
    }
}