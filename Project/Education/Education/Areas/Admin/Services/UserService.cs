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

    public class TeacherService
    {
        private IDbConnection connect = new SqlConnection(Config.ConnectString);
        public List<Teacher> GetAll()
        {
            try
            {
                string query = string.Format("select * from Teacher left join AppUsers on Teacher.UserID = AppUsers.Id");
                List<Teacher> teachers = connect.Query<Teacher>(query).ToList<Teacher>();
                return teachers;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public List<Teacher> GetByWhere(string where)
        {
            try
            {
                string query = string.Format("select * from Teacher left join AppUsers on Teacher.UserID = AppUsers.Id");
                if (!string.IsNullOrEmpty(where))
                {
                    query = string.Format("select * from Teacher left join AppUsers on Teacher.UserID = AppUsers.Id where " + where);
                }
                return connect.Query<Teacher>(query).ToList();
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public Teacher GetByPrimaryKey(int id)
        {
            try
            {
                string query = "select * from Teacher left join AppUsers on Teacher.UserID = AppUsers.Id where Teacher.ID = " + id;
                Teacher teacher = connect.Query<Teacher>(query).FirstOrDefault<Teacher>();
                return teacher;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public Teacher GetByUserID(int userID)
        {
            try
            {
                string query = "select * from Teacher where UserID = " + userID;
                return connect.Query<Teacher>(query).FirstOrDefault();
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public int Insert(Teacher teacher)
        {
            try
            {
                string query = "insert into Teacher(" +
                        " UserID,ExperienceYear,MainSubjectID,SchoolID,SchoolName)" +
                        " values (@UserID,@ExperienceYear,@MainSubjectID,@SchoolID,@SchoolName)" +
                        " SELECT @@IDENTITY";
                int id = connect.Query<int>(query, new
                {
                    teacher.UserID,
                    teacher.ExperienceYear,
                    teacher.MainSubjectID,
                    teacher.SchoolID,
                    teacher.SchoolName
                }).Single();
                return id;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return 0;
            }
        }
        public bool Update(Teacher teacher)
        {
            try
            {
                string query = "update Teacher set UserID = @UserID, ExperienceYear = @ExperienceYear, MainSubjectID = @MainSubjectID, "
                    + " SchoolID=@SchoolID,SchoolName=@SchoolName"
                    + " where ID = @ID ";
                return 0 < connect.Execute(query, new
                {
                    teacher.UserID,
                    teacher.ExperienceYear,
                    teacher.MainSubjectID,
                    teacher.ID
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
                string query = "delete from Teacher where ID = " + id;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }

        public void DeleteByUserID(int userID)
        {
            try
            {
                string query = "delete from Teacher where UserID = " + userID;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }

        public void DeleteByMainSubjectID(int mainSubjectID)
        {
            try
            {
                string query = "delete from Student where MainSubjectID = " + mainSubjectID;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }
    }

    public class StudentService
    {
        private IDbConnection connect = new SqlConnection(Config.ConnectString);
        public List<Student> GetAll()
        {
            try
            {
                string query = string.Format("select * from Student left join AppUsers on Student.UserID = AppUsers.Id");
                List<Student> students = connect.Query<Student>(query).ToList<Student>();
                return students;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public List<Student> GetByWhere(string where)
        {
            try
            {
                string query = string.Format("select * from Student left join AppUsers on Student.UserID = AppUsers.Id");
                if (!string.IsNullOrEmpty(where))
                {
                    query = string.Format("select * from Student left join AppUsers on Student.UserID = AppUsers.Id where " + where);
                }
                return connect.Query<Student>(query).ToList();
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public Student GetByPrimaryKey(int id)
        {
            try
            {
                string query = "select * from Student left join AppUsers on Student.UserID = AppUsers.Id where Student.ID = " + id;
                Student student = connect.Query<Student>(query).FirstOrDefault();
                return student;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public Student GetByUserID(int userID)
        {
            try
            {
                string query = "select * from Student where UserID = " + userID;
                return connect.Query<Student>(query).FirstOrDefault();
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public int Insert(Student student)
        {
            try
            {
                string query = "insert into Student(" +
                        " UserID,ClassInfoID,ClassName,SchoolID,SchoolName)" +
                        " values (@UserID,@ClassInfoID,@ClassName,@SchoolID,@SchoolName)" +
                        " SELECT @@IDENTITY";
                int id = connect.Query<int>(query, new
                {
                    student.UserID,
                    student.ClassInfoID,
                    student.ClassName,
                    student.SchoolID,
                    student.SchoolName
                }).Single();
                return id;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return 0;
            }
        }
        public bool Update(Student student)
        {
            try
            {
                string query = "update Student set UserID = @UserID, ClassInfoID = @ClassInfoID, ClassName = @ClassName, "
                    + " SchoolID = @SchoolID, SchoolName = @SchoolName "
                    + " where ID = @ID ";
                return 0 < connect.Execute(query, new
                {
                    student.UserID,
                    student.ClassInfoID,
                    student.ClassName,
                    student.SchoolID,
                    student.SchoolName,
                    student.ID
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
                string query = "delete from Student where ID = " + id;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }

        public void DeleteByUserID(int userID)
        {
            try
            {
                string query = "delete from Student where UserID = " + userID;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }

        public void DeleteByClassInfoID(int classInfoID)
        {
            try
            {
                string query = "delete from Student where ClassInfoID = " + classInfoID;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }
    }
}