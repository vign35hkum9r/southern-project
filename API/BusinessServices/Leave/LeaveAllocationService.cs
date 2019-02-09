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
    public class LeaveAllocationDataAccessLayer:ILeaveAllocation
    {
        public List<LeaveAllocationDTO> GetAllLeaveAllocation(LeaveAllocationGetDTO objLeave)
        {
            List<LeaveAllocationDTO> Leave = new List<LeaveAllocationDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectLeaveAllocation");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
                Leave = dbLayer.GetEntityList<LeaveAllocationDTO>(SqlCmd);
            }
            return Leave;
        }

        public LeaveAllocationDTO GetLeaveAllocationById(LeaveAllocationGetDTO objLeave)
        {
            LeaveAllocationDTO accounts = new LeaveAllocationDTO();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectLeaveAllocation");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Id", objLeave.Id);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
                accounts = dbLayer.GetEntityList<LeaveAllocationDTO>(SqlCmd).FirstOrDefault();
            }
            return accounts;
        }

        public List<LeaveAllocationDTO> GetActiveLeaveAllocation(LeaveAllocationGetDTO objLeave)
        {
            List<LeaveAllocationDTO> ActiveList = new List<LeaveAllocationDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectLeaveAllocation");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 1);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
                ActiveList = dbLayer.GetEntityList<LeaveAllocationDTO>(SqlCmd);
            }
            return ActiveList;
        }

        public List<LeaveAllocationDTO> GetInActiveLeaveAllocation(LeaveAllocationGetDTO objLeave)
        {
            List<LeaveAllocationDTO> InActiveList = new List<LeaveAllocationDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectLeaveAllocation");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 0);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
                InActiveList = dbLayer.GetEntityList<LeaveAllocationDTO>(SqlCmd);
            }
            return InActiveList;
        }

        public List<getAllEmployeeTypeDTO> GetAllEmployeetype(getEmployeeTypeDTO objLeave)
        {
            List<getAllEmployeeTypeDTO> empList = new List<getAllEmployeeTypeDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectEmployeeType");
                SqlCmd.CommandType = CommandType.StoredProcedure;       
                SqlCmd.Parameters.AddWithValue("@ActionBy", objLeave.ActionBy);
                empList = dbLayer.GetEntityList<getAllEmployeeTypeDTO>(SqlCmd);
            }
            return empList;
        }

        public bool InsertLeaveAllocation(List<LeaveAllocationInsertDTO> objLeave)
        {
            bool res = false;
            SqlCommand sqlCmd1 = new SqlCommand("spInsertLeaveAllocation");
            sqlCmd1.CommandType = CommandType.StoredProcedure;           
            sqlCmd1.Parameters.Add(new SqlParameter("@CompanyId", SqlDbType.Int));
            sqlCmd1.Parameters.Add(new SqlParameter("@EmployeeType", SqlDbType.Int));
            sqlCmd1.Parameters.Add(new SqlParameter("@ServiceId", SqlDbType.Int));
            sqlCmd1.Parameters.Add(new SqlParameter("@LeaveMasterId", SqlDbType.Int));
            sqlCmd1.Parameters.Add(new SqlParameter("@LeaveFrequencyId", SqlDbType.Int));
            sqlCmd1.Parameters.Add(new SqlParameter("@NoofDays", SqlDbType.Int));
            sqlCmd1.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.VarChar));
            foreach (var detail in objLeave)
            {
                if (sqlCmd1.Connection != null)
                {
                    if (sqlCmd1.Connection.State == ConnectionState.Closed)
                        sqlCmd1.Connection.Open();
                }
                sqlCmd1.Parameters["@CompanyId"].Value = detail.CompanyId;
                sqlCmd1.Parameters["@ServiceId"].Value = detail.ServiceId;
                sqlCmd1.Parameters["@EmployeeType"].Value = detail.EmployeeType;
                sqlCmd1.Parameters["@LeaveMasterId"].Value = (detail.LeaveMasterId == 0) ? null : detail.LeaveMasterId;
                sqlCmd1.Parameters["@LeaveFrequencyId"].Value = (detail.LeaveFrequencyId == 0) ? null : detail.LeaveFrequencyId;
                sqlCmd1.Parameters["@NoofDays"].Value = (detail.NoofDays == 0) ? null : detail.NoofDays;
                sqlCmd1.Parameters["@CreatedBy"].Value = (detail.CreatedBy == null) ? null : detail.CreatedBy;
                int queryRes = new DbLayer().ExecuteNonQuery(sqlCmd1);
                if (queryRes != Int32.MaxValue)
                {
                    res = true;
                }
                else
                {
                    // this part needed error handling code.
                    res = false;
                }
            }
            return res;
        }

        public bool UpdateLeaveAllocation(LeaveAllocationUpdateDTO Leave)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateLeaveAllocation");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@CompanyId", Leave.CompanyId);
            SqlCmd.Parameters.AddWithValue("@ServiceId", Leave.ServiceId);
            SqlCmd.Parameters.AddWithValue("@LeaveId", Leave.LeaveId);
            SqlCmd.Parameters.AddWithValue("@FrequencyId", Leave.FrequencyId);
            SqlCmd.Parameters.AddWithValue("@NoOfDays", Leave.NoOfDays);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", Leave.ModifiedBy);
            SqlCmd.Parameters.AddWithValue("@Active", Leave.Active);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool DeactivateLeaveAllocation(LeaveAllocationRemoveDTO objLeave)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteLeaveAllocation");
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@Id", objLeave.Id);
            //sqlcmd.Parameters.AddWithValue("@Active", objLeave.Active);
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
