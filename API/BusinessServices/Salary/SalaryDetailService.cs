using SouthernERP.DataLayer.Models;
using SouthernERPApi.DBLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SouthernERP.DataLayer.DataAccessLayer
{
    public class SalaryDetailDataAccessLayer
    {
        public List<SalaryDetailDTO> GetAllSalaryDetail(SalaryDetailGetDTO objSalary)
        {
            List<SalaryDetailDTO> salary = new List<SalaryDetailDTO>();
            using (DataBaseLayer dbLayer = new DataBaseLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectSalaryDetail");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy", 1001);
                salary = dbLayer.GetEntityList<SalaryDetailDTO>(SqlCmd);
            }
            return salary;
        }

        public List<SalaryDetailDTO> GetSalaryDetailById(SalaryDetailGetDTO objSalary)
        {
            List<SalaryDetailDTO> accounts = new List<SalaryDetailDTO>();
            using (DataBaseLayer dbLayer = new DataBaseLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectSalaryDetail");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@EmployeeId", objSalary.EmployeeId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objSalary.ActionBy);
                accounts = dbLayer.GetEntityList<SalaryDetailDTO>(SqlCmd);
            }
            return accounts;
        }


        public List<SalaryDetailDTO> GetActiveSalaryDetail(SalaryDetailGetDTO objSalary)
        {
            List<SalaryDetailDTO> ActiveList = new List<SalaryDetailDTO>();
            using (DataBaseLayer dbLayer = new DataBaseLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectSalaryDetail");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 1);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objSalary.ActionBy);
                ActiveList = dbLayer.GetEntityList<SalaryDetailDTO>(SqlCmd);
            }
            return ActiveList;
        }

        public List<SalaryDetailDTO> GetInActiveSalaryDetail(SalaryDetailGetDTO objSalary)
        {
            List<SalaryDetailDTO> InActiveList = new List<SalaryDetailDTO>();
            using (DataBaseLayer dbLayer = new DataBaseLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectSalaryDetail");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 0);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objSalary.ActionBy);
                InActiveList = dbLayer.GetEntityList<SalaryDetailDTO>(SqlCmd);
            }
            return InActiveList;
        }

        public bool InsertSalaryDetail(SalaryDetailInsertDTO objSalary)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertSalaryDetail");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@EmployeeId", objSalary.EmployeeId);
            SqlCmd.Parameters.AddWithValue("@SalaryCompensate", objSalary.SalaryCompensate);
            SqlCmd.Parameters.AddWithValue("@Amount", objSalary.Amount);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objSalary.CreatedBy);
            int result = new DataBaseLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool UpdateSalaryDetail(SalaryDetailUpdateDTO salary)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Id", salary.EmployeeId);
            SqlCmd.Parameters.AddWithValue("@SalaryCompensate", salary.SalaryCompensate);
            SqlCmd.Parameters.AddWithValue("@Amount", salary.Amount);           
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", salary.ModifiedBy);
            SqlCmd.Parameters.AddWithValue("@Active", salary.Active);
            int result = new DataBaseLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool RemoveSalaryDetail(SalaryDetailRemoveDTO objSalary)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteSalaryDetail");
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@Id", objSalary.Id);           
            sqlcmd.Parameters.AddWithValue("@ActionBy", objSalary.ActionBy);
            int result = new DataBaseLayer().ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

    }
}
