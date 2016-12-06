using Dapper;
using Education.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Education.Areas.Admin.Services
{
    public class LessionnService
    {
        private IDbConnection connect = new SqlConnection(Config.ConnectString);

        public List<Lession> GetAll()
        {
            try
            {
                string query = string.Format("select * from Lession order by Created desc");
                List<Lession> lessions = connect.Query<Lession>(query).ToList<Lession>();
                return lessions;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public List<Lession> GetAllActive()
        {
            try
            {
                string query = string.Format("select * from Lession where Status = {0} order by Created desc", (int)Config.Status.Active);
                List<Lession> lessions = connect.Query<Lession>(query).ToList<Lession>();
                return lessions;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public List<Lession> GetByWhere(string where)
        {
            try
            {
                string query = "";
                if (!string.IsNullOrEmpty(where))
                {
                    query = string.Format("select * from Lession where " + where + " order by Created desc");
                }
                else
                {
                    query = string.Format("select * from Lession order by Created desc");
                }
                return connect.Query<Lession>(query).ToList();
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public Lession GetByPrimaryKey(int id)
        {
            try
            {
                string query = "select * from Lession where ID = " + id;
                Lession lession = connect.Query<Lession>(query).FirstOrDefault<Lession>();
                return lession;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public List<Lession> GetByTeacherID(int teacherID)
        {
            try
            {
                string query = "select * from Lession where TeacherID = " + teacherID;
                List<Lession> lessions = connect.Query<Lession>(query).ToList();
                return lessions;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public int Insert(Lession lession)
        {
            try
            {
                string query = "insert into Lession(" +
                        " Name,Description,Created,Modified,Alias,Status,ImageUrl,TeacherID,RateAverage,SubjectClassID,DownloadCount)" +
                        " values (@Name,@Description,@Created,@Modified,@Alias,@Status,@ImageUrl,@TeacherID,@RateAverage,@SubjectClassID,@DownloadCount)" +
                        " SELECT @@IDENTITY";
                int id = connect.Query<int>(query, new
                {
                    lession.Name,
                    lession.Description,
                    lession.Created,
                    lession.Modified,
                    lession.Alias,
                    lession.Status,
                    lession.ImageUrl,
                    lession.TeacherID,
                    lession.RateAverage,
                    lession.SubjectClassID,
                    lession.DownloadCount
                }).Single();
                return id;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return 0;
            }
        }

        public bool Update(Lession lession)
        {
            try
            {
                string query = "update Lession set Name = @Name, Description = @Description, Created = @Created, " +
                    " Modified=@Modified,Alias=@Alias, " +
                    " Status=@Status,ImageUrl=@ImageUrl, " +
                    " TeacherID=@TeacherID,RateAverage=@RateAverage, " +
                    " SubjectClassID=@SubjectClassID,DownloadCount=@DownloadCount " +
                        " where ID = @ID ";
                return 0 < connect.Execute(query, new
                {
                    lession.Name,
                    lession.Description,
                    lession.Created,
                    lession.Modified,
                    lession.Alias,
                    lession.Status,
                    lession.ImageUrl,
                    lession.TeacherID,
                    lession.RateAverage,
                    lession.SubjectClassID,
                    lession.DownloadCount,
                    lession.ID
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
                string query = "delete from Lession where ID = " + id;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }

        public SubjectClass GetSubjectClass(int subjectClassID)
        {
            try
            {
                string query = "select * from SubjectClass where ID = " + subjectClassID;
                SubjectClass subjectClass = connect.Query<SubjectClass>(query).FirstOrDefault();
                return subjectClass;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public ClassInfo GetClassInfo(int classID)
        {
            try
            {
                string query = "select * from ClassInfo where ID = " + classID;
                ClassInfo classInfo = connect.Query<ClassInfo>(query).FirstOrDefault();
                return classInfo;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public Subject GetSubject(int subjectID)
        {
            try
            {
                string query = "select * from Subject where ID = " + subjectID;
                Subject subject = connect.Query<Subject>(query).FirstOrDefault();
                return subject;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
    }
}