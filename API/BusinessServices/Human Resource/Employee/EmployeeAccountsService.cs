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
    public class EmployeeAccountsDataAccessLayer:IEmployeeAccountService
    {
        public List<GetEmployeeDTO> GetEmployee(EmplyoeeAccountsGetDTO objGetEmp)
        {
            List<GetEmployeeDTO> empList = new List<GetEmployeeDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectEmployeeAccount");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 1);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetEmp.ActionBy);
                empList = dbLayer.GetEntityList<GetEmployeeDTO>(SqlCmd);
            }
            return empList;
        }


        public List<EmployeeAccountsDTO> GetAllEmployeeAccounts(EmplyoeeAccountsGetDTO objGetAccount)
        {
            List<EmployeeAccountsDTO> accounts = new List<EmployeeAccountsDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectAccount");            
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetAccount.ActionBy);
                accounts = dbLayer.GetEntityList<EmployeeAccountsDTO>(SqlCmd);
            }
            return accounts;
        }

        public EmployeeAccountsDTO GetEmployeeAccountsById(EmplyoeeAccountsGetDTO objGetAccById)
        {
            EmployeeAccountsDTO accounts = new EmployeeAccountsDTO();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectAccount");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Id", objGetAccById.Id);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objGetAccById.ActionBy);
                accounts = dbLayer.GetEntityList<EmployeeAccountsDTO>(SqlCmd).FirstOrDefault();
            }
            return accounts;
        }

        public List<EmployeeAccountsDTO> GetActiveEmployeeAccount(EmplyoeeAccountsGetDTO objActive)
        {
            List<EmployeeAccountsDTO> activeList = new List<EmployeeAccountsDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectAccount");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 1);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objActive.ActionBy);
                activeList = dbLayer.GetEntityList<EmployeeAccountsDTO>(SqlCmd);
            }
            return activeList;
        }

        public List<EmployeeAccountsDTO>GetInActiveEmployeeAccount(EmplyoeeAccountsGetDTO objInActive)
        {
            List<EmployeeAccountsDTO> inActiveList = new List<EmployeeAccountsDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectAccount");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 0);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objInActive.ActionBy);
                inActiveList = dbLayer.GetEntityList<EmployeeAccountsDTO>(SqlCmd);
            }
            return inActiveList;
        }

        public bool InsertEmployeeAccounts(EmployeeAccountsInsertDTO objAccount)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertAccount");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@EmployeeId", objAccount.EmployeeId);
            SqlCmd.Parameters.AddWithValue("@AccountNo", objAccount.AccountNo);
            SqlCmd.Parameters.AddWithValue("@PaymentMode", objAccount.PaymentMode);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objAccount.CreatedBy);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool CheckAccount(GetEmployeeDTO objCheck)
        {
            bool res = false;

            SqlCommand sqlcmd = new SqlCommand("spCheckAccount");
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@EmployeeId", objCheck.EmployeeId);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objCheck.ActionBy);
            int accCount = new DbLayer().GetEntityList<CheckAccountDTO>(sqlcmd).FirstOrDefault().Count;

            if (accCount > 0)
                res = false;
            else
                res = true;

            return res;
        }



        public bool UpdateEmployeeAccounts(EmployeeAccountsUpdateDTO objAccount)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateAccount");
            SqlCmd.CommandType = CommandType.StoredProcedure;            
            SqlCmd.Parameters.AddWithValue("@Id", objAccount.Id);
            SqlCmd.Parameters.AddWithValue("@AccountNo", objAccount.AccountNo);
            SqlCmd.Parameters.AddWithValue("@PaymentMode", objAccount.PaymentMode);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", objAccount.ModifiedBy);
            SqlCmd.Parameters.AddWithValue("@Active", objAccount.Active);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool RemoveEmployeeAccount(EmployeeAccountRemoveDTO objRemoveAcc)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteAccount");
            sqlcmd.Parameters.AddWithValue("@Id", objRemoveAcc.Id);
            sqlcmd.Parameters.AddWithValue("@EmployeeId", objRemoveAcc.EmployeeId);
            sqlcmd.Parameters.AddWithValue("@Active", objRemoveAcc.Active);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objRemoveAcc.ActionBy);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            int result = new DbLayer().ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
    }
}
