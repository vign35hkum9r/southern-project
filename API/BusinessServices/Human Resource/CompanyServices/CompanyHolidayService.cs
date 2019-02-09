using BusinessEntities;
using DataModel.DBLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BusinessServices
{
    public class CompanyHolidayDataAccessLayer:ICompanyHolidayService
    {
        public List<CompanyHolidayDTO> GetAllCompanyHoliday(CompanyHolidayGetDTO objLeave)
        {
            List<CompanyHolidayDTO> Leave = new List<CompanyHolidayDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectCompanyHoliday");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
                Leave = dbLayer.GetEntityList<CompanyHolidayDTO>(SqlCmd);
            }
            return Leave;
        }

        public CompanyHolidayDTO GetCompanyHolidayById(CompanyHolidayGetDTO objLeave)
        {
            CompanyHolidayDTO accounts = new CompanyHolidayDTO();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectCompanyHoliday");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Id", objLeave.Id);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
                accounts = dbLayer.GetEntityList<CompanyHolidayDTO>(SqlCmd).FirstOrDefault();
            }
            return accounts;
        }

        public List<CompanyHolidayDTO> GetActiveCompanyHoliday(CompanyHolidayGetDTO objLeave)
        {
            List<CompanyHolidayDTO> ActiveList = new List<CompanyHolidayDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectCompanyHoliday");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 1);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
                ActiveList = dbLayer.GetEntityList<CompanyHolidayDTO>(SqlCmd);
            }
            return ActiveList;
        }

        public List<CompanyHolidayDTO> GetInActiveCompanyHoliday(CompanyHolidayGetDTO objLeave)
        {
            List<CompanyHolidayDTO> InActiveList = new List<CompanyHolidayDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectCompanyHoliday");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 0);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
                InActiveList = dbLayer.GetEntityList<CompanyHolidayDTO>(SqlCmd);
            }
            return InActiveList;
        }

        public bool InsertCompanyHoliday(CompanyHolidayInsertDTO objLeave)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertCompanyHoliday");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@CompanyId", objLeave.CompanyId);
            SqlCmd.Parameters.AddWithValue("@EmployeeType", objLeave.EmployeeType);
            SqlCmd.Parameters.AddWithValue("@Date", objLeave.Date);
            SqlCmd.Parameters.AddWithValue("@Description", objLeave.Description);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objLeave.CreatedBy);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;

        }

        public bool UpdateCompanyHoliday(CompanyHolidayUpdateDTO Leave)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateCompanyHoliday");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Id", Leave.Id);
            SqlCmd.Parameters.AddWithValue("@CompanyId", Leave.CompanyId);
            SqlCmd.Parameters.AddWithValue("@EmployeeType", Leave.EmployeeType);
            SqlCmd.Parameters.AddWithValue("@Date", Leave.Date);
            SqlCmd.Parameters.AddWithValue("@Description", Leave.Description);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", Leave.ModifiedBy);
            SqlCmd.Parameters.AddWithValue("@Active", Leave.Active);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool DeactivateCompanyHoliday(CompanyHolidayRemoveDTO objLeave)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteCompanyHoliday");
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@Id", objLeave.Id);
            sqlcmd.Parameters.AddWithValue("@Active", objLeave.Active);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
            int result = new DbLayer().ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
    }
}
