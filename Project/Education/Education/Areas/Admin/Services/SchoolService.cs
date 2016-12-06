using Dapper;
using Education.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Education.Areas.Admin.Services
{
    public class LevelEducationService
    {
        private IDbConnection connect = new SqlConnection(Config.ConnectString);
        public List<LevelEducation> GetAll()
        {
            try
            {
                string query = string.Format("select * from LevelEducation");
                List<LevelEducation> teachers = connect.Query<LevelEducation>(query).ToList<LevelEducation>();
                return teachers;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public List<LevelEducation> GetByWhere(string where)
        {
            try
            {
                string query = string.Format("select * from LevelEducation");
                if (!string.IsNullOrEmpty(where))
                {
                    query = string.Format("select * from LevelEducation where " + where);
                }
                return connect.Query<LevelEducation>(query).ToList();
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public LevelEducation GetByPrimaryKey(int id)
        {
            try
            {
                string query = "select * from LevelEducation where ID = " + id;
                LevelEducation teacher = connect.Query<LevelEducation>(query).FirstOrDefault<LevelEducation>();
                return teacher;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public int Insert(LevelEducation teacher)
        {
            try
            {
                string query = "insert into LevelEducation(" +
                        " Code,Name)" +
                        " values (@Code,@Name)" +
                        " SELECT @@IDENTITY";
                int id = connect.Query<int>(query, new
                {
                    teacher.Code,
                    teacher.Name
                }).Single();
                return id;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return 0;
            }
        }
        public bool Update(LevelEducation teacher)
        {
            try
            {
                string query = "update LevelEducation set Code = @Code,Name = @Name " +
                        " where ID = @ID ";
                return 0 < connect.Execute(query, new
                {
                    teacher.Code,
                    teacher.Name,
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
                string query = "delete from LevelEducation where ID = " + id;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }
    }

    public class SchoolService
    {
        private IDbConnection connect = new SqlConnection(Config.ConnectString);
        public List<School> GetAll()
        {
            try
            {
                string query = string.Format("select * from School");
                List<School> teachers = connect.Query<School>(query).ToList<School>();
                return teachers;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public List<School> GetByWhere(string where)
        {
            try
            {
                string query = string.Format("select * from School");
                if (!string.IsNullOrEmpty(where))
                {
                    query = string.Format("select * from School where " + where);
                }
                return connect.Query<School>(query).ToList();
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public School GetByPrimaryKey(int id)
        {
            try
            {
                string query = "select * from School where ID = " + id;
                School teacher = connect.Query<School>(query).FirstOrDefault<School>();
                return teacher;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public int Insert(School teacher)
        {
            try
            {
                string query = "insert into School(" +
                        " TownID,SchoolTypeID,Address,LevelID,Status,Name)" +
                        " values (@TownID,@SchoolTypeID,@Address,@LevelID,@Status,@Name)" +
                        " SELECT @@IDENTITY";
                int id = connect.Query<int>(query, new
                {
                    teacher.TownID,
                    teacher.SchoolTypeID,
                    teacher.Address,
                    teacher.LevelID,
                    teacher.Status,
                    teacher.Name
                }).Single();
                return id;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return 0;
            }
        }
        public bool Update(School teacher)
        {
            try
            {
                string query = "update School set TownID = @TownID,SchoolTypeID = @SchoolTypeID,Address = @Address,LevelID = @LevelID,Status = @Status,Name = @Name " +
                        " where ID = @ID ";
                return 0 < connect.Execute(query, new
                {
                    teacher.TownID,
                    teacher.SchoolTypeID,
                    teacher.Address,
                    teacher.LevelID,
                    teacher.Status,
                    teacher.Name,
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
                string query = "delete from School where ID = " + id;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }
    }

    public class SchoolTypeService
    {
        private IDbConnection connect = new SqlConnection(Config.ConnectString);
        public List<SchoolType> GetAll()
        {
            try
            {
                string query = string.Format("select * from SchoolType");
                List<SchoolType> teachers = connect.Query<SchoolType>(query).ToList<SchoolType>();
                return teachers;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public List<SchoolType> GetByWhere(string where)
        {
            try
            {
                string query = string.Format("select * from SchoolType");
                if (!string.IsNullOrEmpty(where))
                {
                    query = string.Format("select * from SchoolType where " + where);
                }
                return connect.Query<SchoolType>(query).ToList();
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public SchoolType GetByPrimaryKey(int id)
        {
            try
            {
                string query = "select * from SchoolType where ID = " + id;
                SchoolType teacher = connect.Query<SchoolType>(query).FirstOrDefault<SchoolType>();
                return teacher;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public int Insert(SchoolType teacher)
        {
            try
            {
                string query = "insert into SchoolType(" +
                        " Code,Name,Description)" +
                        " values (@Code,@Name,@Description)" +
                        " SELECT @@IDENTITY";
                int id = connect.Query<int>(query, new
                {
                    teacher.Code,
                    teacher.Name,
                    teacher.Description
                }).Single();
                return id;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return 0;
            }
        }
        public bool Update(SchoolType teacher)
        {
            try
            {
                string query = "update SchoolType set Code = @Code,Name = @Name,Description = @Description " +
                        " where ID = @ID ";
                return 0 < connect.Execute(query, new
                {
                    teacher.Code,
                    teacher.Name,
                    teacher.Description,
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
                string query = "delete from SchoolType where ID = " + id;
                connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }
    }
}