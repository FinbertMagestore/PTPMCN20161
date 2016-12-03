using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Education.Areas.Admin.Models;

namespace Education.Areas.Admin.Services
{
    public class DistrictService
    {
        private IDbConnection connect = new SqlConnection(Common.ConnectString);
        public List<District> GetAll()
        {
            try
            {
                string query = "select * from District order by DistrictID";
                List<District> customer = connect.Query<District>(query).ToList<District>();
                return customer;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return new List<District>();
            }
        }

        public static object GetDistrictName(int districtID)
        {
            IDbConnection sqlConnect = new SqlConnection(Common.ConnectString);
            try
            {
                if (districtID <= 0)
                {
                    return "";
                }
                string query = "select DistrictName from District where DistrictID = " + districtID;
                return sqlConnect.Query<string>(query).FirstOrDefault<string>();
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return "";
            }
        }

        public District GetByPrimaryKey(int districtID)
        {
            try
            {
                if (districtID <= 0)
                {
                    return null;
                }
                string query = "select * from District where DistrictID = " + districtID;
                District district = connect.Query<District>(query).FirstOrDefault();
                return district;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public List<District> GetByProvinceID(int provinceID)
        {
            try
            {
                if (provinceID <= 0)
                {
                    return null;
                }
                string query = "select * from District where ProvinceID = " + provinceID;
                List<District> districts = connect.Query<District>(query).ToList();
                return districts;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
    }
}