using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BusinessEntities;
using DataModel.DBLayer;

namespace BusinessServices
{
    public class SalaryCompensateDataAccessLayer
    {

        public List<SalaryCompensateDTO> GetAllSalaryCompensate(SalaryCompensateGetDTO objSalary)
        {
            List<SalaryCompensateDTO> salary = new List<SalaryCompensateDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectSalaryComponent");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy", objSalary.ActionBy);
                salary = dbLayer.GetEntityList<SalaryCompensateDTO>(SqlCmd);
            }
            return salary;
        }

        public SalaryCompensateDTO GetSalaryCompensateById(SalaryCompensateGetDTO objSalary)
        {
            SalaryCompensateDTO accounts = new SalaryCompensateDTO();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectSalaryComponent");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Id", objSalary.Id);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objSalary.ActionBy);
                accounts = dbLayer.GetEntityList<SalaryCompensateDTO>(SqlCmd).FirstOrDefault();
            }
            return accounts;
        }

        public List<SalaryCompensateDTO> GetActiveSalaryCompensate(SalaryCompensateGetDTO objSalary)
        {
            List<SalaryCompensateDTO> ActiveList = new List<SalaryCompensateDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectSalaryComponent");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 1);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objSalary.ActionBy);
                ActiveList = dbLayer.GetEntityList<SalaryCompensateDTO>(SqlCmd);
            }
            return ActiveList;
        }

        public List<SalaryCompensateDTO> GetInActiveSalaryCompensate(SalaryCompensateGetDTO objSalary)
        {
            List<SalaryCompensateDTO> InActiveList = new List<SalaryCompensateDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSalaryComponent");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 0);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objSalary.ActionBy);
                InActiveList = dbLayer.GetEntityList<SalaryCompensateDTO>(SqlCmd);
            }
            return InActiveList;
        }

        public bool InsertSalary(SalaryCompensateInsertDTO objSalary)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertSalaryComponent");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Name", objSalary.Name);
            SqlCmd.Parameters.AddWithValue("@ComponentType", objSalary.ComponentType);        
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objSalary.CreatedBy);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool UpdateSalary(SalaryCompensateUpdateDTO salary)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateSalaryComponent");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Id", salary.Id);
            SqlCmd.Parameters.AddWithValue("@Name", salary.Name);
            SqlCmd.Parameters.AddWithValue("@ComponentType", salary.ComponentType);            
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", salary.ModifiedBy);
            SqlCmd.Parameters.AddWithValue("@Active", salary.Active);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool DeactivateSalary(SalaryCompensateRemoveDTO objSalary)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteSalaryComponent");
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@Id", objSalary.Id);
            sqlcmd.Parameters.AddWithValue("@Active", objSalary.Active);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objSalary.ActionBy);
            int result = new DbLayer().ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
    }
}
